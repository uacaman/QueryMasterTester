namespace QueryMasterTester
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource? _cts;

        public MainForm()
        {
            InitializeComponent();
            btnCancel.Enabled = false;
            var toolTip = new ToolTip();
            toolTip.SetToolTip(txtAddress, "Enter server address and port in the format host:port, e.g. 127.0.0.1:27015");
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var addr = txtAddress.Text.Trim();
            if (string.IsNullOrWhiteSpace(addr))
            {
                MessageBox.Show("Enter address:port", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetBusyState(true);
            try
            {
                _cts?.Cancel();
                _cts?.Dispose();
                _cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                var ctsLocal = _cts;
                lblStatus.Text = "Status: querying...";
                gridPlayers.Rows.Clear();
                gridRules.Rows.Clear();
                gridInfo.Rows.Clear();

                var backend = rdoQueryMaster.Checked ? QueryBackend.QueryMaster : QueryBackend.OpenGSQ;
                var server = await QueryService.ProcessAsync(addr, appId: 0, backend);

                if (ctsLocal.IsCancellationRequested || _cts != ctsLocal)
                {
                    lblStatus.Text = "Status: canceled";
                    return;
                }

                if (!server.Online)
                {
                    lblStatus.Text = "Status: offline or no response";
                    return;
                }

                gridInfo.Rows.Add("Address", server.Addr);
                gridInfo.Rows.Add("Name", server.Name);
                gridInfo.Rows.Add("Map", server.Map);
                gridInfo.Rows.Add("Players", $"{server.Players}/{server.MaxPlayers}");
                gridInfo.Rows.Add("Bots", server.Bots);
                gridInfo.Rows.Add("VAC Secure", server.Secure ? "Yes" : "No");
                gridInfo.Rows.Add("Dedicated", server.Dedicated ? "Yes" : "No");
                gridInfo.Rows.Add("OS", server.Os);
                gridInfo.Rows.Add("Game Port", server.Gameport);
                gridInfo.Rows.Add("Online", server.Online ? "Yes" : "No");

                foreach (var p in server.PlayerList)
                {
                    gridPlayers.Rows.Add(p.Name, p.Score, p.DurationSeconds);
                }

                PopulateRulesGrid(server);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Status: error";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusyState(false);
            }
        }

        private void SetBusyState(bool busy)
        {
            btnSearch.Enabled = !busy;
            txtAddress.Enabled = !busy;
            btnCancel.Enabled = busy;
            UseWaitCursor = busy;
        }


        private void PopulateRulesGrid(Server server)
        {
            foreach (var kvp in server.Rules)
            {
                var key = kvp.Key;
                var value = kvp.Value;
                string change = "";
                if (server.PreviousRules.TryGetValue(key, out var prev))
                {
                    if (!string.Equals(prev, value, StringComparison.Ordinal))
                    {
                        change = $"Changed: '{prev}' → '{value}'";
                    }
                }
                else
                {
                    change = "New";
                }

                gridRules.Rows.Add(key, value, change);
            }

            foreach (var prev in server.PreviousRules)
            {
                if (!server.Rules.ContainsKey(prev.Key))
                {
                    gridRules.Rows.Add(prev.Key, "", "Removed");
                }
            }

            server.PreviousRules = new Dictionary<string, string>(server.Rules, StringComparer.OrdinalIgnoreCase);
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            try { _cts?.Cancel(); } catch { }
            lblStatus.Text = "Status: canceled";
            SetBusyState(false);
        }

        private void lnkHelp_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            var message = "How to use:\n\n" +
                          "1) Type address:port (example: 127.0.0.1:27015).\n" +
                          "2) Click Search to query the server.\n" +
                          "3) See Info, Players, and Rules on their tabs.\n" +
                          "4) Click Cancel to stop a long request.";
            MessageBox.Show(this, message, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lnkGithub_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var url = "https://github.com/uacaman/QueryMasterTester";
                using var ps = new System.Diagnostics.Process();
                ps.StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                ps.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Open URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
