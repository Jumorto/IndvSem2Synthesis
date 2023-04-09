using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using BusinessLogicLayer;
using DataAccessLayer;

namespace SynthesisAssignment
{
    public partial class LoginForm : Form
    {
        private UsersLogic logic;

        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            logic = new UsersLogic(new UsersDAL(Properties.Settings.Default.ConnectionStringDB));

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User cUser = logic.LoginUserCheck(tbxEmail.Text, tbxPassword.Text);
            if (cUser.ID == 0)
            {
                MessageBox.Show("Invalid user.");
            }
            else
            {
                if(cUser.Usertype == 1)
                {
                    Program.CurrentUser = cUser;
                    MainForm fr = new MainForm();
                    fr.StartPosition = FormStartPosition.CenterScreen;
                    fr.WindowState = FormWindowState.Normal;
                    this.Hide();
                    fr.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your account does not have permission \n to log in this application. Sorry!");
                }
                
            }
        }
    }
}
        