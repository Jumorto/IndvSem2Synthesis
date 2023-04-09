using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ITournamentPlayersRepo
    {
        public bool UserRegisterForTournament(int idUser, int idTournament);

        public bool UserDERegisterFromTournament(int idUser, int idTournament);

        public bool CheckIfUserIsRegisteredForTournament(int idUser, int idTournament);

        public int CountPlayersForTournament(int idTournament);

        public List<int> GetPlayersForTournament(int idTournament);

        public List<Object[]> GetPlayerTournamentStatistics(int idPlayer);

        public int UpdateRankPlayer(int idTournament, int idPalyer, int rank);
    }
}
