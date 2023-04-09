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

namespace SynthesisAssignment
{
    public partial class TournamentEditForm : Form
    {
        public static bool reloadTournament;
        TournamentLogic logicT;
        TournamentPlayersLogic logicTP;
        MatchLogic logicM;
        Tournament objT { get; set; }

        public TournamentEditForm(int idTournament)
        {
            InitializeComponent();
            reloadTournament = false;
            logicT = new TournamentLogic(new TournamentDAL(Properties.Settings.Default.ConnectionStringDB));
            logicTP = new TournamentPlayersLogic(new TournamentPlayersDAL(Properties.Settings.Default.ConnectionStringDB));
            logicM = new MatchLogic(new MatchDAL(Properties.Settings.Default.ConnectionStringDB));
            objT = logicT.GetById(idTournament);
            if (objT.ID != 0)
            {
                LoadFields();
            }
        }

        private void btnConfirmTournament_Click(object sender, EventArgs e)
        {
            if(DateTime.Now > objT.TournamentStart && objT.ID != 0)
            {
                MessageBox.Show("You cannot edit tournament after it has started");
            }
            else
            {
                reloadTournament = true;
                Boolean isValid = true;
                String msgStr = "";
                try
                {
                    if(tbxTournamentName.Text != "" && richtbxTournamentInfo.Text != "" && tbxLocationTournament.Text != "")
                    {
                        objT.TournamentName = tbxTournamentName.Text;
                        objT.TournamentInfo = richtbxTournamentInfo.Text;
                        objT.TournamentLocation = tbxLocationTournament.Text;
                    }
                    else
                    {
                        isValid = false;
                    }                    

                    //start date is less then end date
                    if (dateTimePickerStartTournament.Value <= dateTimePickerEndTournament.Value &&
                        dateTimePickerRegisterDeadline.Value < dateTimePickerStartTournament.Value)
                    {
                        objT.TournamentStart = dateTimePickerStartTournament.Value;
                        objT.TournamentEnd = dateTimePickerEndTournament.Value;
                        objT.RegisterDeadline = dateTimePickerRegisterDeadline.Value;
                    }
                    else
                    {
                        isValid = false;
                        msgStr = " Start date cannot be after end date! \n Deadline date must be before start date!";
                    }                    

                    //min players cant be more than max
                    if (Convert.ToInt32(tbxMinPlayersTournament.Text) < Convert.ToInt32(tbxMaxPlayersTournament.Text))
                    {
                        objT.MinPlayers = Convert.ToInt32(tbxMinPlayersTournament.Text);
                        objT.MaxPlayers = Convert.ToInt32(tbxMaxPlayersTournament.Text);
                    }
                    else
                    {
                        isValid = false;
                        msgStr += "\r\n Minimum players cannot be more than maximum players!";
                    }
                    //default values
                    objT.SportType = "Badminton";
                    objT.Gold = 0;
                    objT.Silver = 0;
                    objT.Bronze = 0;

                    if (isValid)
                    {
                        msgStr = "Update complete!";
                        logicT.UpdateTournament(objT);
                        LoadFields();
                    }
                    else
                    {
                        msgStr += "\r\n Enter valid details!";
                    }
                    MessageBox.Show(msgStr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbxTournamentName.Clear();
            richtbxTournamentInfo.Clear();
            tbxLocationTournament.Clear();
            tbxMinPlayersTournament.Clear();
            tbxMaxPlayersTournament.Clear();
        }

        public void LoadFields()
        {
            lblTournamentNameShow.Text = objT.TournamentName;
            tbxTournamentName.Text = objT.TournamentName;
            richtbxTournamentInfo.Text = objT.TournamentInfo;
            dateTimePickerStartTournament.Value = objT.TournamentStart;
            dateTimePickerEndTournament.Value = objT.TournamentEnd;
            dateTimePickerRegisterDeadline.Value = objT.RegisterDeadline;
            tbxLocationTournament.Text = objT.TournamentLocation;
            tbxMinPlayersTournament.Text = objT.MinPlayers.ToString();
            tbxMaxPlayersTournament.Text = objT.MaxPlayers.ToString();
            lblPlayersRegisteredCount.Text = logicTP.CountPlayersForTournament(objT.ID).ToString();
            lblMaxPlayersReg.Text = objT.MaxPlayers.ToString();
        }

        private void btnGenerateMatches_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirm generate matches!",
                                                "Tournament",
                                                MessageBoxButtons.OKCancel,
                                                MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                //allow to generate schedule only after register deadline but before start of tournament
                if (logicTP.CountPlayersForTournament(objT.ID) == objT.MaxPlayers || (objT.TournamentStart > DateTime.Now && DateTime.Now >= objT.RegisterDeadline))
                {
                    if (objT.ID != 0)
                    {
                        List<int> players = logicTP.GetPlayersForTournament(objT.ID);
                        if (players.Count < objT.MinPlayers)
                        {
                            MessageBox.Show("Not enought players to create matches!");
                        }
                        else
                        {
                            try
                            {
                                bool matchesCreated = logicM.RoundRobin(players, objT.ID, objT.TournamentStart, objT.TournamentEnd);
                                if (matchesCreated)
                                {
                                    MessageBox.Show("Matches created successfully!");
                                }
                                else
                                {
                                    MessageBox.Show("Error occured when creating matches.");
                                }
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("Error occured when creating matches. \n Check if there are results already inputted.");
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Tournament is not created yet! \n Create one first.");
                    }
                }
                else
                {
                    MessageBox.Show("The tournament still accepts players, \n " +
                        "please wait until there are enough players or \n the " +
                        "register deadline has passed.");
                }
            }
        }
    }
}
