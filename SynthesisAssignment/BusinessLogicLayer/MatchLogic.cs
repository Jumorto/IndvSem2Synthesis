using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Interfaces;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class MatchLogic
    {
        IMatchRepo context;

        public MatchLogic(/*string conString,*/ IMatchRepo context)
        {
            //context = new MatchDAL();
            this.context = context;
            //context.GiveConString(conString);
        }

        public MatchLogic()
        {

        }

        public Match GetById(int idMatch)
        {
            return context.GetByID(idMatch);
        }

        public Match UpdateMatch(Match m)
        {
            Match updateMatch = new Match();
            if (m.ID != 0)
            {
                updateMatch = context.EditMatch(m, m.IDTournament);
            }
            return updateMatch;
        }

        public DataTable MatchList(int idTournament)
        {
            List<Match> matches = context.GetByTournamentID(idTournament);
            DataTable dtMatches = GetMatchListTable();

            foreach (Match m in matches)
            {
                DataRow workRow;
                workRow = dtMatches.NewRow();
                workRow[0] = m.ID.ToString();
                workRow[1] = m.Player1Name.ToString();
                workRow[2] = m.Player2Name.ToString();
                workRow[3] = m.WinnerName.ToString();
                workRow[4] = m.MatchStart.ToShortDateString();
                dtMatches.Rows.Add(workRow);
            }

            return dtMatches;
        }

        public DataTable GetMatchListTable()
        {
            DataTable dtM = new DataTable();
            dtM.Columns.Add("ID", typeof(string));
            dtM.Columns.Add("Player1", typeof(string));
            dtM.Columns.Add("Player2", typeof(string));
            dtM.Columns.Add("IDWinner", typeof(string));
            dtM.Columns.Add("MatchStart", typeof(string));
            return dtM;
        }

        //Round Robin method 
        public bool RoundRobin(List<int> players, int idTournament, DateTime startTournament, DateTime endTournament)
        {
            List<Match> matches = new List<Match>();
            bool result = false;
            
            matches = RoundRobinMatches(players, idTournament, startTournament, endTournament);
            try
            {
                result = context.GenerateMatches(matches, idTournament);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        //Round Robin Algorithm 
        public List<Match> RoundRobinMatches(List<int> players, int idTournament, DateTime startTournament, DateTime endTournament)
        {
            List<Match> matches = new List<Match>();
            //Round Robin Algorithm
            int round = 0;
            int match = 0;
            if (players.Count % 2 == 0)
            {
                round = players.Count - 1;
                match = round * (players.Count / 2);
            }
            else
            {
                round = players.Count;
                players.Add(0);
                match = round * (players.Count / 2) - round;
            }

            int tournamentDays = (endTournament - startTournament).Days + 1; // to count the last day too / if the tournament is just 1 day
            DateTime startMatch = new DateTime(startTournament.Year, startTournament.Month, startTournament.Day, 0, 0, 0, 0);
            int matchPerDay = match / tournamentDays; // determine how many matches per day(+ 1 if there is modulo)
            int remainder = match % tournamentDays;   // for adding the matches

            int matchPerDayTmp = matchPerDay;
            bool remainderFlag = false;

            int l = players.Count - 1;
            for (int i = 0; i < round; i++)
            {
                //playerX VS playerY
                for (int j = 0; j < (players.Count / 2); j++)
                {
                    if (players[j] != 0 && players[l - j] != 0)
                    {
                        Match m = new Match();
                        m.IDTournament = idTournament;
                        m.Player1 = players[j];
                        m.Player2 = players[l - j];


                        m.MatchStart = startMatch;
                        matchPerDayTmp--;

                        if (matchPerDayTmp == 0)
                        {
                            if (remainder > 0 && !remainderFlag)
                            {
                                matchPerDayTmp++;
                                remainder--;
                                remainderFlag = true;
                            }
                            else
                            {
                                startMatch = startMatch.AddDays(1);
                                matchPerDayTmp = matchPerDay;
                                remainderFlag = false;
                            }
                        }
                        matches.Add(m);
                    }
                }

                //moving the list in correct order - round robin
                int saveLast = players[players.Count - 1];
                for (int k = players.Count - 2; k > 0; k--)
                {
                    players[k + 1] = players[k];
                }
                players[1] = saveLast;
            }

            return matches;
        }

        // Leaderboard list
        public DataTable LeaderboardList(int idTournament)
        {
            List<Object[]> winners = context.GetMatchWinners(idTournament);
            DataTable dtLeaderboard = GetLeaderboardTable();

            foreach (Object[] o in winners)
            {
                DataRow workRow;
                workRow = dtLeaderboard.NewRow();
                workRow[0] = o[0].ToString();
                workRow[1] = o[1].ToString();
                workRow[2] = o[2].ToString();
                dtLeaderboard.Rows.Add(workRow);
            }

            return dtLeaderboard;
        }

        public DataTable GetLeaderboardTable()
        {
            DataTable dtL = new DataTable();
            dtL.Columns.Add("ID", typeof(string));
            dtL.Columns.Add("PlayerName", typeof(string));
            dtL.Columns.Add("Victories", typeof(string));
            return dtL;
        }

        public List<Object[]> GoldSilverBronzeWinners(int idTournament)
        {
            List<Object[]> GoldSilverBronze = new List<object[]>();
            List<Object[]> winners = context.GetMatchWinners(idTournament);

            for (int i = 1; i < winners.Count; i++)
            {
                if(winners[i][2] == winners[i - 1][2])
                {
                    int idWinner = context.DetermineMatchWinner(Convert.ToInt32(winners[i][0]), Convert.ToInt32(winners[i - 1][0]), idTournament);
                    if(idWinner == Convert.ToInt32(winners[i][0]))
                    {
                        GoldSilverBronze.Add(winners[i]);
                    }
                    else if(idWinner == Convert.ToInt32(winners[i-1][0]))
                    {
                        GoldSilverBronze.Add(winners[i-1]);
                    }
                }
                else
                {
                    GoldSilverBronze.Add(winners[i - 1]);
                }
            }

            return GoldSilverBronze;
        }

        //For web
        public List<Object[]> LeaderboardListWeb(int idTournament)
        {
            return context.GetMatchWinners(idTournament);
        }
        public List<Match> GetMatchesInTournamentWeb(int idTournament)
        {
            return context.GetByTournamentID(idTournament);
        }

        public List<Match> GetMatchesByPlayerIDWeb(int idPlayer)
        {
            return context.GetByPlayerID(idPlayer);
        } 
    }
}
