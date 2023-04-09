using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Models;
using MySql.Data.MySqlClient;

namespace SynthATests
{
    public class TournamentMockDB: ITournamentRepo
    {
        List<Tournament> mockBDTournament;
        public string ConnectionString { get; set; }

        public TournamentMockDB()
        {
            mockBDTournament = new List<Tournament>();
            for (int i = 0; i < 10; i++)
            {
                Tournament t = new Tournament();
                t.ID = i;
                t.SportType = "Badminton";
                t.TournamentName = "A" + i;
                t.TournamentInfo = "AAAAAAAA" + i;
                t.TournamentStart = DateTime.Now;
                t.TournamentEnd = DateTime.Now;
                t.RegisterDeadline = DateTime.Now;
                t.TournamentLocation = "a" + i;
                t.MinPlayers = i;
                t.MaxPlayers = i + 5;
                t.Gold = 1;
                t.NameGoldWinner = "p1";
                t.Silver = 2;
                t.NameSilverWinner = "p2";
                t.Bronze = 3;
                t.NameBronzeWinner = "p3";

                mockBDTournament.Add(t);
            }
        }

        public void GiveConString(string connectionString)
        {
            this.ConnectionString = connectionString;
        }        

        public Tournament GetByID(int idTournament)
        {
            Tournament srch = new Tournament();
            foreach (Tournament u in mockBDTournament)
            {
                if (u.ID == idTournament)
                {
                    srch = u;
                    break;
                }
            }
            return srch;
        }

        public Tournament AddTournament(Tournament nT)
        {
            mockBDTournament.Add(nT);
            return nT;
        }

        public Tournament EditTournament(Tournament nT)
        {
            for (int i = 0; i < mockBDTournament.Count; i++)
            {
                if (nT.ID == mockBDTournament[i].ID)
                {
                    mockBDTournament[i] = nT;
                    break;
                }
            }
            return nT;
        }

        public bool DeleteTournament(int idTournament)
        {
            bool result = false;
            for (int i = 0; i < mockBDTournament.Count; i++)
            {
                if (idTournament == mockBDTournament[i].ID)
                {
                    mockBDTournament.RemoveAt(i);
                    result = true;
                    break;
                }
            }
            return result;
        }

        public List<Tournament> SearchListAllTournaments(string tName, string tLocation, int btn)
        {
            List<Tournament> listSrch = new List<Tournament>();
            foreach(Tournament t in mockBDTournament)
            {
                if(t.TournamentName == tName && t.TournamentLocation == tLocation)
                {
                    listSrch.Add(t);
                }
            }
            return listSrch;
        }


        public MySqlDataAdapter TournamentList()
        {
            return null;
        }

        public MySqlDataAdapter SearchTournaments(string tName, string tLocation)
        {
            return null;
        }
    }
}
