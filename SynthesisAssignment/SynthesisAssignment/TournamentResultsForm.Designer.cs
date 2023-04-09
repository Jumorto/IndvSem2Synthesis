
namespace SynthesisAssignment
{
    partial class TournamentResultsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbTournamentName = new System.Windows.Forms.GroupBox();
            this.lblTournamentName = new System.Windows.Forms.Label();
            this.lblMatchesTable = new System.Windows.Forms.Label();
            this.dataGridViewMatches = new System.Windows.Forms.DataGridView();
            this.grbFinalResults = new System.Windows.Forms.GroupBox();
            this.bGenerateGoldSilverBronze = new System.Windows.Forms.Button();
            this.panelBronze = new System.Windows.Forms.Panel();
            this.lblBronzeWinner = new System.Windows.Forms.Label();
            this.panelSilver = new System.Windows.Forms.Panel();
            this.lblSilverWinner = new System.Windows.Forms.Label();
            this.panelGold = new System.Windows.Forms.Panel();
            this.lblGoldWinner = new System.Windows.Forms.Label();
            this.dataGridViewLeaderboard = new System.Windows.Forms.DataGridView();
            this.grbLeaderboard = new System.Windows.Forms.GroupBox();
            this.lblLeaderboard = new System.Windows.Forms.Label();
            this.grbTournamentName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatches)).BeginInit();
            this.grbFinalResults.SuspendLayout();
            this.panelBronze.SuspendLayout();
            this.panelSilver.SuspendLayout();
            this.panelGold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeaderboard)).BeginInit();
            this.grbLeaderboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbTournamentName
            // 
            this.grbTournamentName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grbTournamentName.Controls.Add(this.lblTournamentName);
            this.grbTournamentName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.grbTournamentName.Location = new System.Drawing.Point(13, 13);
            this.grbTournamentName.Name = "grbTournamentName";
            this.grbTournamentName.Size = new System.Drawing.Size(960, 82);
            this.grbTournamentName.TabIndex = 0;
            this.grbTournamentName.TabStop = false;
            this.grbTournamentName.Text = "Tournament";
            // 
            // lblTournamentName
            // 
            this.lblTournamentName.AutoSize = true;
            this.lblTournamentName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTournamentName.Location = new System.Drawing.Point(375, 19);
            this.lblTournamentName.Name = "lblTournamentName";
            this.lblTournamentName.Size = new System.Drawing.Size(172, 25);
            this.lblTournamentName.TabIndex = 0;
            this.lblTournamentName.Text = "Tournament Name";
            // 
            // lblMatchesTable
            // 
            this.lblMatchesTable.AutoSize = true;
            this.lblMatchesTable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMatchesTable.Location = new System.Drawing.Point(12, 278);
            this.lblMatchesTable.Name = "lblMatchesTable";
            this.lblMatchesTable.Size = new System.Drawing.Size(71, 21);
            this.lblMatchesTable.TabIndex = 7;
            this.lblMatchesTable.Text = "Matches:";
            // 
            // dataGridViewMatches
            // 
            this.dataGridViewMatches.AllowUserToAddRows = false;
            this.dataGridViewMatches.AllowUserToDeleteRows = false;
            this.dataGridViewMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatches.Location = new System.Drawing.Point(12, 302);
            this.dataGridViewMatches.Name = "dataGridViewMatches";
            this.dataGridViewMatches.RowTemplate.Height = 25;
            this.dataGridViewMatches.Size = new System.Drawing.Size(961, 345);
            this.dataGridViewMatches.TabIndex = 6;
            this.dataGridViewMatches.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMatches_CellContentClick);
            // 
            // grbFinalResults
            // 
            this.grbFinalResults.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grbFinalResults.Controls.Add(this.bGenerateGoldSilverBronze);
            this.grbFinalResults.Controls.Add(this.panelBronze);
            this.grbFinalResults.Controls.Add(this.panelSilver);
            this.grbFinalResults.Controls.Add(this.panelGold);
            this.grbFinalResults.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.grbFinalResults.Location = new System.Drawing.Point(13, 101);
            this.grbFinalResults.Name = "grbFinalResults";
            this.grbFinalResults.Size = new System.Drawing.Size(960, 174);
            this.grbFinalResults.TabIndex = 8;
            this.grbFinalResults.TabStop = false;
            this.grbFinalResults.Text = "Results";
            // 
            // bGenerateGoldSilverBronze
            // 
            this.bGenerateGoldSilverBronze.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bGenerateGoldSilverBronze.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bGenerateGoldSilverBronze.Location = new System.Drawing.Point(771, 125);
            this.bGenerateGoldSilverBronze.Name = "bGenerateGoldSilverBronze";
            this.bGenerateGoldSilverBronze.Size = new System.Drawing.Size(189, 43);
            this.bGenerateGoldSilverBronze.TabIndex = 3;
            this.bGenerateGoldSilverBronze.Text = "Get Top 3 players";
            this.bGenerateGoldSilverBronze.UseVisualStyleBackColor = false;
            this.bGenerateGoldSilverBronze.Click += new System.EventHandler(this.bGenerateGoldSilverBronze_Click);
            // 
            // panelBronze
            // 
            this.panelBronze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(127)))), ((int)(((byte)(50)))));
            this.panelBronze.Controls.Add(this.lblBronzeWinner);
            this.panelBronze.Location = new System.Drawing.Point(538, 83);
            this.panelBronze.Name = "panelBronze";
            this.panelBronze.Size = new System.Drawing.Size(131, 57);
            this.panelBronze.TabIndex = 2;
            // 
            // lblBronzeWinner
            // 
            this.lblBronzeWinner.AutoSize = true;
            this.lblBronzeWinner.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBronzeWinner.Location = new System.Drawing.Point(13, 17);
            this.lblBronzeWinner.Name = "lblBronzeWinner";
            this.lblBronzeWinner.Size = new System.Drawing.Size(62, 21);
            this.lblBronzeWinner.TabIndex = 2;
            this.lblBronzeWinner.Text = "Player3";
            // 
            // panelSilver
            // 
            this.panelSilver.BackColor = System.Drawing.Color.Silver;
            this.panelSilver.Controls.Add(this.lblSilverWinner);
            this.panelSilver.Location = new System.Drawing.Point(264, 64);
            this.panelSilver.Name = "panelSilver";
            this.panelSilver.Size = new System.Drawing.Size(131, 57);
            this.panelSilver.TabIndex = 1;
            // 
            // lblSilverWinner
            // 
            this.lblSilverWinner.AutoSize = true;
            this.lblSilverWinner.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSilverWinner.Location = new System.Drawing.Point(16, 19);
            this.lblSilverWinner.Name = "lblSilverWinner";
            this.lblSilverWinner.Size = new System.Drawing.Size(62, 21);
            this.lblSilverWinner.TabIndex = 3;
            this.lblSilverWinner.Text = "Player2";
            // 
            // panelGold
            // 
            this.panelGold.BackColor = System.Drawing.Color.Gold;
            this.panelGold.Controls.Add(this.lblGoldWinner);
            this.panelGold.Location = new System.Drawing.Point(401, 32);
            this.panelGold.Name = "panelGold";
            this.panelGold.Size = new System.Drawing.Size(131, 57);
            this.panelGold.TabIndex = 0;
            // 
            // lblGoldWinner
            // 
            this.lblGoldWinner.AutoSize = true;
            this.lblGoldWinner.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGoldWinner.Location = new System.Drawing.Point(17, 17);
            this.lblGoldWinner.Name = "lblGoldWinner";
            this.lblGoldWinner.Size = new System.Drawing.Size(62, 21);
            this.lblGoldWinner.TabIndex = 0;
            this.lblGoldWinner.Text = "Player1";
            // 
            // dataGridViewLeaderboard
            // 
            this.dataGridViewLeaderboard.AllowUserToAddRows = false;
            this.dataGridViewLeaderboard.AllowUserToDeleteRows = false;
            this.dataGridViewLeaderboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLeaderboard.Location = new System.Drawing.Point(979, 101);
            this.dataGridViewLeaderboard.Name = "dataGridViewLeaderboard";
            this.dataGridViewLeaderboard.RowTemplate.Height = 25;
            this.dataGridViewLeaderboard.Size = new System.Drawing.Size(296, 546);
            this.dataGridViewLeaderboard.TabIndex = 9;
            // 
            // grbLeaderboard
            // 
            this.grbLeaderboard.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grbLeaderboard.Controls.Add(this.lblLeaderboard);
            this.grbLeaderboard.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.grbLeaderboard.Location = new System.Drawing.Point(979, 14);
            this.grbLeaderboard.Name = "grbLeaderboard";
            this.grbLeaderboard.Size = new System.Drawing.Size(296, 81);
            this.grbLeaderboard.TabIndex = 1;
            this.grbLeaderboard.TabStop = false;
            // 
            // lblLeaderboard
            // 
            this.lblLeaderboard.AutoSize = true;
            this.lblLeaderboard.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLeaderboard.Location = new System.Drawing.Point(90, 29);
            this.lblLeaderboard.Name = "lblLeaderboard";
            this.lblLeaderboard.Size = new System.Drawing.Size(119, 25);
            this.lblLeaderboard.TabIndex = 0;
            this.lblLeaderboard.Text = "Leaderboard";
            // 
            // TournamentResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 659);
            this.Controls.Add(this.grbLeaderboard);
            this.Controls.Add(this.dataGridViewLeaderboard);
            this.Controls.Add(this.grbFinalResults);
            this.Controls.Add(this.lblMatchesTable);
            this.Controls.Add(this.dataGridViewMatches);
            this.Controls.Add(this.grbTournamentName);
            this.Name = "TournamentResultsForm";
            this.Text = "TournamentResultsForm";
            this.Activated += new System.EventHandler(this.TournamentResultsForm_Activated);
            this.grbTournamentName.ResumeLayout(false);
            this.grbTournamentName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatches)).EndInit();
            this.grbFinalResults.ResumeLayout(false);
            this.panelBronze.ResumeLayout(false);
            this.panelBronze.PerformLayout();
            this.panelSilver.ResumeLayout(false);
            this.panelSilver.PerformLayout();
            this.panelGold.ResumeLayout(false);
            this.panelGold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeaderboard)).EndInit();
            this.grbLeaderboard.ResumeLayout(false);
            this.grbLeaderboard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTournamentName;
        private System.Windows.Forms.Label lblTournamentName;
        private System.Windows.Forms.Label lblMatchesTable;
        private System.Windows.Forms.DataGridView dataGridViewMatches;
        private System.Windows.Forms.GroupBox grbFinalResults;
        private System.Windows.Forms.Panel panelBronze;
        private System.Windows.Forms.Label lblBronzeWinner;
        private System.Windows.Forms.Panel panelSilver;
        private System.Windows.Forms.Label lblSilverWinner;
        private System.Windows.Forms.Panel panelGold;
        private System.Windows.Forms.Label lblGoldWinner;
        private System.Windows.Forms.Button bGenerateGoldSilverBronze;
        private System.Windows.Forms.DataGridView dataGridViewLeaderboard;
        private System.Windows.Forms.GroupBox grbLeaderboard;
        private System.Windows.Forms.Label lblLeaderboard;
    }
}