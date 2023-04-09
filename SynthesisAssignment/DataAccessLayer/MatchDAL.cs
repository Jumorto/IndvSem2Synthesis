using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Interfaces;

namespace DataAccessLayer
{
    public class MatchDAL : IMatchRepo
    {
        public string ConnectionString { get; set; }

        public MatchDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public Match GetByID(int idMatch)
        {
            Match fMatch = new Match();
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    String query = "SELECT m.id mId, idtournament, player1, up1.name p1Name, player2, up2.name p2Name, datestart, m.id_winner mIdWin, winner.name winName" +
                                   " FROM synmatch m " +
                                   " left join synuser up1 on m.player1 = up1.id " +
                                   " left join synuser up2 on m.player2 = up2.id " +
                                   " left join synuser winner on m.id_winner = winner.id " +
                                   " WHERE m.id = @Id; ";

                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@Id", idMatch);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fMatch.ID = Convert.ToInt32(reader["mId"]);
                            fMatch.IDTournament = Convert.ToInt32(reader["idtournament"]);
                            fMatch.Player1 = Convert.ToInt32(reader["player1"]);
                            fMatch.Player1Name = reader["p1Name"].ToString();
                            fMatch.Player2 = Convert.ToInt32(reader["player2"]);
                            fMatch.Player2Name = reader["p2Name"].ToString();
                            fMatch.MatchStart = DateTime.Parse(reader["datestart"].ToString());
                            fMatch.IDWinner = Convert.ToInt32(reader["mIdWin"]);
                            fMatch.WinnerName = reader["winName"].ToString();
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

            return fMatch;
        }

        public List<Match> GetByTournamentID(int idTournament)
        {
            List<Match> matchesInTournament = new List<Match>();
            Match fMatch = new Match();
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    String query = "SELECT m.id mId, idtournament, player1, up1.name p1Name, player2, up2.name p2Name, datestart, m.id_winner mIdWin, winner.name winName" +
                                   " FROM synmatch m " +
                                   " left join synuser up1 on m.player1 = up1.id " +
                                   " left join synuser up2 on m.player2 = up2.id " +
                                   " left join synuser winner on m.id_winner = winner.id " +
                                   " WHERE idtournament = @IdTournament; ";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@IdTournament", idTournament);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            matchesInTournament.Add(new Match
                            {
                                ID = Convert.ToInt32(reader["mId"]),
                                IDTournament = Convert.ToInt32(reader["idtournament"]),
                                Player1 = Convert.ToInt32(reader["player1"]),
                                Player1Name = reader["p1Name"].ToString(),
                                Player2 = Convert.ToInt32(reader["player2"]),
                                Player2Name = reader["p2Name"].ToString(),
                                MatchStart = DateTime.Parse(reader["datestart"].ToString()),
                                IDWinner = Convert.ToInt32(reader["mIdWin"]),
                                WinnerName = reader["winName"].ToString()
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

            return matchesInTournament;
        }

        private int ExecUpdInsCmdMatch(String query, Match objMatch, int idTournament, MySqlTransaction mytransaction, MySqlConnection myconnection)
        {
            MySqlCommand command = new MySqlCommand(query, myconnection);
            command.Parameters.AddWithValue("@IdMatch", objMatch.ID);
            command.Parameters.AddWithValue("@IdTournament", idTournament);
            command.Parameters.AddWithValue("@Player1", objMatch.Player1);
            command.Parameters.AddWithValue("@Player2", objMatch.Player2);
            command.Parameters.AddWithValue("@DateStart", objMatch.MatchStart);
            command.Parameters.AddWithValue("@IdWinner", objMatch.IDWinner);

            command.Transaction = mytransaction;
            command.ExecuteNonQuery();

            return int.Parse(command.LastInsertedId.ToString());
        }

        public bool GenerateMatches(List<Match> nM, int idTournament)
        {
            bool result = false;
            MySqlTransaction mytransaction = null;
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();

                    //deleting all prevoius matches
                    String queryDel = "DELETE FROM synmatch WHERE idtournament = @IdTournament";
                    MySqlCommand commandDel = new MySqlCommand(queryDel, myconnection);
                    commandDel.Parameters.AddWithValue("@IdTournament", idTournament);

                    //new match
                    StringBuilder query = new StringBuilder();
                    query.Append(" INSERT INTO synmatch ");
                    query.Append(" (idtournament, player1, player2, datestart, id_winner) VALUES ");
                    query.Append(" (@IdTournament, @Player1, @Player2, @DateStart, @IdWinner)");


                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();
                    commandDel.ExecuteNonQuery(); //delete all matches

                    foreach (Match m in nM)
                    {
                        ExecUpdInsCmdMatch(query.ToString(), m, idTournament, mytransaction, myconnection);
                    }
                    result = true;
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
            return result;
        }

        public Match EditMatch(Match nM, int idTournament)
        {
            using (MySqlConnection myconnection = GetConnection())
            {
                MySqlTransaction mytransaction = null;

                try
                {
                    myconnection.Open();
                    StringBuilder query = new StringBuilder();
                    query.Append(" UPDATE synmatch SET ");
                    query.Append(" idtournament =  @IdTournament,");
                    query.Append(" player1 =  @Player1,");
                    query.Append(" player2 = @Player2, ");
                    query.Append(" datestart = @DateStart, ");
                    query.Append(" id_winner =  @IdWinner ");
                    query.Append(" WHERE id = @IdMatch");

                    // Start a local transaction.
                    mytransaction = myconnection.BeginTransaction();

                    ExecUpdInsCmdMatch(query.ToString(), nM, idTournament, mytransaction, myconnection);

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
            return nM;
        }

        public bool DeleteMatch(int idMatch)
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
                    String query = "DELETE FROM synmatch WHERE id = @Id";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@Id", idMatch);
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

        public List<Object[]> GetMatchWinners(int idTournament)
        {
            List<Object[]> matchWinners = new List<Object[]>();

            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();

                    String query = " SELECT " +
                                        "(SELECT count(*) winM FROM synmatch m " +
                                        " WHERE m.idtournament = pl.idtournament  and m.id_winner = pl.idplayer " +
                                        " GROUP BY m.id_winner) winM, pl.idplayer win, u.name pName " +
                                    " FROM syntournament_players pl " +
                                    " INNER JOIN synuser u ON pl.idplayer = u.id" +
                                    " WHERE pl.idtournament = @IdTournament " +
                                    " ORDER BY winM DESC;";

                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@IdTournament", idTournament);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int winM = 0;
                            int.TryParse(reader["winM"].ToString(), out winM);
                            matchWinners.Add(new object[]
                            {
                                Convert.ToInt32(reader["win"]),
                                reader["pName"].ToString(),
                                winM
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

            return matchWinners;
        }


        public int DetermineMatchWinner(int idPlayer1, int idPlayer2, int idTournament)
        {
            int idWinner = 0;
            using (MySqlConnection myconnection = GetConnection())
            {

                try
                {
                    myconnection.Open();
                    String query = " SELECT id_winner idWin " +
                                   " FROM synmatch" +
                                   " WHERE player1 = @IdPlayer1 AND player2 = @IdPlayer2 OR player1 = @IdPlayer12 AND player2 = @IdPlayer21 AND idtournament = @IdTournament ; ";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@IdPlayer1", idPlayer1);
                    command.Parameters.AddWithValue("@IdPlayer2", idPlayer2);
                    command.Parameters.AddWithValue("@IdPlayer12", idPlayer2);
                    command.Parameters.AddWithValue("@IdPlayer21", idPlayer1);
                    command.Parameters.AddWithValue("@IdTournament", idTournament);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idWinner = Convert.ToInt32(reader["idWin"]);
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
            return idWinner;
        }


        public List<Match> GetByPlayerID(int idPlayer)
        {
            List<Match> matchesInTournament = new List<Match>();
            Match fMatch = new Match();
            using (MySqlConnection myconnection = GetConnection())
            {
                try
                {
                    myconnection.Open();
                    String query = "SELECT m.id mId, idtournament, player1, up1.name p1Name, player2, up2.name p2Name, datestart, m.id_winner mIdWin, winner.name winName" +
                                   " FROM synmatch m " +
                                   " left join synuser up1 on m.player1 = up1.id " +
                                   " left join synuser up2 on m.player2 = up2.id " +
                                   " left join synuser winner on m.id_winner = winner.id " +
                                   " WHERE player1 = @idPlayer or player2 = @idPlayer; ";
                    MySqlCommand command = new MySqlCommand(query, myconnection);
                    command.Parameters.AddWithValue("@idPlayer", idPlayer);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            matchesInTournament.Add(new Match
                            {
                                ID = Convert.ToInt32(reader["mId"]),
                                IDTournament = Convert.ToInt32(reader["idtournament"]),
                                Player1 = Convert.ToInt32(reader["player1"]),
                                Player1Name = reader["p1Name"].ToString(),
                                Player2 = Convert.ToInt32(reader["player2"]),
                                Player2Name = reader["p2Name"].ToString(),
                                MatchStart = DateTime.Parse(reader["datestart"].ToString()),
                                IDWinner = Convert.ToInt32(reader["mIdWin"]),
                                WinnerName = reader["winName"].ToString()
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

            return matchesInTournament;
        }

    }
}
