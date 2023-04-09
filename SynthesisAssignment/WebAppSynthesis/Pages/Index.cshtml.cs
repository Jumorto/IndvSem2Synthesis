using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;

namespace WebAppSynthesis.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Tournament> TournamentsListView { get; set; }
        private int Count;
        public string ListShown { get; set; }
        public string Message { get; set; }
        public string TournamentName { get; set; }
        public string TournamentLocation { get; set; }

        public void OnGet(string param)
        {                     
            TournamentLogic logicT = HttpContext.RequestServices.GetService(typeof(TournamentLogic)) as TournamentLogic;
            TournamentsListView = logicT.SearchListAllTournaments(null, null, 2);
            this.Count = TournamentsListView.Count;
            this.ListShown = "Upcoming tournaments";

            if (param == null)
            {
                //Must have this thing -- using Microsoft.AspNetCore.Http;
                ViewData["CurrentUser"] = HttpContext.Session.GetInt32("CurrentUser");
                ViewData["CurrentEmail"] = HttpContext.Session.GetString("CurrentEmail");
            }
            else
            {
                //For the logout
                HttpContext.Session.Clear();
            }
        }

        public void OnPostPastTournaments(string TournamentName, string TournamentLocation)
        {
            Message = null;
            TournamentLogic logicT = HttpContext.RequestServices.GetService(typeof(TournamentLogic)) as TournamentLogic;
            TournamentsListView = logicT.SearchListAllTournaments(TournamentName, TournamentLocation, 0);
            this.Count = TournamentsListView.Count;
            if (TournamentName != null)
            {
                Message = $"You searched for {TournamentName}. Search results: {this.Count}";
            }
            this.TournamentName = TournamentName;
            this.TournamentLocation = TournamentLocation;
            ViewData["CurrentUser"] = HttpContext.Session.GetInt32("CurrentUser");
            ViewData["CurrentEmail"] = HttpContext.Session.GetString("CurrentEmail");
            this.ListShown = "Past tournaments";
        }

        public void OnPostCurrentTournaments(string TournamentName, string TournamentLocation)
        {
            Message = null;
            TournamentLogic logicT = HttpContext.RequestServices.GetService(typeof(TournamentLogic)) as TournamentLogic;
            TournamentsListView = logicT.SearchListAllTournaments(TournamentName, TournamentLocation, 1);
            this.Count = TournamentsListView.Count;
            if (TournamentName != null)
            {
                Message = $"You searched for {TournamentName}. Search results: {this.Count}";
            }
            this.TournamentName = TournamentName;
            this.TournamentLocation = TournamentLocation;
            ViewData["CurrentUser"] = HttpContext.Session.GetInt32("CurrentUser");
            ViewData["CurrentEmail"] = HttpContext.Session.GetString("CurrentEmail");
            this.ListShown = "Current tournaments";
        }

        public void OnPostUpcomingTournaments(string TournamentName, string TournamentLocation)
        {
            Message = null;
            TournamentLogic logicT = HttpContext.RequestServices.GetService(typeof(TournamentLogic)) as TournamentLogic;
            TournamentsListView = logicT.SearchListAllTournaments(TournamentName, TournamentLocation, 2);
            this.Count = TournamentsListView.Count;
            if (TournamentName != null)
            {
                Message = $"You searched for {TournamentName}. Search results: {this.Count}";
            }
            this.TournamentName = TournamentName;
            this.TournamentLocation = TournamentLocation;
            ViewData["CurrentUser"] = HttpContext.Session.GetInt32("CurrentUser");
            ViewData["CurrentEmail"] = HttpContext.Session.GetString("CurrentEmail");
            this.ListShown = "Upcoming tournaments";
        }

        public IActionResult OnPostMoreInfo(int idTournament)
        {
            if (ModelState.IsValid)
            {
                //Redirects to the game we clicked
                return RedirectToPage("TournamentPage", "GetTournament", new { idTournament = idTournament });
            }
            else
            {
                return Page(); // stay on this page
            }
        }

    }
}
