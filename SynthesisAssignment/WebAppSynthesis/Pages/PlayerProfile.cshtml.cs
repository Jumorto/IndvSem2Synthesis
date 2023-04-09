using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using BusinessLogicLayer;
using Microsoft.Extensions.Caching.Memory;


namespace WebAppSynthesis.Pages
{
    public class PlayerProfileModel : PageModel
    {

      
        public string Message { get; set; }
        public int PlayersSignedIn { get; set; }
        public bool IsPlayerRegisterd { get; set; }
        public List<Object[]> TournamentBoard { get; set; }

        public List<Match> MatchesList { get; set; }

        public void OnGet()
        {
            ViewData["CurrentUser"] = HttpContext.Session.GetInt32("CurrentUser");
            ViewData["CurrentEmail"] = HttpContext.Session.GetString("CurrentEmail");
            int idPlayer = Convert.ToInt32(HttpContext.Session.GetInt32("CurrentUser"));
            TournamentPlayersLogic logicTP = HttpContext.RequestServices.GetService(typeof(TournamentPlayersLogic)) as TournamentPlayersLogic;
            TournamentBoard = logicTP.GetPlayerTournamentStatistics(idPlayer);
            MatchLogic logicM = HttpContext.RequestServices.GetService(typeof(MatchLogic)) as MatchLogic;
            MatchesList = logicM.GetMatchesByPlayerIDWeb(idPlayer);
        }

    }
}
