using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Interfaces;

namespace DataAccessLayer
{
    public class GameDAL : IGameRepo
    {
        public string ConnectionString { get; set; }

        public GameDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public Game GetByID(int idGame)
        {
            Game findGame = new Game();
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    String query = "SELECT id, idmatch, result_player1, result_player2, id_winner " +
                                   " FROM syngame " +
                                   " WHERE id = @Id; ";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@Id", idGame);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            findGame.ID = Convert.ToInt32(reader["id"]);
                            findGame.IDMatch = Convert.ToInt32(reader["idmatch"]);
                            findGame.ResultPlayer1 = Convert.ToInt32(reader["result_player1"]);
                            findGame.ResultPlayer2 = Convert.ToInt32(reader["result_player2"]);
                            findGame.IDWinner = Convert.ToInt32(reader["id_winner"]);
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

            return findGame;
        }

        public List<Game> GetByMatchID(int idMatch)
        {
            List<Game> gamesInMatch = new List<Game>();
            Game findGame = new Game();
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    String query = "SELECT id, idmatch, result_player1, result_player2, id_winner " +
                                   " FROM syngame " +
                                   " WHERE idmatch = @IdMatch; ";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@IdMatch", idMatch);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gamesInMatch.Add(new Game
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                IDMatch = Convert.ToInt32(reader["idmatch"]),
                                ResultPlayer1 = Convert.ToInt32(reader["result_player1"]),
                                ResultPlayer2 = Convert.ToInt32(reader["result_player2"]),
                                IDWinner = Convert.ToInt32(reader["id_winner"])
                            });

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

            return gamesInMatch;
        }

        private int ExecUpdInsCmdGame(String query, Game objGame, int idMatch, MySqlTransaction mytransaction, MySqlConnection myconnection)
        {
            MySqlCommand command = new MySqlCommand(query, myconnection);
            command.Parameters.AddWithValue("@IdGame", objGame.ID);
            command.Parameters.AddWithValue("@IdMatch", idMatch);
            command.Parameters.AddWithValue("@RP1", objGame.ResultPlayer1);
            command.Parameters.AddWithValue("@RP2", objGame.ResultPlayer2);
            command.Parameters.AddWithValue("@IdWinner", objGame.IDWinner);

            command.Transaction = mytransaction;
            command.ExecuteNonQuery();

            return int.Parse(command.LastInsertedId.ToString());
        }

        public Game AddGame(Game ng, int idMatch)
        {

            MySqlTransaction mytransaction = null;
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    //new game
                    StringBuilder query = new StringBuilder();
                    query.Append(" INSERT INTO syngame ");
                    query.Append(" (idmatch, result_player1, result_player2, id_winner) VALUES ");
                    query.Append(" (@IdMatch, @RP1, @RP2, @IdWinner)");

                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();

                    ng.ID = ExecUpdInsCmdGame(query.ToString(), ng, idMatch, mytransaction, myconnection);

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
            return ng;
        }

        public Game EditGame(Game ng, int idMatch)
        {
            using (MySqlConnection myconnection = GetConnection())
            {
                MySqlTransaction mytransaction = null;

                try
                {
                    myconnection.Open();
                    StringBuilder query = new StringBuilder();
                    query.Append(" UPDATE syngame SET ");
                    query.Append(" idmatch =  @IdMatch,");
                    query.Append(" result_player1 =  @RP1,");
                    query.Append(" result_player2 = @RP2, ");
                    query.Append(" id_winner =  @IdWinner ");
                    query.Append(" WHERE id = @IdGame");

                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();

                    ExecUpdInsCmdGame(query.ToString(), ng, idMatch, mytransaction, myconnection);

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
            return ng;
        }

        public bool DeleteGame(int idGame)
        {
            bool result = false;
            using (MySqlConnection myconnection = GetConnection())
            {
                MySqlTransaction mytransaction = null;
                try
                {
                    myconnection.Open();
                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();
                    String query = "DELETE FROM syngame WHERE id = @Id";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@Id", idGame);
                    command.Transaction = mytransaction;
                    command.ExecuteNonQuery();

                    mytransaction.Commit();
                    result = true;
                }
                catch (MySqlException ex)
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
            return result;
        }


    }
}
