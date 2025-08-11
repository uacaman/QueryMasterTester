using System.Diagnostics;

namespace QueryMasterTester
{
    public static class QueryService
    {
        public static async Task<Server> ProcessAsync(string addr, int appId)
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

                var source = new OpenGSQ.Protocols.Source(ip, port, 10000);

                var info = await source.GetInfo();
                var rules = await source.GetRules();

                var server = new Server
                {
                    Addr = addr,
                    Gameport = port,
                    Name = info.Name,
                    AppId = appId,
                    Players = info.Players,
                    MaxPlayers = info.MaxPlayers,
                    Bots = info.Bots,
                    Map = info.Map,
                    Secure = info.VAC == OpenGSQ.Responses.Source.VAC.Secured,
                    Dedicated = info.ServerType == OpenGSQ.Responses.Source.ServerType.Dedicated,
                    Os = info.Environment switch
                    {
                        OpenGSQ.Responses.Source.Environment.Linux => "linux",
                        OpenGSQ.Responses.Source.Environment.Windows => "windows",
                        OpenGSQ.Responses.Source.Environment.Mac => "mac",
                        _ => string.Empty
                    },
                    CreatedAt = DateTime.UtcNow,
                };
                if (rules is not null)
                {
                    server.Rules = new Dictionary<string, string>(rules);
                }

                try
                {
                    var players = await source.GetPlayers();
                    if (players is not null)
                    {
                        foreach (var p in players)
                        {
                            server.PlayerList.Add(new PlayerInfo
                            {
                                Name = p.Name,
                                Score = p.Score,
                                DurationSeconds = (int)Math.Round(p.Duration)
                            });
                        }
                    }
                }
                catch
                {
                }

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
