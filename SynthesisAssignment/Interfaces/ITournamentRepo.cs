using System;
using System.Collections.Generic;
using System.Text;
using Models;
using MySql.Data.MySqlClient;

namespace Interfaces
{
    public interface ITournamentRepo
    {
        public MySqlDataAdapter TournamentList();

        public MySqlDataAdapter SearchTournaments(string tName, string tLocation);

        public Tournament GetByID(int idTournament);

        public Tournament AddTournament(Tournament nT);

        public Tournament EditTournament(Tournament nT);

        public bool DeleteTournament(int idTournament);

        public List<Tournament> SearchListAllTournaments(string tName, string tLocation, int btn);      
    }
}
