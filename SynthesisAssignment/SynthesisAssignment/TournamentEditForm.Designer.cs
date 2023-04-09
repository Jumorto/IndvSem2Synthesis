
namespace SynthesisAssignment
{
    partial class TournamentEditForm
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
            this.grbTournament = new System.Windows.Forms.GroupBox();
            this.lblTournamentNameShow = new System.Windows.Forms.Label();
            this.lblTournamentName = new System.Windows.Forms.Label();
            this.grbTournamentDetails = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirmTournament = new System.Windows.Forms.Button();
            this.lblRegisterDeadline = new System.Windows.Forms.Label();
            this.dateTimePickerRegisterDeadline = new System.Windows.Forms.DateTimePicker();
            this.tbxMaxPlayersTournament = new System.Windows.Forms.TextBox();
            this.lblMaxPlayerTournament = new System.Windows.Forms.Label();
            this.tbxMinPlayersTournament = new System.Windows.Forms.TextBox();
            this.lblMinPlayersTournament = new System.Windows.Forms.Label();
            this.tbxLocationTournament = new System.Windows.Forms.TextBox();
            this.lblLocationTournament = new System.Windows.Forms.Label();
            this.lblEndTournament = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dateTimePickerEndTournament = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartTournament = new System.Windows.Forms.DateTimePicker();
            this.lblInfoLabel = new System.Windows.Forms.Label();
            this.richtbxTournamentInfo = new System.Windows.Forms.RichTextBox();
            this.tbxTournamentName = new System.Windows.Forms.TextBox();
            this.lblTNameLabel = new System.Windows.Forms.Label();
            this.grpbGeneratePlayerMatches = new System.Windows.Forms.GroupBox();
            this.lblMaxPlayersReg = new System.Windows.Forms.Label();
            this.lblDASH = new System.Windows.Forms.Label();
            this.lblPlayersRegisteredCount = new System.Windows.Forms.Label();
            this.btnGenerateMatches = new System.Windows.Forms.Button();
            this.lblPlayersRegister = new System.Windows.Forms.Label();
            this.grbTournament.SuspendLayout();
            this.grbTournamentDetails.SuspendLayout();
            this.grpbGeneratePlayerMatches.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbTournament
            // 
            this.grbTournament.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grbTournament.Controls.Add(this.lblTournamentNameShow);
            this.grbTournament.Controls.Add(this.lblTournamentName);
            this.grbTournament.Location = new System.Drawing.Point(13, 13);
            this.grbTournament.Name = "grbTournament";
            this.grbTournament.Size = new System.Drawing.Size(354, 65);
            this.grbTournament.TabIndex = 0;
            this.grbTournament.TabStop = false;
            this.grbTournament.Text = "Tournament";
            // 
            // lblTournamentNameShow
            // 
            this.lblTournamentNameShow.AutoSize = true;
            this.lblTournamentNameShow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTournamentNameShow.Location = new System.Drawing.Point(77, 23);
            this.lblTournamentNameShow.Name = "lblTournamentNameShow";
            this.lblTournamentNameShow.Size = new System.Drawing.Size(25, 21);
            this.lblTournamentNameShow.TabIndex = 1;
            this.lblTournamentNameShow.Text = ".....";
            // 
            // lblTournamentName
            // 
            this.lblTournamentName.AutoSize = true;
            this.lblTournamentName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTournamentName.Location = new System.Drawing.Point(16, 23);
            this.lblTournamentName.Name = "lblTournamentName";
            this.lblTournamentName.Size = new System.Drawing.Size(55, 21);
            this.lblTournamentName.TabIndex = 0;
            this.lblTournamentName.Text = "Name:";
            // 
            // grbTournamentDetails
            // 
            this.grbTournamentDetails.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grbTournamentDetails.Controls.Add(this.btnCancel);
            this.grbTournamentDetails.Controls.Add(this.btnConfirmTournament);
            this.grbTournamentDetails.Controls.Add(this.lblRegisterDeadline);
            this.grbTournamentDetails.Controls.Add(this.dateTimePickerRegisterDeadline);
            this.grbTournamentDetails.Controls.Add(this.tbxMaxPlayersTournament);
            this.grbTournamentDetails.Controls.Add(this.lblMaxPlayerTournament);
            this.grbTournamentDetails.Controls.Add(this.tbxMinPlayersTournament);
            this.grbTournamentDetails.Controls.Add(this.lblMinPlayersTournament);
            this.grbTournamentDetails.Controls.Add(this.tbxLocationTournament);
            this.grbTournamentDetails.Controls.Add(this.lblLocationTournament);
            this.grbTournamentDetails.Controls.Add(this.lblEndTournament);
            this.grbTournamentDetails.Controls.Add(this.lblStartDate);
            this.grbTournamentDetails.Controls.Add(this.dateTimePickerEndTournament);
            this.grbTournamentDetails.Controls.Add(this.dateTimePickerStartTournament);
            this.grbTournamentDetails.Controls.Add(this.lblInfoLabel);
            this.grbTournamentDetails.Controls.Add(this.richtbxTournamentInfo);
            this.grbTournamentDetails.Controls.Add(this.tbxTournamentName);
            this.grbTournamentDetails.Controls.Add(this.lblTNameLabel);
            this.grbTournamentDetails.Location = new System.Drawing.Point(12, 84);
            this.grbTournamentDetails.Name = "grbTournamentDetails";
            this.grbTournamentDetails.Size = new System.Drawing.Size(444, 614);
            this.grbTournamentDetails.TabIndex = 2;
            this.grbTournamentDetails.TabStop = false;
            this.grbTournamentDetails.Text = "Details";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.Location = new System.Drawing.Point(340, 563);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 45);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirmTournament
            // 
            this.btnConfirmTournament.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfirmTournament.Location = new System.Drawing.Point(24, 563);
            this.btnConfirmTournament.Name = "btnConfirmTournament";
            this.btnConfirmTournament.Size = new System.Drawing.Size(166, 45);
            this.btnConfirmTournament.TabIndex = 14;
            this.btnConfirmTournament.Text = "Confirm";
            this.btnConfirmTournament.UseVisualStyleBackColor = false;
            this.btnConfirmTournament.Click += new System.EventHandler(this.btnConfirmTournament_Click);
            // 
            // lblRegisterDeadline
            // 
            this.lblRegisterDeadline.AutoSize = true;
            this.lblRegisterDeadline.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRegisterDeadline.Location = new System.Drawing.Point(24, 446);
            this.lblRegisterDeadline.Name = "lblRegisterDeadline";
            this.lblRegisterDeadline.Size = new System.Drawing.Size(133, 21);
            this.lblRegisterDeadline.TabIndex = 6;
            this.lblRegisterDeadline.Text = "Register deadline:";
            // 
            // dateTimePickerRegisterDeadline
            // 
            this.dateTimePickerRegisterDeadline.Location = new System.Drawing.Point(163, 445);
            this.dateTimePickerRegisterDeadline.Name = "dateTimePickerRegisterDeadline";
            this.dateTimePickerRegisterDeadline.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerRegisterDeadline.TabIndex = 4;
            // 
            // tbxMaxPlayersTournament
            // 
            this.tbxMaxPlayersTournament.Location = new System.Drawing.Point(226, 521);
            this.tbxMaxPlayersTournament.Name = "tbxMaxPlayersTournament";
            this.tbxMaxPlayersTournament.Size = new System.Drawing.Size(52, 23);
            this.tbxMaxPlayersTournament.TabIndex = 13;
            // 
            // lblMaxPlayerTournament
            // 
            this.lblMaxPlayerTournament.AutoSize = true;
            this.lblMaxPlayerTournament.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMaxPlayerTournament.Location = new System.Drawing.Point(24, 519);
            this.lblMaxPlayerTournament.Name = "lblMaxPlayerTournament";
            this.lblMaxPlayerTournament.Size = new System.Drawing.Size(200, 21);
            this.lblMaxPlayerTournament.TabIndex = 12;
            this.lblMaxPlayerTournament.Text = "Maximum players required:";
            // 
            // tbxMinPlayersTournament
            // 
            this.tbxMinPlayersTournament.Location = new System.Drawing.Point(226, 485);
            this.tbxMinPlayersTournament.Name = "tbxMinPlayersTournament";
            this.tbxMinPlayersTournament.Size = new System.Drawing.Size(52, 23);
            this.tbxMinPlayersTournament.TabIndex = 11;
            // 
            // lblMinPlayersTournament
            // 
            this.lblMinPlayersTournament.AutoSize = true;
            this.lblMinPlayersTournament.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMinPlayersTournament.Location = new System.Drawing.Point(24, 483);
            this.lblMinPlayersTournament.Name = "lblMinPlayersTournament";
            this.lblMinPlayersTournament.Size = new System.Drawing.Size(198, 21);
            this.lblMinPlayersTournament.TabIndex = 10;
            this.lblMinPlayersTournament.Text = "Minimum players required:";
            // 
            // tbxLocationTournament
            // 
            this.tbxLocationTournament.Location = new System.Drawing.Point(24, 390);
            this.tbxLocationTournament.Name = "tbxLocationTournament";
            this.tbxLocationTournament.Size = new System.Drawing.Size(254, 23);
            this.tbxLocationTournament.TabIndex = 9;
            // 
            // lblLocationTournament
            // 
            this.lblLocationTournament.AutoSize = true;
            this.lblLocationTournament.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLocationTournament.Location = new System.Drawing.Point(24, 366);
            this.lblLocationTournament.Name = "lblLocationTournament";
            this.lblLocationTournament.Size = new System.Drawing.Size(72, 21);
            this.lblLocationTournament.TabIndex = 8;
            this.lblLocationTournament.Text = "Location:";
            // 
            // lblEndTournament
            // 
            this.lblEndTournament.AutoSize = true;
            this.lblEndTournament.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEndTournament.Location = new System.Drawing.Point(24, 336);
            this.lblEndTournament.Name = "lblEndTournament";
            this.lblEndTournament.Size = new System.Drawing.Size(73, 21);
            this.lblEndTournament.TabIndex = 7;
            this.lblEndTournament.Text = "End date:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStartDate.Location = new System.Drawing.Point(24, 307);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(79, 21);
            this.lblStartDate.TabIndex = 6;
            this.lblStartDate.Text = "Start date:";
            // 
            // dateTimePickerEndTournament
            // 
            this.dateTimePickerEndTournament.Location = new System.Drawing.Point(120, 334);
            this.dateTimePickerEndTournament.Name = "dateTimePickerEndTournament";
            this.dateTimePickerEndTournament.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerEndTournament.TabIndex = 5;
            // 
            // dateTimePickerStartTournament
            // 
            this.dateTimePickerStartTournament.Location = new System.Drawing.Point(120, 305);
            this.dateTimePickerStartTournament.Name = "dateTimePickerStartTournament";
            this.dateTimePickerStartTournament.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerStartTournament.TabIndex = 4;
            // 
            // lblInfoLabel
            // 
            this.lblInfoLabel.AutoSize = true;
            this.lblInfoLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfoLabel.Location = new System.Drawing.Point(24, 81);
            this.lblInfoLabel.Name = "lblInfoLabel";
            this.lblInfoLabel.Size = new System.Drawing.Size(95, 21);
            this.lblInfoLabel.TabIndex = 3;
            this.lblInfoLabel.Text = "Information:";
            // 
            // richtbxTournamentInfo
            // 
            this.richtbxTournamentInfo.Location = new System.Drawing.Point(24, 105);
            this.richtbxTournamentInfo.Name = "richtbxTournamentInfo";
            this.richtbxTournamentInfo.Size = new System.Drawing.Size(393, 180);
            this.richtbxTournamentInfo.TabIndex = 2;
            this.richtbxTournamentInfo.Text = "";
            // 
            // tbxTournamentName
            // 
            this.tbxTournamentName.Location = new System.Drawing.Point(24, 43);
            this.tbxTournamentName.Name = "tbxTournamentName";
            this.tbxTournamentName.Size = new System.Drawing.Size(254, 23);
            this.tbxTournamentName.TabIndex = 1;
            // 
            // lblTNameLabel
            // 
            this.lblTNameLabel.AutoSize = true;
            this.lblTNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTNameLabel.Location = new System.Drawing.Point(24, 19);
            this.lblTNameLabel.Name = "lblTNameLabel";
            this.lblTNameLabel.Size = new System.Drawing.Size(55, 21);
            this.lblTNameLabel.TabIndex = 0;
            this.lblTNameLabel.Text = "Name:";
            // 
            // grpbGeneratePlayerMatches
            // 
            this.grpbGeneratePlayerMatches.BackColor = System.Drawing.Color.PapayaWhip;
            this.grpbGeneratePlayerMatches.Controls.Add(this.lblMaxPlayersReg);
            this.grpbGeneratePlayerMatches.Controls.Add(this.lblDASH);
            this.grpbGeneratePlayerMatches.Controls.Add(this.lblPlayersRegisteredCount);
            this.grpbGeneratePlayerMatches.Controls.Add(this.btnGenerateMatches);
            this.grpbGeneratePlayerMatches.Controls.Add(this.lblPlayersRegister);
            this.grpbGeneratePlayerMatches.Location = new System.Drawing.Point(462, 84);
            this.grpbGeneratePlayerMatches.Name = "grpbGeneratePlayerMatches";
            this.grpbGeneratePlayerMatches.Size = new System.Drawing.Size(444, 246);
            this.grpbGeneratePlayerMatches.TabIndex = 16;
            this.grpbGeneratePlayerMatches.TabStop = false;
            this.grpbGeneratePlayerMatches.Text = "Player matches management";
            // 
            // lblMaxPlayersReg
            // 
            this.lblMaxPlayersReg.AutoSize = true;
            this.lblMaxPlayersReg.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMaxPlayersReg.Location = new System.Drawing.Point(244, 81);
            this.lblMaxPlayersReg.Name = "lblMaxPlayersReg";
            this.lblMaxPlayersReg.Size = new System.Drawing.Size(22, 21);
            this.lblMaxPlayersReg.TabIndex = 17;
            this.lblMaxPlayersReg.Text = "....";
            // 
            // lblDASH
            // 
            this.lblDASH.AutoSize = true;
            this.lblDASH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDASH.Location = new System.Drawing.Point(222, 81);
            this.lblDASH.Name = "lblDASH";
            this.lblDASH.Size = new System.Drawing.Size(16, 21);
            this.lblDASH.TabIndex = 16;
            this.lblDASH.Text = "/";
            // 
            // lblPlayersRegisteredCount
            // 
            this.lblPlayersRegisteredCount.AutoSize = true;
            this.lblPlayersRegisteredCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayersRegisteredCount.Location = new System.Drawing.Point(194, 81);
            this.lblPlayersRegisteredCount.Name = "lblPlayersRegisteredCount";
            this.lblPlayersRegisteredCount.Size = new System.Drawing.Size(22, 21);
            this.lblPlayersRegisteredCount.TabIndex = 15;
            this.lblPlayersRegisteredCount.Text = "....";
            // 
            // btnGenerateMatches
            // 
            this.btnGenerateMatches.BackColor = System.Drawing.Color.Cyan;
            this.btnGenerateMatches.Location = new System.Drawing.Point(120, 152);
            this.btnGenerateMatches.Name = "btnGenerateMatches";
            this.btnGenerateMatches.Size = new System.Drawing.Size(166, 45);
            this.btnGenerateMatches.TabIndex = 14;
            this.btnGenerateMatches.Text = "Generate Match Schedule";
            this.btnGenerateMatches.UseVisualStyleBackColor = false;
            this.btnGenerateMatches.Click += new System.EventHandler(this.btnGenerateMatches_Click);
            // 
            // lblPlayersRegister
            // 
            this.lblPlayersRegister.AutoSize = true;
            this.lblPlayersRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayersRegister.Location = new System.Drawing.Point(47, 81);
            this.lblPlayersRegister.Name = "lblPlayersRegister";
            this.lblPlayersRegister.Size = new System.Drawing.Size(141, 21);
            this.lblPlayersRegister.TabIndex = 0;
            this.lblPlayersRegister.Text = "Players registered: ";
            // 
            // TournamentEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 710);
            this.Controls.Add(this.grpbGeneratePlayerMatches);
            this.Controls.Add(this.grbTournamentDetails);
            this.Controls.Add(this.grbTournament);
            this.Name = "TournamentEditForm";
            this.Text = "Edit Tournament";
            this.grbTournament.ResumeLayout(false);
            this.grbTournament.PerformLayout();
            this.grbTournamentDetails.ResumeLayout(false);
            this.grbTournamentDetails.PerformLayout();
            this.grpbGeneratePlayerMatches.ResumeLayout(false);
            this.grpbGeneratePlayerMatches.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTournament;
        private System.Windows.Forms.Label lblTournamentNameShow;
        private System.Windows.Forms.Label lblTournamentName;
        private System.Windows.Forms.GroupBox grbTournamentDetails;
        private System.Windows.Forms.Label lblEndTournament;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTournament;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTournament;
        private System.Windows.Forms.Label lblInfoLabel;
        private System.Windows.Forms.RichTextBox richtbxTournamentInfo;
        private System.Windows.Forms.TextBox tbxTournamentName;
        private System.Windows.Forms.Label lblTNameLabel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirmTournament;
        private System.Windows.Forms.TextBox tbxMaxPlayersTournament;
        private System.Windows.Forms.Label lblMaxPlayerTournament;
        private System.Windows.Forms.TextBox tbxMinPlayersTournament;
        private System.Windows.Forms.Label lblMinPlayersTournament;
        private System.Windows.Forms.TextBox tbxLocationTournament;
        private System.Windows.Forms.Label lblLocationTournament;
        private System.Windows.Forms.Label lblRegisterDeadline;
        private System.Windows.Forms.DateTimePicker dateTimePickerRegisterDeadline;
        private System.Windows.Forms.GroupBox grpbGeneratePlayerMatches;
        private System.Windows.Forms.Label lblPlayersRegisteredCount;
        private System.Windows.Forms.Button btnGenerateMatches;
        private System.Windows.Forms.Label lblPlayersRegister;
        private System.Windows.Forms.Label lblMaxPlayersReg;
        private System.Windows.Forms.Label lblDASH;
    }
}