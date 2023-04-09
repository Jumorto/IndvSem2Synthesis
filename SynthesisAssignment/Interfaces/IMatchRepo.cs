using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Interfaces
{
    public interface IMatchRepo
    {
        public Match GetByID(int idMatch);

        public List<Match> GetByTournamentID(int idTournament);

        public bool GenerateMatches(List<Match> nM, int idTournament);

        public Match EditMatch(Match nM, int idTournament);

        public bool DeleteMatch(int idMatch);

        public List<Object[]> GetMatchWinners(int idTournament);

        public int DetermineMatchWinner(int idPlayer1, int idPlayer2, int idTournament);

        public List<Match> GetByPlayerID(int idPlayer);
    }
}
