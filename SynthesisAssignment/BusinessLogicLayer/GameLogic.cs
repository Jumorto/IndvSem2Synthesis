using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Interfaces;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class GameLogic
    {
        IGameRepo context;

        public GameLogic(IGameRepo context)
        {
            this.context = context;
        }

        public List<Game> GetGamesByMatchID(int idMatch)
        {
            return context.GetByMatchID(idMatch);
        }

        public Game UpdateGame(Game g)
        {
            Game gameUpdate = new Game();
            if(g.ID != 0)
            {
                gameUpdate = context.EditGame(g, g.IDMatch);
            }
            else
            {
                gameUpdate = context.AddGame(g, g.IDMatch);
            }
            return gameUpdate;
        }

        public int CheckResults(int idPlayer1, int player1Res, int idPlayer2, int player2Res)
        {
            int winner = 0; 
            if (player1Res == 0 && player2Res == 0)
            {
                winner = 0; //not played yet
            }
            else if (player1Res + player2Res > 59 || player1Res == player2Res || (player1Res < 21 && player2Res < 21))
            {                
                winner = -1; // err
            }
            else
            {
                if (player1Res == 21 && player2Res < 20)
                {
                    winner = idPlayer1;
                }
                else if (player1Res < 20 && player2Res == 21)
                {
                    winner = idPlayer2;
                }
                else if (player1Res >= 20 && player2Res >= 20)
                {
                    if (player1Res > player2Res)
                    {
                        if (player1Res - player2Res == 2)
                        {
                            winner = idPlayer1;
                        }
                        else
                        {
                            if (player1Res == 30 && player2Res == 29)
                            {
                                winner = idPlayer1;
                            }
                            else
                            {                               
                                winner = -1; // err
                            }
                        }
                    }
                    else
                    {
                        if (player2Res - player1Res == 2)
                        {
                            winner = idPlayer2;
                        }
                        else
                        {
                            if (player2Res == 30 && player1Res == 29)
                            {
                                winner = idPlayer2;
                            }
                            else
                            {
                                winner = -1; // err
                            }
                        }
                    }
                }
                else
                {
                    winner = -1; // err
                }
            }

            return winner;
        }
    }
}
