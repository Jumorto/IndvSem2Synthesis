
namespace SynthesisAssignment
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.lblUserHello = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newTournamentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewCuTournaments = new System.Windows.Forms.DataGridView();
            this.lblTournaments = new System.Windows.Forms.Label();
            this.tbxSearchByName = new System.Windows.Forms.TextBox();
            this.btnSearchBy = new System.Windows.Forms.Button();
            this.tbxSearchByLocation = new System.Windows.Forms.TextBox();
            this.lblSearchByName = new System.Windows.Forms.Label();
            this.lblSearchByLocation = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCuTournaments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserHello
            // 
            this.lblUserHello.AutoSize = true;
            this.lblUserHello.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserHello.Location = new System.Drawing.Point(12, 55);
            this.lblUserHello.Name = "lblUserHello";
            this.lblUserHello.Size = new System.Drawing.Size(88, 21);
            this.lblUserHello.TabIndex = 0;
            this.lblUserHello.Text = "Username: ";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUsername.Location = new System.Drawing.Point(96, 55);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(25, 21);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = ".....";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTournamentToolStripMenuItem,
            this.userManagementToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1002, 29);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newTournamentToolStripMenuItem
            // 
            this.newTournamentToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newTournamentToolStripMenuItem.Name = "newTournamentToolStripMenuItem";
            this.newTournamentToolStripMenuItem.Size = new System.Drawing.Size(141, 25);
            this.newTournamentToolStripMenuItem.Text = "New Tournament";
            this.newTournamentToolStripMenuItem.Click += new System.EventHandler(this.newTournamentToolStripMenuItem_Click);
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(150, 25);
            this.userManagementToolStripMenuItem.Text = "User management";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // dataGridViewCuTournaments
            // 
            this.dataGridViewCuTournaments.AllowUserToAddRows = false;
            this.dataGridViewCuTournaments.AllowUserToDeleteRows = false;
            this.dataGridViewCuTournaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCuTournaments.Location = new System.Drawing.Point(13, 172);
            this.dataGridViewCuTournaments.Name = "dataGridViewCuTournaments";
            this.dataGridViewCuTournaments.RowTemplate.Height = 25;
            this.dataGridViewCuTournaments.Size = new System.Drawing.Size(978, 345);
            this.dataGridViewCuTournaments.TabIndex = 4;
            this.dataGridViewCuTournaments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCuTournaments_CellContentClick);
            // 
            // lblTournaments
            // 
            this.lblTournaments.AutoSize = true;
            this.lblTournaments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTournaments.Location = new System.Drawing.Point(13, 148);
            this.lblTournaments.Name = "lblTournaments";
            this.lblTournaments.Size = new System.Drawing.Size(107, 21);
            this.lblTournaments.TabIndex = 5;
            this.lblTournaments.Text = "Tournaments: ";
            // 
            // tbxSearchByName
            // 
            this.tbxSearchByName.Location = new System.Drawing.Point(759, 57);
            this.tbxSearchByName.Name = "tbxSearchByName";
            this.tbxSearchByName.Size = new System.Drawing.Size(231, 23);
            this.tbxSearchByName.TabIndex = 7;
            // 
            // btnSearchBy
            // 
            this.btnSearchBy.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchBy.Location = new System.Drawing.Point(759, 131);
            this.btnSearchBy.Name = "btnSearchBy";
            this.btnSearchBy.Size = new System.Drawing.Size(231, 35);
            this.btnSearchBy.TabIndex = 8;
            this.btnSearchBy.Text = "Search";
            this.btnSearchBy.UseVisualStyleBackColor = false;
            this.btnSearchBy.Click += new System.EventHandler(this.btnSearchBy_Click);
            // 
            // tbxSearchByLocation
            // 
            this.tbxSearchByLocation.Location = new System.Drawing.Point(760, 102);
            this.tbxSearchByLocation.Name = "tbxSearchByLocation";
            this.tbxSearchByLocation.Size = new System.Drawing.Size(231, 23);
            this.tbxSearchByLocation.TabIndex = 11;
            // 
            // lblSearchByName
            // 
            this.lblSearchByName.AutoSize = true;
            this.lblSearchByName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSearchByName.Location = new System.Drawing.Point(759, 33);
            this.lblSearchByName.Name = "lblSearchByName";
            this.lblSearchByName.Size = new System.Drawing.Size(142, 21);
            this.lblSearchByName.TabIndex = 12;
            this.lblSearchByName.Text = "Tournament Name:";
            // 
            // lblSearchByLocation
            // 
            this.lblSearchByLocation.AutoSize = true;
            this.lblSearchByLocation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSearchByLocation.Location = new System.Drawing.Point(759, 80);
            this.lblSearchByLocation.Name = "lblSearchByLocation";
            this.lblSearchByLocation.Size = new System.Drawing.Size(72, 21);
            this.lblSearchByLocation.TabIndex = 13;
            this.lblSearchByLocation.Text = "Location:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 529);
            this.Controls.Add(this.lblSearchByLocation);
            this.Controls.Add(this.lblSearchByName);
            this.Controls.Add(this.tbxSearchByLocation);
            this.Controls.Add(this.btnSearchBy);
            this.Controls.Add(this.tbxSearchByName);
            this.Controls.Add(this.lblTournaments);
            this.Controls.Add(this.dataGridViewCuTournaments);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblUserHello);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCuTournaments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserHello;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newTournamentToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewCuTournaments;
        private System.Windows.Forms.Label lblTournaments;
        private System.Windows.Forms.TextBox tbxSearchByName;
        private System.Windows.Forms.Button btnSearchBy;
        private System.Windows.Forms.TextBox tbxSearchByLocation;
        private System.Windows.Forms.Label lblSearchByName;
        private System.Windows.Forms.Label lblSearchByLocation;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
    }
}