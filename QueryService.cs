using System.Diagnostics;
using System.Linq;
using QueryMaster;


namespace QueryMasterTester
{
    public enum QueryBackend
    {
        OpenGSQ,
        QueryMaster
    }

    public static class QueryService
    {
        public static async Task<Server> ProcessAsync(string addr, int appId, QueryBackend backend = QueryBackend.OpenGSQ)
        {
            if (string.IsNullOrWhiteSpace(addr) || addr.IndexOf(":", StringComparison.Ordinal) == -1)
            {
                return new Server
                {
                    Addr = addr ?? string.Empty,
                    AppId = appId,
                    Online = false
                };
            }

            var operationStopwatch = Stopwatch.StartNew();
            try
            {
                var rAddr = addr.Split(":");
                var ip = rAddr[0];
                var port = int.Parse(rAddr[1]);

                string name = string.Empty;
                int playersCount = 0;
                int maxPlayers = 0;
                int bots = 0;
                string map = string.Empty;
                bool secure = false;
                bool dedicated = false;
                string os = string.Empty;
                Dictionary<string, string>? rules = null;
                List<PlayerInfo> playerList = new();

                if (backend == QueryBackend.OpenGSQ)
                {
                    var source = new OpenGSQ.Protocols.Source(ip, port, 30000);
                    var info = await source.GetInfo();
                    var rulesResp = await source.GetRules();
                    name = info.Name;
                    playersCount = info.Players;
                    maxPlayers = info.MaxPlayers;
                    bots = info.Bots;
                    map = info.Map;
                    secure = info.VAC == OpenGSQ.Responses.Source.VAC.Secured;
                    dedicated = info.ServerType == OpenGSQ.Responses.Source.ServerType.Dedicated;
                    os = info.Environment switch
                    {
                        OpenGSQ.Responses.Source.Environment.Linux => "linux",
                        OpenGSQ.Responses.Source.Environment.Windows => "windows",
                        OpenGSQ.Responses.Source.Environment.Mac => "mac",
                        _ => string.Empty
                    };
                    if (rulesResp is not null) rules = new Dictionary<string, string>(rulesResp);
                    try
                    {
                        var players = await source.GetPlayers();
                        if (players is not null)
                        {
                            foreach (var p in players)
                            {
                                playerList.Add(new PlayerInfo { Name = p.Name, Score = p.Score, DurationSeconds = (int)Math.Round(p.Duration) });
                            }
                        }
                    }
                    catch { }
                }
                else
                {
                    var serverQM = QueryMaster.ServerQuery.GetServerInstance(QueryMaster.EngineType.Source, ip, (ushort)port);
                    var info = serverQM.GetInfo();
                    name = info.Name;
                    playersCount = info.Players;
                    maxPlayers = info.MaxPlayers;
                    bots = info.Bots;
                    map = info.Map;
                    secure = info.IsSecure;
                    //dedicated = info.ServerType;
                    //os = info.Os == QueryMaster.GameServer.OperatingSystem.Windows ? "windows" : info.Os == QueryMaster.GameServer.OperatingSystem.Linux ? "linux" : string.Empty;
                    try
                    {
                        var rulesResp = serverQM.GetRules();
                        //rules = rulesResp?.ToDictionary(kv => kv.Key, kv => kv.Value);
                    }
                    catch { }
                    try
                    {
                        var players = serverQM.GetPlayers();
                        if (players != null)
                        {
                            //foreach (var p in players)
                            //{
                            //    playerList.Add(new PlayerInfo { Name = p.Name, Score = p.Score, DurationSeconds = (int)Math.Round(p.Time) });
                            //}
                        }
                    }
                    catch { }
                }

                var server = new Server
                {
                    Addr = addr,
                    Gameport = port,
                    Name = name,
                    AppId = appId,
                    Players = playersCount,
                    MaxPlayers = maxPlayers,
                    Bots = bots,
                    Map = map,
                    Secure = secure,
                    Dedicated = dedicated,
                    Os = os,
                    CreatedAt = DateTime.UtcNow,
                };
                if (rules is not null)
                {
                    server.Rules = new Dictionary<string, string>(rules);
                }
                server.PlayerList = playerList;

                server.Online = true;
                return server;
            }
             catch (OpenGSQ.Exceptions.TimeoutException ex)
             {
                Console.WriteLine($"Timeout handling server {addr}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling server {addr}: {ex.Message}");
            }
            finally
            {
                try { operationStopwatch.Stop(); } catch { }
            }

            return new Server
            {
                Addr = addr,
                AppId = appId,
                Online = false
            };
        }
    }

    public class Server
    {
        public string Addr { get; set; } = string.Empty;
        public int AppId { get; set; }
        public bool Online { get; set; }

        public int Gameport { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Players { get; set; }
        public int MaxPlayers { get; set; }
        public int Bots { get; set; }
        public string Map { get; set; } = string.Empty;
        public bool PvE { get; set; }
        public bool Secure { get; set; }
        public bool Dedicated { get; set; }
        public string Os { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public List<PlayerInfo> PlayerList { get; set; } = new List<PlayerInfo>();
        public Dictionary<string, string> Rules { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // For change tracking of rules per server instance
        public Dictionary<string, string> PreviousRules { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }

    public class PlayerInfo
    {
        public string Name { get; set; } = string.Empty;
        public long Score { get; set; }
        public int DurationSeconds { get; set; }
    }
}
