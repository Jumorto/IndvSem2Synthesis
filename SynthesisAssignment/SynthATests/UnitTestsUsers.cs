using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Interfaces;

namespace SynthATests
{
    [TestClass]
    public class UnitTestsUsers
    {
        [TestMethod]
        public void TestGetByID()
        {
            IUsersRepo m = new UsersMockDB();
            User testUser = new User();
            User expectedUser = new User();
            testUser = m.GetByID(5);

            expectedUser.ID = 5;
            expectedUser.Usertype = 0;
            expectedUser.Username = "A5";
            expectedUser.Email = "A@A.5";
            expectedUser.Password = "a5";

            Assert.AreEqual(testUser.ID, expectedUser.ID);
        }

        [TestMethod]
        public void TestAddNewUser()
        {
            IUsersRepo m = new UsersMockDB();
            User newUser = new User();
            newUser.ID = 100;
            newUser.Usertype = 1;
            newUser.Username = "a100";
            newUser.Email = "a@a.a";
            newUser.Password = "a";

            User expectedUser = m.AddNewUser(newUser);

            Assert.AreEqual(expectedUser.ID, newUser.ID);

        }

        [TestMethod]
        public void TestEditUser()
        {
            IUsersRepo m = new UsersMockDB();
            User editUser = new User();
            editUser.ID = 1;
            editUser.Usertype = 1;
            editUser.Username = "a1";
            editUser.Email = "a@a.a";
            editUser.Password = "a";

            User expectedUser = m.EditUser(editUser);

            Assert.AreEqual(expectedUser.ID, editUser.ID);

        }

        [TestMethod]
        public void TestLoginCheckUser()
        {
            IUsersRepo m = new UsersMockDB();
            User testUser = new User();
            User expectedUser = new User();

            testUser = m.LoginUserCheck("A@A.5", "a5");

            expectedUser.ID = 5;
            expectedUser.Usertype = 0;
            expectedUser.Username = "A5";
            expectedUser.Email = "A@A.5";
            expectedUser.Password = "a5";

            Assert.AreEqual(testUser.ID, expectedUser.ID);
        }

        [TestMethod]
        public void TestCheckForExistingUser()
        {
            IUsersRepo m = new UsersMockDB();
            bool test = false;

            test = m.CheckForExistingUser("A@A.5");

            Assert.IsTrue(test);
        }        

        [TestMethod]
        public void TestCreateUserWeb()
        {
            IUsersRepo m = new UsersMockDB();
            int idexpected = 110;
            int actual = m.CreateNewUserWeb("a100", "a100@a.a", "100a");

            Assert.AreEqual(idexpected, actual);
        }

        [TestMethod]
        public void TestGetUserByEmail()
        {
            IUsersRepo m = new UsersMockDB();
            User newUser = new User();
            newUser.ID = 5;
            newUser.Usertype = 0;
            newUser.Username = "A5";
            newUser.Email = "A@A.5";
            newUser.Password = "a5";

            User expectedUser = m.GetUserByEmail(newUser.Email);

            Assert.AreEqual(expectedUser.ID, newUser.ID);
        }
    }
}
