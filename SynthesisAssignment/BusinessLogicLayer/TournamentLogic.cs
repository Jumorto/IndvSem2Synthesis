using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Interfaces;
using DataAccessLayer;
using System.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogicLayer
{
    public class TournamentLogic
    {
        ITournamentRepo context;

        public TournamentLogic(ITournamentRepo context)
        {
            this.context = context;
        }


        public DataTable TournamentList()
        {
            MySqlDataAdapter da = context.TournamentList();
            DataSet ds = new DataSet();
            da.Fill(ds, "tournamentLst");
            DataTable dt = ds.Tables["tournamentLst"];
            return dt;
        }

        public DataTable SearchTournamentList(string tName, string tLocation)
        {
            MySqlDataAdapter da = context.SearchTournaments(tName, tLocation);
            DataSet ds = new DataSet();
            da.Fill(ds, "tournamentLstSearch");
            DataTable dt = ds.Tables["tournamentLstSearch"];
            return dt;
        }        

        public Tournament GetById(int idTournament)
        {
            return context.GetByID(idTournament);
        }

        public Tournament UpdateTournament(Tournament t)
        {
            Tournament tUpdated = new Tournament();
            if(t.ID != 0)
            {
                tUpdated = context.EditTournament(t);
            }
            else
            {
                tUpdated = context.AddTournament(t);
            }
            return tUpdated;
        }

        public bool DeleteTournament(int idTournament)
        {
            bool result;
            try
            {
                result = context.DeleteTournament(idTournament);                
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public List<Tournament> SearchListAllTournaments(string tName, string tLocation, int btn)
        {
            return context.SearchListAllTournaments(tName, tLocation, btn);
        }       

    }
}
