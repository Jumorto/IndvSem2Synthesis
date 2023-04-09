using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Models;

namespace SynthATests
{
    public class GameMockDB: IGameRepo
    {
        List<Game> mockBDGame;
        public string ConnectionString { get; set; }

        public GameMockDB()
        {
            mockBDGame = new List<Game>();
            for (int i = 0; i < 10; i++)
            {
                Game g = new Game();
                g.ID = i;
                g.IDMatch = 1;
                g.ResultPlayer1 = 21;
                g.ResultPlayer2 = 19;
                g.IDWinner = 1;

                mockBDGame.Add(g);
            }
        }

        public void GiveConString(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public Game GetByID(int idGame)
        {
            Game srch = new Game();
            foreach (Game u in mockBDGame)
            {
                if (u.ID == idGame)
                {
                    srch = u;
                    break;
                }
            }
            return srch;
        }

        public List<Game> GetByMatchID(int idMatch)
        {
            List<Game> gM = new List<Game>();
            foreach (Game u in mockBDGame)
            {
                if (u.IDMatch == idMatch)
                {
                    gM.Add(u);
                }
            }
            return gM;
        }

        public Game AddGame(Game ng, int idMatch)
        {
            ng.IDMatch = idMatch;
            mockBDGame.Add(ng);
            return ng;
        }

        public Game EditGame(Game ng, int idMatch)
        {
            for (int i = 0; i < mockBDGame.Count; i++)
            {
                if (ng.ID == mockBDGame[i].ID && idMatch == mockBDGame[i].IDMatch)
                {
                    mockBDGame[i] = ng;
                    break;
                }
            }
            return ng;
        }

        public bool DeleteGame(int idGame)
        {
            bool result = false;
            for (int i = 0; i < mockBDGame.Count; i++)
            {
                if (idGame == mockBDGame[i].ID)
                {
                    mockBDGame.RemoveAt(i);
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
