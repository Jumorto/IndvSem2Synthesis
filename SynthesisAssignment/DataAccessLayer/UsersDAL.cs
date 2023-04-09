using MySql.Data.MySqlClient;
using Models;
using Interfaces;
using System;
using System.Text;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class UsersDAL : IUsersRepo
    {
        public string ConnectionString { get; set; }

        public UsersDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public User GetByID(int idUser)
        {
            User fUser = new User();
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    String query = "SELECT id, name, email, password, usertype " +
                                   " FROM synuser " +
                                   " WHERE id = @Id; ";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@Id", idUser);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fUser.ID = Convert.ToInt32(reader["id"]);
                            fUser.Username = reader["name"].ToString();
                            fUser.Email = reader["email"].ToString();
                            fUser.Password = Base64Decode(reader["password"].ToString());
                            fUser.Usertype = Convert.ToInt32(reader["usertype"]);
                        }
                    }

                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (myconnection != null)
                    {
                        myconnection.Close();
                    }
                }
            }

            return fUser;
        }

        public User AddNewUser(User objUser)
        {
            MySqlTransaction mytransaction = null;
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    //new user
                    StringBuilder query = new StringBuilder();
                    query.Append(" INSERT INTO synuser ");
                    query.Append(" (usertype, name, email, password) VALUES ");
                    query.Append(" (@Type, @Name, @Email, @Password)");

                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();

                    objUser.ID = ExecUpdInsCmdUser(query.ToString(), objUser, mytransaction, myconnection);

                    mytransaction.Commit();
                }
                catch (MySqlException ex)
                {
                    if (mytransaction != null)
                    {
                        mytransaction.Rollback();
                    }
                    throw ex;
                }
                catch (Exception ex)
                {
                    if (mytransaction != null)
                    {
                        mytransaction.Rollback();
                    }
                    throw ex;
                }
                finally
                {
                    if (myconnection != null)
                    {
                        myconnection.Close();
                    }
                }
            }

            return objUser;
        }

        public User EditUser(User objUser)
        {
            using (MySqlConnection myconnection = GetConnection())
            {
                MySqlTransaction mytransaction = null;

                try
                {
                    myconnection.Open();
                    StringBuilder query = new StringBuilder();
                    query.Append(" UPDATE synuser SET ");
                    query.Append(" name =  @Name,");
                    query.Append(" email = @Email, ");
                    query.Append(" password = @Password, ");
                    query.Append(" usertype = @Type ");
                    query.Append(" WHERE id = @IdUser;");

                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();

                    ExecUpdInsCmdUser(query.ToString(), objUser, mytransaction, myconnection);

                    mytransaction.Commit();
                }
                catch (MySqlException ex)
                {
                    if (mytransaction != null)
                    {
                        mytransaction.Rollback();
                    }
                    throw ex;
                }
                catch (Exception ex)
                {
                    if (mytransaction != null)
                    {
                        mytransaction.Rollback();
                    }
                    throw ex;
                }
                finally
                {
                    if (myconnection != null)
                    {
                        myconnection.Close();
                    }
                }
            }
            return objUser;
        }

        public User LoginUserCheck(string email, string password)
        {
            string pass64Encode = Base64Encode(password);
            User loggedUser = new User();
            String query = "SELECT * FROM synuser WHERE email = @Email and password = @Password;";

            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    MySqlCommand command = new MySqlCommand(query.ToString(), myconnection);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", pass64Encode);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            loggedUser.ID = Convert.ToInt32(reader["id"]);
                            loggedUser.Usertype = Convert.ToInt32(reader["usertype"]);
                            loggedUser.Username = reader["name"].ToString();
                            loggedUser.Email = reader["email"].ToString();
                            loggedUser.Password = Base64Decode(reader["password"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (myconnection != null)
                    {
                        myconnection.Close();
                    }
                }
            }
            return loggedUser;
        }

        public bool CheckForExistingUser(string email)
        {
            bool exists = false;
            String query = "SELECT id FROM synuser WHERE email = @Email;";
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@Email", email);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exists = true;
                        }
                    }
                    return exists;
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (myconnection != null)
                    {
                        myconnection.Close();
                    }
                }
            }
        }

        public User GetUserByEmail(string email)
        {
            User fUser = new User();
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    String query = "SELECT id, name, email, password, usertype " +
                                   " FROM synuser " +
                                   " WHERE email = @Email;";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@Email", email);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fUser.ID = Convert.ToInt32(reader["id"]);
                            fUser.Username = reader["name"].ToString();
                            fUser.Email = reader["email"].ToString();
                            fUser.Password = Base64Decode(reader["password"].ToString());
                            fUser.Usertype = Convert.ToInt32(reader["usertype"]);
                        }
                    }

                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (myconnection != null)
                    {
                        myconnection.Close();
                    }
                }
            }
            return fUser;
        }

        private int ExecUpdInsCmdUser(String query, User objUser, MySqlTransaction mytransaction, MySqlConnection myconnection)
        {
            string pass64Encode = Base64Encode(objUser.Password);
            MySqlCommand command = new MySqlCommand(query, myconnection);
            command.Parameters.AddWithValue("@IdUser", objUser.ID);
            command.Parameters.AddWithValue("@Name", objUser.Username);
            command.Parameters.AddWithValue("@Email", objUser.Email);
            command.Parameters.AddWithValue("@Password", pass64Encode);
            command.Parameters.AddWithValue("@Type", objUser.Usertype);

            command.Transaction = mytransaction;
            command.ExecuteNonQuery();

            return int.Parse(command.LastInsertedId.ToString());
        }

        public int CreateNewUserWeb(string username, string email, string password)
        {
            string pass64Encode = Base64Encode(password);
            int userId = 0;
            using (MySqlConnection myconnection = GetConnection())
            {
                MySqlTransaction mytransaction = null;
                try
                {
                    myconnection.Open();
                    mytransaction = myconnection.BeginTransaction();
                    String query = "INSERT INTO synuser " +
                                    "(name, email, password, usertype) VALUES " +
                                    " (@Name, @Email, @Password, 0);";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@Name", username);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", pass64Encode);

                    command.Transaction = mytransaction;
                    command.ExecuteNonQuery();

                    mytransaction.Commit();
                    userId = int.Parse(command.LastInsertedId.ToString());
                }
                catch (Exception ex)
                {
                    if (mytransaction != null)
                    {
                        mytransaction.Rollback();
                    }
                    throw ex;
                }
                finally
                {
                    if (myconnection != null)
                    {
                        myconnection.Close();
                    }
                }
            }
            return userId;
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
