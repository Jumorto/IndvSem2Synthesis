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
    public partial class MainForm : Form
    {
        TournamentLogic logic;
        public MainForm()
        {
            InitializeComponent();
            lblUsername.Text = Program.CurrentUser.Username;
            logic = new TournamentLogic(new TournamentDAL(Properties.Settings.Default.ConnectionStringDB));
            LoadDataGrid();
        }

        private void newTournamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TournamentEditForm tef = new TournamentEditForm(0);
            tef.StartPosition = FormStartPosition.CenterScreen;
            tef.Location = this.Location;
            tef.ShowDialog();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm usForm = new UsersForm();
            usForm.StartPosition = FormStartPosition.CenterScreen;
            usForm.Location = this.Location;
            usForm.ShowDialog();
        }

        public void LoadDataGrid()
        {
            dataGridViewCuTournaments.AutoGenerateColumns = false;
            dataGridViewCuTournaments.ColumnCount = 6;

            dataGridViewCuTournaments.Columns[0].Name = "idTournament";
            dataGridViewCuTournaments.Columns[0].HeaderText = "Tournament Id";
            dataGridViewCuTournaments.Columns[0].DataPropertyName = "id";
            dataGridViewCuTournaments.Columns[0].Visible = false;


            dataGridViewCuTournaments.Columns[1].Name = "TName";
            dataGridViewCuTournaments.Columns[1].HeaderText = "Name";
            dataGridViewCuTournaments.Columns[1].DataPropertyName = "name";
            dataGridViewCuTournaments.Columns[1].Width = 200;

            dataGridViewCuTournaments.Columns[2].Name = "TStartDate";
            dataGridViewCuTournaments.Columns[2].HeaderText = "Start date";
            dataGridViewCuTournaments.Columns[2].DataPropertyName = "datestart";
            dataGridViewCuTournaments.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridViewCuTournaments.Columns[3].Name = "TEndDate";
            dataGridViewCuTournaments.Columns[3].HeaderText = "End date";
            dataGridViewCuTournaments.Columns[3].DataPropertyName = "dateend";
            dataGridViewCuTournaments.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridViewCuTournaments.Columns[4].Name = "TRegDeadline";
            dataGridViewCuTournaments.Columns[4].HeaderText = "Register deadline";
            dataGridViewCuTournaments.Columns[4].DataPropertyName = "register_deadline";
            dataGridViewCuTournaments.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridViewCuTournaments.Columns[5].Name = "TLocation";
            dataGridViewCuTournaments.Columns[5].HeaderText = "Location";
            dataGridViewCuTournaments.Columns[5].DataPropertyName = "location";

            //ADD VIEW BUTTON COLUMN
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "btnedit";
            btnEdit.Text = "Edit";
            btnEdit.UseColumnTextForButtonValue = true;


            //ADD DELETE BUTTON COLUMN
            DataGridViewButtonColumn btnResults = new DataGridViewButtonColumn();
            btnResults.HeaderText = "Results";
            btnResults.Name = "btnResults";
            btnResults.Text = "Results";
            btnResults.UseColumnTextForButtonValue = true;

            //ADD DELETE BUTTON COLUMN
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Delete";
            btnDelete.Name = "btnDelete";
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;

            dataGridViewCuTournaments.Columns.Add(btnEdit);
            dataGridViewCuTournaments.Columns.Add(btnResults);
            dataGridViewCuTournaments.Columns.Add(btnDelete);
            dataGridViewCuTournaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewCuTournaments.DataSource = logic.TournamentList();
        }

        private void dataGridViewCuTournaments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
            int row = e.RowIndex;
            if (row > -1)
            {
                DataGridViewRow myRow = dataGridViewCuTournaments.Rows[e.RowIndex];
                if (e.ColumnIndex == 6 && myRow.Cells[0].Value != null)
                {
                    int idTournament = int.Parse((myRow.Cells[0].Value).ToString()); // id Tournament
                    TournamentEditForm tef = new TournamentEditForm(idTournament);
                    tef.StartPosition = FormStartPosition.CenterScreen;
                    tef.Location = this.Location;
                    tef.ShowDialog();
                }
                else if (e.ColumnIndex == 7 && myRow.Cells[0].Value != null)
                {
                    int idTournament = int.Parse((myRow.Cells[0].Value).ToString()); // id Tournament
                    TournamentResultsForm tRf = new TournamentResultsForm(idTournament);
                    tRf.StartPosition = FormStartPosition.CenterScreen;
                    tRf.Location = this.Location;
                    tRf.ShowDialog();
                }
                else if (e.ColumnIndex == 8 && myRow.Cells[0].Value != null)
                {
                    DialogResult result = MessageBox.Show("Confirm DELETE Tournament!",
                                               "Tournament",
                                               MessageBoxButtons.OKCancel,
                                               MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        int idTournament = int.Parse((myRow.Cells[0].Value).ToString()); // id Tournament
                        bool done = logic.DeleteTournament(idTournament);
                        if (done)
                        {
                            MessageBox.Show($"Tournament {idTournament} deleted!");
                        }
                        else
                        {
                            MessageBox.Show($"Tournament {idTournament} NOT deleted!");
                        }
                    }
                    ReloadTorunaments();
                }
            }

        }

        public void ReloadTorunaments()
        {
            dataGridViewCuTournaments.DataSource = logic.TournamentList();
            dataGridViewCuTournaments.Refresh();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (TournamentEditForm.reloadTournament)
            {
                TournamentEditForm.reloadTournament = false;
                ReloadTorunaments();
            }
        }

        private void btnSearchBy_Click(object sender, EventArgs e)
        {
            if (tbxSearchByName.Text != "" || tbxSearchByLocation.Text != "")
            {
                dataGridViewCuTournaments.DataSource = logic.SearchTournamentList(tbxSearchByName.Text, tbxSearchByLocation.Text);
                dataGridViewCuTournaments.Refresh();
            }
            else
            {
                ReloadTorunaments();
            }

        }

        
    }
}
