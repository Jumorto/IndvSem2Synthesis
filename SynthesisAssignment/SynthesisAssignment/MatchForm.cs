using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Models;
using BusinessLogicLayer;
using DataAccessLayer;
using Interfaces;

namespace SynthesisAssignment
{
    public partial class MatchForm : Form
    {
        public static bool reloadTournamentResults = false;
        GameLogic logicG;
        MatchLogic logicM;
        UsersLogic logicU;
        TournamentLogic logictT;

        IMatchRepo matchDal;

        Match objM;
        Tournament objT;
        Game objGame1 { get; set; }
        Game objGame2 { get; set; }
        Game objGame3 { get; set; }

        public MatchForm(int idMatch)
        {
            InitializeComponent();

            logicG = new GameLogic(new GameDAL(Properties.Settings.Default.ConnectionStringDB));
            logicM = new MatchLogic(new MatchDAL(Properties.Settings.Default.ConnectionStringDB));//this is how it should be done
            logicU = new UsersLogic(new UsersDAL(Properties.Settings.Default.ConnectionStringDB));
            logictT = new TournamentLogic(new TournamentDAL(Properties.Settings.Default.ConnectionStringDB));            

            objM = logicM.GetById(idMatch);
            objT = logictT.GetById(objM.IDTournament);

            List<Game> allGames = new List<Game>();
            foreach (Game allG in logicG.GetGamesByMatchID(idMatch))
            {
                allGames.Add(allG);
            }

            if (allGames.Count == 0)
            {
                //Game 1
                objGame1 = new Game();
                objGame1.IDMatch = objM.ID;
                //Game 2
                objGame2 = new Game();
                objGame2.IDMatch = objM.ID;
                //Game 3
                objGame3 = new Game();
                objGame3.IDMatch = objM.ID;
            }
            else if (allGames.Count == 1)
            {
                objGame1 = allGames[0];
                //Game 2
                objGame2 = new Game();
                objGame2.IDMatch = objM.ID;
                //Game 3
                objGame3 = new Game();
                objGame3.IDMatch = objM.ID;
            }
            else if (allGames.Count == 2)
            {
                objGame1 = allGames[0];
                objGame2 = allGames[1];
                //Game 3
                objGame3 = new Game();
                objGame3.IDMatch = objM.ID;
            }
            else if (allGames.Count == 3)
            {
                objGame1 = allGames[0];
                objGame2 = allGames[1];
                objGame3 = allGames[2];
            }

            //Game 1
            tbxGame1P1.Text = objGame1.ResultPlayer1.ToString();
            tbxGame1P2.Text = objGame1.ResultPlayer2.ToString();
            
            if (objGame1.IDWinner == objM.Player1)
            {
                lblWinnerGame1Name.Text = objM.Player1Name;
            }
            else if(objGame1.IDWinner == objM.Player2)
            {
                lblWinnerGame1Name.Text = objM.Player2Name;
            }

            //Game 2
            tbxGame2P1.Text = objGame2.ResultPlayer1.ToString();
            tbxGame2P2.Text = objGame2.ResultPlayer2.ToString();
            if (objGame2.IDWinner == objM.Player1)
            {
                lblWinnerGame2Name.Text = objM.Player1Name;
            }
            else if (objGame2.IDWinner == objM.Player2)
            {
                lblWinnerGame2Name.Text = objM.Player2Name;
            }

            //Game 3
            tbxGame3P1.Text = objGame3.ResultPlayer1.ToString();
            tbxGame3P2.Text = objGame3.ResultPlayer2.ToString();
            if (objGame3.IDWinner == objM.Player1)
            {
                lblWinnerGame3Name.Text = objM.Player1Name;
            }
            else if (objGame3.IDWinner == objM.Player2)
            {
                lblWinnerGame3Name.Text = objM.Player2Name;
            }


            lblMatchWinner.Text = objM.WinnerName;
 
            lblPlayer1Name.Text = objM.Player1Name;
            lblPlayer2Name.Text = objM.Player2Name;
            lblPlayer1NameRes.Text = objM.Player1Name;
            lblPlayer2NameRes.Text = objM.Player2Name;
        }

        private void btnConfirmResults_Click(object sender, EventArgs e)
        {
            if(DateTime.Now < objM.MatchStart || DateTime.Now > objT.TournamentEnd.AddDays(5))
            {
                MessageBox.Show("You cannot enter results for matches that have not started. \n " +
                    "You have up to 5 days after the end of the tournament to enter results. ");
            }
            else
            {
                try
                {
                    String msgStr = "Invalid game results - enter correct points for: ";
                    //Game 1

                    int w1 = 0;
                    if (int.TryParse(tbxGame1P1.Text, out int r11) && int.TryParse(tbxGame1P2.Text, out int r12))
                    {
                        w1 = logicG.CheckResults(objM.Player1, r11, objM.Player2, r12);
                        if (w1 == -1)
                        {
                            msgStr += "Game 1; ";
                        }
                        else if (w1 != 0)
                        {
                            objGame1.IDWinner = w1;
                            objGame1.ResultPlayer1 = Convert.ToInt32(tbxGame1P1.Text);
                            objGame1.ResultPlayer2 = Convert.ToInt32(tbxGame1P2.Text);
                            if (objGame1.IDWinner == objM.Player1)
                            {
                                lblWinnerGame1Name.Text = objM.Player1Name;
                            }
                            else
                            {
                                lblWinnerGame1Name.Text = objM.Player2Name;
                            }
                            logicG.UpdateGame(objGame1);
                        }
                    }

                    //Game 2
                    int w2 = 0;
                    if (int.TryParse(tbxGame2P1.Text, out int r21) && int.TryParse(tbxGame2P2.Text, out int r22))
                    {
                        w2 = logicG.CheckResults(objM.Player1, r21, objM.Player2, r22);
                        if (w2 == -1)
                        {
                            msgStr += "Game 2; ";
                        }
                        else if (w2 != 0)
                        {
                            objGame2.IDWinner = w2;
                            objGame2.ResultPlayer1 = Convert.ToInt32(tbxGame2P1.Text);
                            objGame2.ResultPlayer2 = Convert.ToInt32(tbxGame2P2.Text);
                            if (objGame2.IDWinner == objM.Player1)
                            {
                                lblWinnerGame2Name.Text = objM.Player1Name;
                            }
                            else
                            {
                                lblWinnerGame2Name.Text = objM.Player2Name;
                            }
                            logicG.UpdateGame(objGame2);
                        }
                    }

                    //Game 3                                
                    int w3 = 0;
                    if (int.TryParse(tbxGame3P1.Text, out int r31) && int.TryParse(tbxGame3P2.Text, out int r32))
                    {
                        w3 = logicG.CheckResults(objM.Player1, r31, objM.Player2, r32);
                        if (w3 == -1)
                        {
                            msgStr += "Game 3; ";
                        }
                        else if (w3 != 0)
                        {
                            objGame3.IDWinner = w3;
                            objGame3.ResultPlayer1 = Convert.ToInt32(tbxGame3P1.Text);
                            objGame3.ResultPlayer2 = Convert.ToInt32(tbxGame3P2.Text);
                            if (objGame3.IDWinner == objM.Player1)
                            {
                                lblWinnerGame3Name.Text = objM.Player1Name;
                            }
                            else
                            {
                                lblWinnerGame3Name.Text = objM.Player2Name;
                            }
                            logicG.UpdateGame(objGame3);
                        }
                    }

                    //Match winner
                    int idWinner = 0;
                    if (w1 == -1 || w2 == -1 || w3 == -1)
                    {
                        MessageBox.Show(msgStr);
                    }
                    else if (w1 == 0 && w2 == 0 && w3 == 0)
                    {
                        MessageBox.Show("Enter results.");
                    }
                    else if (objGame1.IDWinner != 0 && objGame2.IDWinner != 0)
                    {
                        bool isWin = false;
                        if (objGame1.IDWinner == objGame2.IDWinner)
                        {
                            idWinner = objGame1.IDWinner;
                            isWin = true;
                        }
                        else if (objGame2.IDWinner == objGame3.IDWinner && objGame3.IDWinner != 0)
                        {
                            idWinner = objGame2.IDWinner;
                            isWin = true;
                        }
                        else if (objGame1.IDWinner == objGame3.IDWinner && objGame3.IDWinner != 0)
                        {
                            idWinner = objGame1.IDWinner;
                            isWin = true;
                        }
                        if (isWin)
                        {
                            objM.IDWinner = idWinner; //setting the winner for the match

                            if (objM.IDWinner == objM.Player1)
                            {
                                lblMatchWinner.Text = objM.Player1Name;
                            }
                            else
                            {
                                lblMatchWinner.Text = objM.Player2Name;
                            }

                            logicM.UpdateMatch(objM);
                            MessageBox.Show($"Match updated.");
                            reloadTournamentResults = true;
                        }
                        else
                        {
                            MessageBox.Show($"This match has not finished yet.");
                        }

                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            

        }

        private void btnCancelMatchRes_Click(object sender, EventArgs e)
        {
            lblMatchWinner.Text = "";
            //Game 1 
            tbxGame1P1.Clear();
            tbxGame1P2.Clear();
            lblWinnerGame1.Text = "";
            //Game 2
            tbxGame2P1.Clear();
            tbxGame2P2.Clear();
            lblWinnerGame2.Text = "";
            //Game 3
            tbxGame3P1.Clear();
            tbxGame3P2.Clear();
            lblWinnerGame3.Text = "";
        }
    }
}
