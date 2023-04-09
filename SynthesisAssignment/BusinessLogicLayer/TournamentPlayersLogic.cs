using System;
using Models;
using Interfaces;
using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class TournamentPlayersLogic
    {
        ITournamentPlayersRepo context;

        public TournamentPlayersLogic(ITournamentPlayersRepo context)
        {
            this.context = context;
        }

        public bool UserRegisterForTournament(int idUser, int idTournament)
        {
            return context.UserRegisterForTournament(idUser, idTournament);
        }

        public bool UserDERegisterFromTournament(int idUser, int idTournament)
        {
            return context.UserDERegisterFromTournament(idUser, idTournament);
        }

        public bool CheckIfUserIsRegisteredForTournament(int idUser, int idTournament)
        {
            return context.CheckIfUserIsRegisteredForTournament(idUser, idTournament);
        }

        public int CountPlayersForTournament(int idTournament)
        {
            return context.CountPlayersForTournament(idTournament);
        }

        public List<int> GetPlayersForTournament(int idTournament)
        {
            return context.GetPlayersForTournament(idTournament);
        }

        public int UpdateRankPlayer(int idTournament, int idPalyer, int rank)
        {
            return context.UpdateRankPlayer(idTournament, idPalyer, rank);
        }

        public List<Object[]> GetPlayerTournamentStatistics(int idPlayer)
        {
            return context.GetPlayerTournamentStatistics(idPlayer);
        }
    }
}
