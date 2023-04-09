using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Models;
using MySql.Data.MySqlClient;

namespace SynthATests
{
    public class MatchMockDB: IMatchRepo
    {
        List<Match> mockBDMatch;
        public string ConnectionString { get; set; }

        public MatchMockDB()
        {
            mockBDMatch = new List<Match>();
            for (int i = 0; i < 10; i++)
            {
                Match m = new Match();
                m.ID = i;
                m.IDTournament = 1;
                m.MatchStart = DateTime.Now;
                m.Player1 = 1;
                m.Player1Name = "A1";
                m.Player2 = 2;
                m.Player2Name = "A2";
                m.IDWinner = 2;
                m.WinnerName = "A2";

                mockBDMatch.Add(m);
            }
        }

        public void GiveConString(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public Match GetByID(int idMatch)
        {
            Match srch = new Match();
            foreach (Match u in mockBDMatch)
            {
                if (u.ID == idMatch)
                {
                    srch = u;
                    break;
                }
            }
            return srch;
        }

        public List<Match> GetByTournamentID(int idTournament)
        {
            List<Match> mT = new List<Match>();
            foreach (Match u in mockBDMatch)
            {
                if (u.IDTournament == idTournament)
                {
                    mT.Add(u);
                }
            }
            return mT;
        }        

        public Match EditMatch(Match nM, int idTournament)
        {
            for (int i = 0; i < mockBDMatch.Count; i++)
            {
                if (nM.ID == mockBDMatch[i].ID && idTournament == mockBDMatch[i].IDTournament)
                {
                    mockBDMatch[i] = nM;
                    break;
                }
            }
            return nM;
        }

        public bool DeleteMatch(int idMatch)
        {
            bool result = false;
            for (int i = 0; i < mockBDMatch.Count; i++)
            {
                if (idMatch == mockBDMatch[i].ID)
                {
                    mockBDMatch.RemoveAt(i);
                    result = true;
                    break;
                }
            }
            return result;
        }

        public List<Object[]> GetMatchWinners(int idTournament)
        {
            List<Object[]> mT = new List<Object[]>();
            foreach (Match u in mockBDMatch)
            {
                if (u.IDTournament == idTournament)
                {
                    mT.Add(new object[]
                            {
                                u.IDWinner,
                                u.IDWinner
                            });
                }
            }
            return mT;
        }

        public int DetermineMatchWinner(int idPlayer1, int idPlayer2, int idTournament)
        {
            int srch = 0;
            foreach (Match u in mockBDMatch)
            {
                if (u.IDTournament == idTournament)
                {
                    if(idPlayer1 == u.IDWinner)
                    {
                        srch = idPlayer1;
                    }else if(idPlayer2 == u.IDWinner)
                    {
                        srch = idPlayer2;
                    }
                }
            }
            return srch;
        }

        public List<Match> GetByPlayerID(int idPlayer)
        {
            List<Match> mT = new List<Match>();
            foreach (Match u in mockBDMatch)
            {
                if (u.Player1 == idPlayer || u.Player2 == idPlayer)
                {
                    mT.Add(u);
                }
            }
            return mT;
        }

        public bool GenerateMatches(List<Match> nM, int idTournament)
        {
            return false;
        }
    }
}
