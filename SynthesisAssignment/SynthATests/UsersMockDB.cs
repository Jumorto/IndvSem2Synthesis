using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Models;

namespace SynthATests
{
    public class UsersMockDB : IUsersRepo
    {
        List<User> mockDBUsers;
        public string ConnectionString { get; set; }

        public UsersMockDB()
        {
            mockDBUsers = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                User u = new User();
                u.ID = i;
                u.Usertype = 0;
                u.Username = "A" + i;
                u.Email = "A@A." + i;
                u.Password = "a" + i;

                mockDBUsers.Add(u);
            }
        }

        public void GiveConString(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public User GetByID(int idUser)
        {
            User srch = new User();
            foreach(User u in mockDBUsers)
            {
                if(u.ID == idUser)
                {
                    srch = u;
                    break;
                }
            }
            return srch;
        }

        public User AddNewUser(User objUser)
        {
            mockDBUsers.Add(objUser);
            return objUser;
        }

        public User EditUser(User objUser)
        {
            for(int i = 0; i < mockDBUsers.Count; i++)
            {
                if(objUser.ID == mockDBUsers[i].ID)
                {
                    mockDBUsers[i] = objUser;
                    break;
                }
            }
            return objUser;
        }

        public User LoginUserCheck(string email, string password)
        {
            User srch = new User();
            foreach (User u in mockDBUsers)
            {
                if (u.Email == email && u.Password == password)
                {
                    srch = u;
                    break;
                }
            }
            return srch;
        }

        public bool CheckForExistingUser(string email)
        {
            bool result = false;
            foreach (User u in mockDBUsers)
            {
                if (u.Email == email)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public int CreateNewUserWeb(string username, string email, string password)
        {
            User u = new User();
            u.ID = mockDBUsers.Count + 100;
            u.Usertype = 0;
            u.Username = username;
            u.Email = email;
            u.Password = password;            
            
            mockDBUsers.Add(u);
            return u.ID;
        }

        public User GetUserByEmail(string email)
        {
            User srch = new User();
            foreach (User u in mockDBUsers)
            {
                if (u.Email == email)
                {
                    srch = u;
                    break;
                }
            }
            return srch;
        }
    }
}
