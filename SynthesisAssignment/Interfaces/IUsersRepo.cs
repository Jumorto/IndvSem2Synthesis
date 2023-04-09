using Models;
using MySql.Data.MySqlClient;

namespace Interfaces
{
    public interface IUsersRepo
    {
        public User GetByID(int idUser);

        public User AddNewUser(User objUser);

        public User EditUser(User objUser);

        public User LoginUserCheck(string email, string password);

        public bool CheckForExistingUser(string email);

        public User GetUserByEmail(string email); 

        public int CreateNewUserWeb(string username, string email, string password);
    }
}
