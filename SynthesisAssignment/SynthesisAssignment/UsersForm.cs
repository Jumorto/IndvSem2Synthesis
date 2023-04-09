using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer;
using Models;
using DataAccessLayer;

namespace SynthesisAssignment
{
    public partial class UsersForm : Form
    {
        UsersLogic logicU;
        User objUser;
        
        public UsersForm()
        {
            InitializeComponent();
            logicU = new UsersLogic(new UsersDAL(Properties.Settings.Default.ConnectionStringDB));
            objUser = new User();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxUserName == null || tbxUserEmail == null || tbxUserPassword == null)
            {
                MessageBox.Show("Enter the required fields!");
            }
            else
            {
                try
                {
                    if (new EmailAddressAttribute().IsValid(tbxUserEmail.Text))
                    {
                        objUser.Username = tbxUserName.Text;
                        objUser.Email = tbxUserEmail.Text;
                        objUser.Password = tbxUserPassword.Text;
                        objUser.Usertype = 1;
                        objUser = logicU.UpdateUser(objUser);

                        MessageBox.Show($"User {objUser.Username} saved!");
                    }
                    else
                    {
                        MessageBox.Show("Enter valid email!");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        private void tbxUserEmail_Leave(object sender, EventArgs e) 
        {
            bool newUser = true;
            try
            {
                objUser = logicU.GetUserByEmail(tbxUserEmail.Text);
                if (objUser != null && objUser.ID > 0)
                {
                    if (objUser.Usertype == 1) {  // staff
                        message.Text = "Update User";
                        tbxUserName.Text = objUser.Username;
                        tbxUserPassword.Text = objUser.Password;
                        newUser = false;
                    }
                    else
                    {
                        MessageBox.Show("Player with such email already created!");
                        tbxUserEmail.Text = "";
                    }
                }
               if(newUser)
                {
                    message.Text = "New User";
                    tbxUserName.Text = "";
                    tbxUserPassword.Text = "";
                    objUser = new User();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxUserName.Text = "";
            tbxUserEmail.Text = "";
            tbxUserPassword.Text = "";
            objUser = new User();
            message.Text = "New User";
        }
    }
}
