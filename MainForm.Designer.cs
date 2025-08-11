namespace QueryMasterTester
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtAddress = new TextBox();
            btnSearch = new Button();
            btnCancel = new Button();
            lblStatus = new Label();
            lnkHelp = new LinkLabel();
            lnkGithub = new LinkLabel();
            gridPlayers = new DataGridView();
            colPlayer = new DataGridViewTextBoxColumn();
            colScore = new DataGridViewTextBoxColumn();
            colDuration = new DataGridViewTextBoxColumn();
            tabControl = new TabControl();
            tabInfo = new TabPage();
            gridInfo = new DataGridView();
            colInfoKey = new DataGridViewTextBoxColumn();
            colInfoValue = new DataGridViewTextBoxColumn();
            tabPlayers = new TabPage();
            tabRules = new TabPage();
            gridRules = new DataGridView();
            colRuleKey = new DataGridViewTextBoxColumn();
            colRuleValue = new DataGridViewTextBoxColumn();
            colRuleChange = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridPlayers).BeginInit();
            tabControl.SuspendLayout();
            tabInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridInfo).BeginInit();
            tabPlayers.SuspendLayout();
            tabRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRules).BeginInit();
            SuspendLayout();
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(12, 12);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "address:port (e.g., 127.0.0.1:27015)";
            txtAddress.Size = new Size(300, 23);
            txtAddress.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(318, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(399, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 46);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 15);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status:";
            // 
            // lnkHelp
            // 
            lnkHelp.AutoSize = true;
            lnkHelp.Location = new Point(480, 16);
            lnkHelp.Name = "lnkHelp";
            lnkHelp.Size = new Size(33, 15);
            lnkHelp.TabIndex = 12;
            lnkHelp.TabStop = true;
            lnkHelp.Text = "Help";
            lnkHelp.LinkClicked += lnkHelp_LinkClicked;
            // 
            // lnkGithub
            // 
            lnkGithub.AutoSize = true;
            lnkGithub.Location = new Point(530, 16);
            lnkGithub.Name = "lnkGithub";
            lnkGithub.Size = new Size(90, 15);
            lnkGithub.TabIndex = 13;
            lnkGithub.TabStop = true;
            lnkGithub.Text = "View on GitHub";
            lnkGithub.LinkClicked += lnkGithub_LinkClicked;
            // 
            // gridPlayers
            // 
            gridPlayers.AllowUserToAddRows = false;
            gridPlayers.AllowUserToDeleteRows = false;
            gridPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPlayers.Columns.AddRange(new DataGridViewColumn[] { colPlayer, colScore, colDuration });
            gridPlayers.Location = new Point(8, 6);
            gridPlayers.Name = "gridPlayers";
            gridPlayers.ReadOnly = true;
            gridPlayers.RowHeadersVisible = false;
            gridPlayers.Size = new Size(760, 329);
            gridPlayers.TabIndex = 9;
            // 
            // colPlayer
            // 
            colPlayer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPlayer.HeaderText = "Player";
            colPlayer.Name = "colPlayer";
            colPlayer.ReadOnly = true;
            // 
            // colScore
            // 
            colScore.HeaderText = "Score";
            colScore.Name = "colScore";
            colScore.ReadOnly = true;
            // 
            // colDuration
            // 
            colDuration.HeaderText = "Duration (s)";
            colDuration.Name = "colDuration";
            colDuration.ReadOnly = true;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabInfo);
            tabControl.Controls.Add(tabPlayers);
            tabControl.Controls.Add(tabRules);
            tabControl.Location = new Point(12, 72);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 366);
            tabControl.TabIndex = 10;
            // 
            // tabInfo
            // 
            tabInfo.Controls.Add(gridInfo);
            tabInfo.Location = new Point(4, 24);
            tabInfo.Name = "tabInfo";
            tabInfo.Padding = new Padding(3);
            tabInfo.Size = new Size(768, 338);
            tabInfo.TabIndex = 0;
            tabInfo.Text = "Info";
            tabInfo.UseVisualStyleBackColor = true;
            // 
            // gridInfo
            // 
            gridInfo.AllowUserToAddRows = false;
            gridInfo.AllowUserToDeleteRows = false;
            gridInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridInfo.Columns.AddRange(new DataGridViewColumn[] { colInfoKey, colInfoValue });
            gridInfo.Location = new Point(8, 6);
            gridInfo.Name = "gridInfo";
            gridInfo.ReadOnly = true;
            gridInfo.RowHeadersVisible = false;
            gridInfo.Size = new Size(752, 326);
            gridInfo.TabIndex = 10;
            // 
            // colInfoKey
            // 
            colInfoKey.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colInfoKey.HeaderText = "Field";
            colInfoKey.Name = "colInfoKey";
            colInfoKey.ReadOnly = true;
            colInfoKey.Width = 57;
            // 
            // colInfoValue
            // 
            colInfoValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colInfoValue.HeaderText = "Value";
            colInfoValue.Name = "colInfoValue";
            colInfoValue.ReadOnly = true;
            // 
            // tabPlayers
            // 
            tabPlayers.Controls.Add(gridPlayers);
            tabPlayers.Location = new Point(4, 24);
            tabPlayers.Name = "tabPlayers";
            tabPlayers.Padding = new Padding(3);
            tabPlayers.Size = new Size(768, 338);
            tabPlayers.TabIndex = 2;
            tabPlayers.Text = "Players";
            tabPlayers.UseVisualStyleBackColor = true;
            // 
            // tabRules
            // 
            tabRules.Controls.Add(gridRules);
            tabRules.Location = new Point(4, 24);
            tabRules.Name = "tabRules";
            tabRules.Padding = new Padding(3);
            tabRules.Size = new Size(768, 338);
            tabRules.TabIndex = 1;
            tabRules.Text = "Rules";
            tabRules.UseVisualStyleBackColor = true;
            // 
            // gridRules
            // 
            gridRules.AllowUserToAddRows = false;
            gridRules.AllowUserToDeleteRows = false;
            gridRules.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridRules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridRules.Columns.AddRange(new DataGridViewColumn[] { colRuleKey, colRuleValue, colRuleChange });
            gridRules.Location = new Point(9, 9);
            gridRules.Name = "gridRules";
            gridRules.ReadOnly = true;
            gridRules.RowHeadersVisible = false;
            gridRules.Size = new Size(753, 323);
            gridRules.TabIndex = 0;
            // 
            // colRuleKey
            // 
            colRuleKey.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colRuleKey.HeaderText = "Key";
            colRuleKey.Name = "colRuleKey";
            colRuleKey.ReadOnly = true;
            colRuleKey.Width = 51;
            // 
            // colRuleValue
            // 
            colRuleValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRuleValue.HeaderText = "Value";
            colRuleValue.Name = "colRuleValue";
            colRuleValue.ReadOnly = true;
            // 
            // colRuleChange
            // 
            colRuleChange.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colRuleChange.HeaderText = "Change";
            colRuleChange.Name = "colRuleChange";
            colRuleChange.ReadOnly = true;
            colRuleChange.Width = 73;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            Controls.Add(lblStatus);
            Controls.Add(btnSearch);
            Controls.Add(lnkHelp);
            Controls.Add(btnCancel);
            Controls.Add(lnkGithub);
            Controls.Add(txtAddress);
            Name = "Form1";
            Text = "QueryMaster Tester - Server Query (Non-Commercial, Use at Your Own Risk)";
            ((System.ComponentModel.ISupportInitialize)gridPlayers).EndInit();
            tabControl.ResumeLayout(false);
            tabInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridInfo).EndInit();
            tabPlayers.ResumeLayout(false);
            tabRules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridRules).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.LinkLabel lnkHelp;
        private System.Windows.Forms.LinkLabel lnkGithub;
        private System.Windows.Forms.DataGridView gridPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabPlayers;
        private System.Windows.Forms.TabPage tabRules;
        private System.Windows.Forms.DataGridView gridRules;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuleKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuleValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuleChange;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView gridInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInfoKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInfoValue;
    }
}
