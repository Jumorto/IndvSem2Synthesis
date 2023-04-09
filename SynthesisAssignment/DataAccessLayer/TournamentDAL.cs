using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Interfaces;

namespace DataAccessLayer
{
    public class TournamentDAL : ITournamentRepo
    {
        public string ConnectionString { get; set; }

        public TournamentDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public MySqlDataAdapter TournamentList()
        {
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    String query = "SELECT id, sporttype, name, info, datestart, dateend, register_deadline, location, min_players, max_players, gold, silver, bronze " +
                                   " FROM syntournament;";

                    MySqlCommand command = new MySqlCommand(query.ToString(), myconnection);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);

                    return da;
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

        public MySqlDataAdapter SearchTournaments(string tName, string tLocation)
        {
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();

                    StringBuilder query = new StringBuilder();
                    query.Append("SELECT id, sporttype, name, info, datestart, dateend, register_deadline, location, min_players, max_players, gold, silver, bronze ");
                    query.Append(" FROM syntournament ");

                    string whereC = " WHERE ";
                    if (tName != null && tName.Trim().Length != 0)
                    {
                        tName = "%" + tName.Trim().ToUpper() + "%";
                        query.Append(whereC + " UPPER(name) LIKE @Name ");
                        whereC = " AND ";
                    }
                    if (tLocation != null && tLocation.Trim().Length != 0)
                    {
                        tLocation = "%" + tLocation.Trim().ToUpper() + "%";
                        query.Append(whereC + " UPPER(location) LIKE @Location ");
                    }

                    MySqlCommand command = new MySqlCommand(query.ToString(), myconnection);
                    command.Parameters.AddWithValue("@Name", tName);
                    command.Parameters.AddWithValue("@Location", tLocation);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);

                    return da;
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

        public Tournament GetByID(int idTournament)
        {
            Tournament fTournament = new Tournament();
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    String query = "SELECT t.id tId, sporttype, t.name tName, info, datestart, dateend, register_deadline, location, min_players, max_players, " +
                                   " gold, ug.name goldName, silver, us.name silverName, bronze, ub.name bronzeName" +
                                   " FROM syntournament t " +
                                   " left join synuser ug on t.gold = ug.id " +
                                   " left join synuser us on t.silver = us.id " +
                                   " left join synuser ub on t.bronze = ub.id " +
                                   " WHERE t.id = @Id;";

                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@Id", idTournament);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fTournament.ID = Convert.ToInt32(reader["tId"]);
                            fTournament.SportType = reader["sporttype"].ToString();
                            fTournament.TournamentName = reader["tName"].ToString();
                            fTournament.TournamentInfo = reader["info"].ToString();
                            fTournament.TournamentStart = DateTime.Parse(reader["datestart"].ToString());
                            fTournament.TournamentEnd = DateTime.Parse(reader["dateend"].ToString());
                            fTournament.RegisterDeadline = DateTime.Parse(reader["register_deadline"].ToString());
                            fTournament.TournamentLocation = reader["location"].ToString();
                            fTournament.MinPlayers = Convert.ToInt32(reader["min_players"]);
                            fTournament.MaxPlayers = Convert.ToInt32(reader["max_players"]);
                            fTournament.Gold = Convert.ToInt32(reader["gold"]);
                            fTournament.NameGoldWinner = reader["goldName"].ToString();
                            fTournament.Silver = Convert.ToInt32(reader["silver"]);
                            fTournament.NameSilverWinner = reader["silverName"].ToString();
                            fTournament.Bronze = Convert.ToInt32(reader["bronze"]);
                            fTournament.NameBronzeWinner = reader["bronzeName"].ToString();
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

            return fTournament;
        }



        private int ExecUpdInsCmdTournament(String query, Tournament objTournament, MySqlTransaction mytransaction, MySqlConnection myconnection)
        {
            MySqlCommand command = new MySqlCommand(query, myconnection);
            command.Parameters.AddWithValue("@IdTournament", objTournament.ID);
            command.Parameters.AddWithValue("@SportType", objTournament.SportType);
            command.Parameters.AddWithValue("@Name", objTournament.TournamentName);
            command.Parameters.AddWithValue("@Info", objTournament.TournamentInfo);
            command.Parameters.AddWithValue("@DateStart", objTournament.TournamentStart);
            command.Parameters.AddWithValue("@DateEnd", objTournament.TournamentEnd);
            command.Parameters.AddWithValue("@RegDeadline", objTournament.RegisterDeadline);
            command.Parameters.AddWithValue("@Location", objTournament.TournamentLocation);
            command.Parameters.AddWithValue("@MinPlayers", objTournament.MinPlayers);
            command.Parameters.AddWithValue("@MaxPlayers", objTournament.MaxPlayers);
            command.Parameters.AddWithValue("@Gold", objTournament.Gold);
            command.Parameters.AddWithValue("@Silver", objTournament.Silver);
            command.Parameters.AddWithValue("@Bronze", objTournament.Bronze);


            command.Transaction = mytransaction;
            command.ExecuteNonQuery();

            return int.Parse(command.LastInsertedId.ToString());
        }

        public Tournament AddTournament(Tournament nT)
        {

            MySqlTransaction mytransaction = null;
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();                    
                    StringBuilder query = new StringBuilder();
                    query.Append(" INSERT INTO syntournament ");
                    query.Append(" (sporttype, name, info, datestart, dateend, register_deadline, location, min_players, max_players, gold, silver, bronze) VALUES ");
                    query.Append(" (@SportType, @Name, @Info, @DateStart, @DateEnd, @RegDeadline,  @Location, @MinPlayers, @MaxPlayers, @Gold, @Silver, @Bronze)");

                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();

                    nT.ID = ExecUpdInsCmdTournament(query.ToString(), nT, mytransaction, myconnection);

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
            return nT;
        }

        public Tournament EditTournament(Tournament nT)
        {
            using (MySqlConnection myconnection = GetConnection())
            {
                MySqlTransaction mytransaction = null;

                try
                {
                    myconnection.Open();
                    StringBuilder query = new StringBuilder();
                    query.Append(" UPDATE syntournament SET ");
                    query.Append(" sporttype =  @SportType,");
                    query.Append(" name =  @Name,");
                    query.Append(" info = @Info, ");
                    query.Append(" datestart = @DateStart, ");
                    query.Append(" dateend = @DateEnd, ");
                    query.Append(" register_deadline = @RegDeadline, ");
                    query.Append(" location =  @Location,");
                    query.Append(" min_players =  @MinPlayers,");
                    query.Append(" max_players =  @MaxPlayers,");
                    query.Append(" gold =  @Gold,");
                    query.Append(" silver =  @Silver,");
                    query.Append(" bronze =  @Bronze ");
                    query.Append(" WHERE id = @IdTournament;");

                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();

                    ExecUpdInsCmdTournament(query.ToString(), nT, mytransaction, myconnection);

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
            return nT;
        }

        public bool DeleteTournament(int idTournament)
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
                    String query = "DELETE FROM syntournament WHERE id = @Id";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@Id", idTournament);
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

        

        //for web
        public List<Tournament> SearchListAllTournaments(string tName, string tLocation, int btn)
        {
            List<Tournament> tournaments = new List<Tournament>();
            DateTime date = DateTime.Now;
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();

                    StringBuilder query = new StringBuilder();
                    query.Append("SELECT t.id tId, sporttype, t.name tName, info, datestart, dateend, register_deadline, location, min_players, max_players, ");
                    query.Append(" gold, ug.name goldName, silver, us.name silverName, bronze, ub.name bronzeName");
                    query.Append(" FROM syntournament t ");
                    query.Append(" left join synuser ug on t.gold = ug.id ");
                    query.Append(" left join synuser us on t.silver = us.id ");
                    query.Append(" left join synuser ub on t.bronze = ub.id ");

                    string whereC = " WHERE ";

                    if (tName != null && tName.Trim().Length != 0)
                    {
                        tName = "%" + tName.Trim().ToUpper() + "%";
                        query.Append(whereC + " UPPER(t.name) LIKE @Name ");
                        whereC = " AND ";
                    }
                    if (tLocation != null && tLocation.Trim().Length != 0)
                    {
                        tLocation = "%" + tLocation.Trim().ToUpper() + "%";
                        query.Append(whereC + " UPPER(t.location) LIKE @Location ");
                        whereC = " AND ";
                    }
                    if (btn == 0)
                    {
                        query.Append(whereC + " dateend < @Date ");
                    }
                    else if (btn == 1)
                    {
                        query.Append(whereC + " datestart <= @Date AND @Date <= dateend ");
                    }
                    else if (btn == 2)
                    {
                        query.Append(whereC + " datestart > @Date ");
                    }


                    MySqlCommand command = new MySqlCommand(query.ToString(), myconnection);
                    command.Parameters.AddWithValue("@Name", tName);
                    command.Parameters.AddWithValue("@Location", tLocation);
                    command.Parameters.AddWithValue("@Date", date);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tournaments.Add(new Tournament
                            {
                                ID = Convert.ToInt32(reader["tId"]),
                                SportType = reader["sporttype"].ToString(),
                                TournamentName = reader["tName"].ToString(),
                                TournamentInfo = reader["info"].ToString(),
                                TournamentStart = DateTime.Parse(reader["datestart"].ToString()),
                                TournamentEnd = DateTime.Parse(reader["dateend"].ToString()),
                                RegisterDeadline = DateTime.Parse(reader["register_deadline"].ToString()),
                                TournamentLocation = reader["location"].ToString(),
                                MinPlayers = Convert.ToInt32(reader["min_players"]),
                                MaxPlayers = Convert.ToInt32(reader["max_players"]),
                                Gold = Convert.ToInt32(reader["gold"]),
                                NameGoldWinner = reader["goldName"].ToString(),
                                Silver = Convert.ToInt32(reader["silver"]),
                                NameSilverWinner = reader["silverName"].ToString(),
                                Bronze = Convert.ToInt32(reader["bronze"]),
                                NameBronzeWinner = reader["bronzeName"].ToString()
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

            return tournaments;
        }       

    }
}
