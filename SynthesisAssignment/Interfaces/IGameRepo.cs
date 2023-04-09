using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Interfaces
{
    public interface IGameRepo
    {
        public Game GetByID(int idGame);

        public List<Game> GetByMatchID(int idMatch);

        public Game AddGame(Game ng, int idMatch);

        public Game EditGame(Game ng, int idMatch);

        public bool DeleteGame(int idGame);
    }
}
