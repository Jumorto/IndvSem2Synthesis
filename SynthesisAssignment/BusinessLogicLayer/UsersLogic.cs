using System;
using Models;
using Interfaces;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UsersLogic
    {
        IUsersRepo context;

        public UsersLogic(IUsersRepo context)
        {
            this.context = context;
        }

        public User GetByID(int idUser)
        {
            return context.GetByID(idUser);
        }

        public User LoginUserCheck(string email, string password)
        {
            return context.LoginUserCheck(email, password);
        }

        public bool CheckForExistingUser(string email)
        {
            return context.CheckForExistingUser(email);
        }

        public User UpdateUser(User u)
        {
            User updateUser = new User();
            if (u.ID != 0)
            {
                updateUser = context.EditUser(u);
            }
            else
            {
                updateUser = context.AddNewUser(u);
            }
            return updateUser;
        }

        public User GetUserByEmail(string email)
        {
            return context.GetUserByEmail(email);
        }

        //for web
        public int CreateNewUserWeb(string username, string email, string password)
        {
            return context.CreateNewUserWeb(username, email, password);
        }        
    }
}
