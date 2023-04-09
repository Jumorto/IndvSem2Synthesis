
namespace SynthesisAssignment
{
    partial class UsersForm
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
            this.grbxAddEditUser = new System.Windows.Forms.GroupBox();
            this.message = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tbxUserPassword = new System.Windows.Forms.TextBox();
            this.tbxUserEmail = new System.Windows.Forms.TextBox();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.grbxAddEditUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbxAddEditUser
            // 
            this.grbxAddEditUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grbxAddEditUser.Controls.Add(this.message);
            this.grbxAddEditUser.Controls.Add(this.btnClear);
            this.grbxAddEditUser.Controls.Add(this.btnSave);
            this.grbxAddEditUser.Controls.Add(this.lblUserPassword);
            this.grbxAddEditUser.Controls.Add(this.lblEmail);
            this.grbxAddEditUser.Controls.Add(this.lblUserName);
            this.grbxAddEditUser.Controls.Add(this.tbxUserPassword);
            this.grbxAddEditUser.Controls.Add(this.tbxUserEmail);
            this.grbxAddEditUser.Controls.Add(this.tbxUserName);
            this.grbxAddEditUser.Location = new System.Drawing.Point(12, 12);
            this.grbxAddEditUser.Name = "grbxAddEditUser";
            this.grbxAddEditUser.Size = new System.Drawing.Size(410, 586);
            this.grbxAddEditUser.TabIndex = 1;
            this.grbxAddEditUser.TabStop = false;
            this.grbxAddEditUser.Text = "Add/Edit Staff user";
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.message.ForeColor = System.Drawing.Color.Blue;
            this.message.Location = new System.Drawing.Point(55, 46);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(78, 21);
            this.message.TabIndex = 18;
            this.message.Text = "New User";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Crimson;
            this.btnClear.Location = new System.Drawing.Point(216, 229);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(138, 39);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear info";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LawnGreen;
            this.btnSave.Location = new System.Drawing.Point(55, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 39);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Location = new System.Drawing.Point(54, 177);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(63, 15);
            this.lblUserPassword.TabIndex = 7;
            this.lblUserPassword.Text = "Password: ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(55, 91);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 15);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email: ";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(55, 135);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(76, 15);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.Text = "User Names: ";
            // 
            // tbxUserPassword
            // 
            this.tbxUserPassword.Location = new System.Drawing.Point(135, 174);
            this.tbxUserPassword.Name = "tbxUserPassword";
            this.tbxUserPassword.PasswordChar = '*';
            this.tbxUserPassword.Size = new System.Drawing.Size(228, 23);
            this.tbxUserPassword.TabIndex = 2;
            // 
            // tbxUserEmail
            // 
            this.tbxUserEmail.Location = new System.Drawing.Point(135, 88);
            this.tbxUserEmail.Name = "tbxUserEmail";
            this.tbxUserEmail.Size = new System.Drawing.Size(228, 23);
            this.tbxUserEmail.TabIndex = 0;
            this.tbxUserEmail.Leave += new System.EventHandler(this.tbxUserEmail_Leave);
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(135, 132);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(228, 23);
            this.tbxUserName.TabIndex = 1;
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 610);
            this.Controls.Add(this.grbxAddEditUser);
            this.Name = "UsersForm";
            this.Text = "UsersForm";
            this.grbxAddEditUser.ResumeLayout(false);
            this.grbxAddEditUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbxAddEditUser;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUserPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbxUserPassword;
        private System.Windows.Forms.TextBox tbxUserEmail;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label message;
    }
}