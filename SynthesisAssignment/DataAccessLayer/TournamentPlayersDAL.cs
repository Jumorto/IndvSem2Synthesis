using MySql.Data.MySqlClient;
using Models;
using Interfaces;
using System;
using System.Text;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class TournamentPlayersDAL: ITournamentPlayersRepo
    {
        public string ConnectionString { get; set; }

        public TournamentPlayersDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public bool UserRegisterForTournament(int idUser, int idTournament)
        {
            bool result = false;
            MySqlTransaction mytransaction = null;
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();

                    String query = " INSERT INTO syntournament_players " +
                                   " (idtournament, idplayer) VALUES " +
                                   " (@IdTournament, @IdPlayer)";


                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@IdTournament", idTournament);
                    command.Parameters.AddWithValue("@IdPlayer", idUser);
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

            return result;
        }

        public bool UserDERegisterFromTournament(int idUser, int idTournament)
        {
            bool result = false;
            MySqlTransaction mytransaction = null;
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();

                    String query = "DELETE FROM syntournament_players WHERE idtournament = @IdTournament AND idplayer = @IdPlayer ; ";

                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@IdTournament", idTournament);
                    command.Parameters.AddWithValue("@IdPlayer", idUser);
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

            return result;
        }

        public bool CheckIfUserIsRegisteredForTournament(int idUser, int idTournament)
        {
            bool result = false;

            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    String query = "SELECT * FROM syntournament_players " +
                                   " WHERE idtournament = @IdTournament AND idplayer = @IdPlayer; ";

                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@IdTournament", idTournament);
                    command.Parameters.AddWithValue("@IdPlayer", idUser);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = true;
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

            return result;
        }


        public int CountPlayersForTournament(int idTournament)
        {
            int count = 0;
            using (MySqlConnection myconnection = GetConnection())
            {
                MySqlTransaction mytransaction = null;
                try
                {
                    myconnection.Open();
                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();
                    String query = "select count(*) from syntournament_players WHERE idtournament = @IdTournament";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@IdTournament", idTournament);
                    command.Transaction = mytransaction;
                    count = Convert.ToInt32(command.ExecuteScalar());

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
                finally
                {
                    if (myconnection != null)
                    {
                        myconnection.Close();
                    }
                }
            }
            return count;
        }


        public List<int> GetPlayersForTournament(int idTournament)
        {
            List<int> playersInTournament = new List<int>();

            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    String query = " SELECT su.id playerId" +
                                   " FROM syntournament_players tp INNER JOIN synuser su " +
                                   " ON tp.idplayer = su.id " +
                                   " WHERE tp.idtournament = @IdTournament; ";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@IdTournament", idTournament);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int playerId = Convert.ToInt32(reader["playerId"]);
                            playersInTournament.Add(playerId);
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

            return playersInTournament;
        }

        //for web
        public List<Object[]> GetPlayerTournamentStatistics(int idPlayer)
        {
            List<Object[]> trunamentsPlayer = new List<Object[]>();

            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();

                    String query = "SELECT " +
                                    " pl.rank plRank, " +
                                    " t.name tName , t.datestart tStart , t.dateend tEnd, t.location tLocation, t.id tId" +
                                    " FROM syntournament_players pl " +
                                    " INNER JOIN syntournament t ON t.id = pl.idtournament" +
                                    " WHERE pl.idplayer = @idPlayer" +
                                    " ORDER BY tStart DESC";

                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@idPlayer", idPlayer);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int plRank = 0;
                            int.TryParse(reader["plRank"].ToString(), out plRank);
                            DateTime ds = DateTime.Parse(reader["tStart"].ToString());
                            DateTime de = DateTime.Parse(reader["tEnd"].ToString());
                            trunamentsPlayer.Add(new object[]
                            {
                                plRank,
                                reader["tName"].ToString(),
                                reader["tLocation"].ToString(),
                                ds.Date.ToShortDateString(),
                                de.Date.ToShortDateString(),
                                reader["tId"]

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

            return trunamentsPlayer;
        }

        public int UpdateRankPlayer(int idTournament, int idPalyer, int rank)
        {
            using (MySqlConnection myconnection = GetConnection())
            {
                MySqlTransaction mytransaction = null;

                try
                {
                    myconnection.Open();

                    StringBuilder query = new StringBuilder();
                    query.Append(" UPDATE syntournament_players p SET ");
                    query.Append(" p.rank =  @Rank");
                    query.Append(" WHERE idPlayer = @idPalyer");
                    query.Append(" AND idtournament = @idT");

                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();
                    MySqlCommand command = new MySqlCommand(query.ToString(), myconnection);

                    command.Parameters.AddWithValue("@idPalyer", idPalyer);
                    command.Parameters.AddWithValue("@idT", idTournament);
                    command.Parameters.AddWithValue("@Rank", rank);

                    command.Transaction = mytransaction;
                    command.ExecuteNonQuery();


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
            return 0;
        }
    }
}
