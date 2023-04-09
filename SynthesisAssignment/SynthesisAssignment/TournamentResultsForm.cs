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
    public partial class TournamentResultsForm : Form
    {
        TournamentLogic logicT;
        TournamentPlayersLogic logicTP;
        MatchLogic logicM;
        Tournament objT { get; set; }

        public TournamentResultsForm(int idTournament)
        {
            InitializeComponent();
            logicT = new TournamentLogic(new TournamentDAL(Properties.Settings.Default.ConnectionStringDB));
            logicTP = new TournamentPlayersLogic(new TournamentPlayersDAL(Properties.Settings.Default.ConnectionStringDB));
            logicM = new MatchLogic(new MatchDAL(Properties.Settings.Default.ConnectionStringDB));
            objT = logicT.GetById(idTournament);
            lblTournamentName.Text = objT.TournamentName + "\n Tournament end date: " + objT.TournamentEnd.ToShortDateString();
            lblGoldWinner.Text = objT.NameGoldWinner;
            lblSilverWinner.Text = objT.NameSilverWinner;
            lblBronzeWinner.Text = objT.NameBronzeWinner;
            LoadDataGrid();
            LoadLeaderboardGrid();
        }

        public void LoadDataGrid()
        {
            dataGridViewMatches.AutoGenerateColumns = false;
            dataGridViewMatches.ColumnCount = 5;

            dataGridViewMatches.Columns[0].Name = "ID";
            dataGridViewMatches.Columns[0].HeaderText = "Match Id";
            dataGridViewMatches.Columns[0].DataPropertyName = "ID";
            dataGridViewMatches.Columns[0].Visible = false;

            dataGridViewMatches.Columns[1].Name = "Player1";
            dataGridViewMatches.Columns[1].HeaderText = "Player 1";
            dataGridViewMatches.Columns[1].DataPropertyName = "Player1";

            dataGridViewMatches.Columns[2].Name = "Player2";
            dataGridViewMatches.Columns[2].HeaderText = "Player 2";
            dataGridViewMatches.Columns[2].DataPropertyName = "Player2";

            dataGridViewMatches.Columns[3].Name = "IDWinner";
            dataGridViewMatches.Columns[3].HeaderText = "Winner";
            dataGridViewMatches.Columns[3].DataPropertyName = "IDWinner";

            dataGridViewMatches.Columns[4].Name = "MatchStart";
            dataGridViewMatches.Columns[4].HeaderText = "Start";
            dataGridViewMatches.Columns[4].DataPropertyName = "MatchStart";

            //ADD VIEW BUTTON COLUMN
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "btnedit";
            btnEdit.Text = "Edit";
            btnEdit.UseColumnTextForButtonValue = true;

            dataGridViewMatches.Columns.Add(btnEdit);
            dataGridViewMatches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewMatches.DataSource = logicM.MatchList(objT.ID);
        }

        private void dataGridViewMatches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row > -1)
            {
                DataGridViewRow myRow = dataGridViewMatches.Rows[e.RowIndex];
                if (e.ColumnIndex == 5 && myRow.Cells[0].Value != null)
                {
                    int idMatch = int.Parse((myRow.Cells[0].Value).ToString()); // id Tournament
                    MatchForm mf = new MatchForm(idMatch);
                    mf.StartPosition = FormStartPosition.CenterScreen;
                    mf.Location = this.Location;
                    mf.ShowDialog();
                }
            }
        }

        public void ReloadMatches()
        {
            dataGridViewMatches.DataSource = logicM.MatchList(objT.ID);
            dataGridViewMatches.Refresh();
        }

        private void TournamentResultsForm_Activated(object sender, EventArgs e)
        {
            if (MatchForm.reloadTournamentResults)
            {
                MatchForm.reloadTournamentResults = false;
                ReloadMatches();
                ReloadLeaderboard();
            }
        }

        public void ReloadLeaderboard()
        {
            dataGridViewLeaderboard.DataSource = logicM.LeaderboardList(objT.ID);
            dataGridViewLeaderboard.Refresh();
        }

        public void LoadLeaderboardGrid()
        {
            dataGridViewLeaderboard.AutoGenerateColumns = false;
            dataGridViewLeaderboard.ColumnCount = 3;

            dataGridViewLeaderboard.Columns[0].Name = "ID";
            dataGridViewLeaderboard.Columns[0].HeaderText = "Player Id";
            dataGridViewLeaderboard.Columns[0].DataPropertyName = "ID";
            dataGridViewLeaderboard.Columns[0].Visible = false;

            dataGridViewLeaderboard.Columns[1].Name = "PlayerName";
            dataGridViewLeaderboard.Columns[1].HeaderText = "Player Name";
            dataGridViewLeaderboard.Columns[1].DataPropertyName = "PlayerName";

            dataGridViewLeaderboard.Columns[2].Name = "Victories";
            dataGridViewLeaderboard.Columns[2].HeaderText = "Victories";
            dataGridViewLeaderboard.Columns[2].DataPropertyName = "Victories";

            dataGridViewLeaderboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewLeaderboard.DataSource = logicM.LeaderboardList(objT.ID);
        }

        private void bGenerateGoldSilverBronze_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > objT.TournamentEnd && DateTime.Now <= objT.TournamentEnd.AddDays(5))
            {
                try
                {
                    List<Object[]> GoldSilverBronze = logicM.GoldSilverBronzeWinners(objT.ID);

                    objT.Gold = Convert.ToInt32(GoldSilverBronze[0][0]);
                    objT.NameGoldWinner = GoldSilverBronze[0][1].ToString();

                    objT.Silver = Convert.ToInt32(GoldSilverBronze[1][0]);
                    objT.NameSilverWinner = GoldSilverBronze[1][1].ToString();

                    objT.Bronze = Convert.ToInt32(GoldSilverBronze[2][0]);
                    objT.NameBronzeWinner = GoldSilverBronze[2][1].ToString();

                    logicT.UpdateTournament(objT);

                    lblGoldWinner.Text = objT.NameGoldWinner;
                    lblSilverWinner.Text = objT.NameSilverWinner;
                    lblBronzeWinner.Text = objT.NameBronzeWinner;

                    int rank = 1;
                    DataTable dd = (DataTable)dataGridViewLeaderboard.DataSource;
                    foreach (DataRow item in dd.Rows)
                    {
                        int idPl = Convert.ToInt32(item["ID"].ToString());
                        logicTP.UpdateRankPlayer(objT.ID, idPl, rank);
                        rank++;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error when generating Gold, Silver and Bronze winners.");
                }
            }
            else
            {
                MessageBox.Show("You have up to 5 days after the end of the tournament to determine winners.");
            }


        }
    }
}
