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
    public class TournamentPageModel : PageModel
    {
        private readonly IMemoryCache _cache;

        public string Message { get; set; }
        public Tournament ObjT { get; set; }
        public int PlayersSignedIn { get; set; }
        public bool IsPlayerRegisterd { get; set; }
        public List<Object[]> Leaderboard { get; set; }
        public List<Match> MatchSchedule { get; set; }

        public TournamentPageModel(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void OnGet()
        {
            GetValuesFromSession();
            if(ObjT.ID != 0)
            {
                TournamentPlayersLogic logicTP = HttpContext.RequestServices.GetService(typeof(TournamentPlayersLogic)) as TournamentPlayersLogic;
                int idUser = Convert.ToInt32(HttpContext.Session.GetInt32("CurrentUser"));
                this.IsPlayerRegisterd = logicTP.CheckIfUserIsRegisteredForTournament(idUser, ObjT.ID);
            }            

        }

        public void OnGetGetTournament(int idTournament)
        {
            GetValuesFromSession();

            Message = $"2. Tournament id = {idTournament}";

            LoadTournament(idTournament);
            TournamentPlayersLogic logicTP = HttpContext.RequestServices.GetService(typeof(TournamentPlayersLogic)) as TournamentPlayersLogic;
            int idUser = Convert.ToInt32(HttpContext.Session.GetInt32("CurrentUser"));
            this.IsPlayerRegisterd = logicTP.CheckIfUserIsRegisteredForTournament(idUser, ObjT.ID);
        }

        private void GetValuesFromSession()
        {
            ViewData["CurrentUser"] = HttpContext.Session.GetInt32("CurrentUser");
            ViewData["CurrentEmail"] = HttpContext.Session.GetString("CurrentEmail");
        }

        private void LoadTournament(int idTournament)
        {
            TournamentLogic logicT = HttpContext.RequestServices.GetService(typeof(TournamentLogic)) as TournamentLogic;
            TournamentPlayersLogic logicTP = HttpContext.RequestServices.GetService(typeof(TournamentPlayersLogic)) as TournamentPlayersLogic;
            ObjT = logicT.GetById(idTournament);
            this.PlayersSignedIn = logicTP.CountPlayersForTournament(idTournament);
            LoadLeaderBoard(idTournament);
            LoadMatchSchedule(idTournament);

            // cache the data so we dont have to load them again when signing for a tournament
            using (var cacheEntry = _cache.CreateEntry("myTournament"))
            {
                _cache.Set<Tournament>("myTournament", ObjT);
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(20); //This particular item will expire from the cache
                                                                         //if it has not been accessed within 20 minutes of it being set or last accessed.
                                                                         //Each time it is accessed, the 20 minute time limit will be reset.  
            }

            using (var cacheEntry = _cache.CreateEntry("myPlayersSignedIn"))
            {
                _cache.Set<int>("myPlayersSignedIn", this.PlayersSignedIn);
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(20);
            }

            using (var cacheEntry = _cache.CreateEntry("myIsPlayerRegisterd"))
            {
                _cache.Set<bool>("myIsPlayerRegisterd", this.IsPlayerRegisterd);
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(20);
            }

        }

        public void GetTournamentFromCache(int idTournament)
        {
            Tournament myEntryTournament; 
            if (_cache.TryGetValue("myTournament", out myEntryTournament))
            {
                // the cache entry has been retrieved
                ObjT = myEntryTournament;
            }
            else
            {
                LoadTournament(idTournament); // nothing in the cache ==> reload from DB
            }

            int myEntryPlayersSignedIn;
            if (_cache.TryGetValue("myPlayersSignedIn", out myEntryPlayersSignedIn))
            {
                // the cache entry has been retrieved
                this.PlayersSignedIn = myEntryPlayersSignedIn;
            }
            else
            {
                LoadTournament(idTournament); // nothing in the cache ==> reload from DB
            }

            bool myEntryIsPlayerRegisterd;
            if (_cache.TryGetValue("myIsPlayerRegisterd", out myEntryIsPlayerRegisterd))
            {
                // the cache entry has been retrieved
                this.IsPlayerRegisterd = myEntryIsPlayerRegisterd;
            }
            else
            {
                LoadTournament(idTournament); // nothing in the cache ==> reload from DB
            }

            List<Object[]> myEntryLeaderboard;
            if (_cache.TryGetValue("myLeaderboard", out myEntryLeaderboard))
            {
                // the cache entry has been retrieved
                this.Leaderboard = myEntryLeaderboard;
            }
            else
            {
                LoadTournament(idTournament); // nothing in the cache ==> reload from DB
            }

            List<Match> myEntryMatchSchedule;
            if (_cache.TryGetValue("myMatchSchedule", out myEntryMatchSchedule))
            {
                // the cache entry has been retrieved
                this.MatchSchedule = myEntryMatchSchedule;
            }
            else
            {
                LoadTournament(idTournament); // nothing in the cache ==> reload from DB
            }
            GetValuesFromSession();
        }

        public void LoadLeaderBoard(int idTournament)
        {
            MatchLogic logicM = HttpContext.RequestServices.GetService(typeof(MatchLogic)) as MatchLogic;
            this.Leaderboard = logicM.LeaderboardListWeb(idTournament);

            using (var cacheEntry = _cache.CreateEntry("myLeaderboard"))
            {
                _cache.Set<List<Object[]>>("myLeaderboard", this.Leaderboard);
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(20);
            }
        }

        public void LoadMatchSchedule(int idTournament)
        {
            MatchLogic logicM = HttpContext.RequestServices.GetService(typeof(MatchLogic)) as MatchLogic;
            this.MatchSchedule = logicM.GetMatchesInTournamentWeb(idTournament);

            using (var cacheEntry = _cache.CreateEntry("myMatchSchedule"))
            {
                _cache.Set<List<Match>>("myMatchSchedule", this.MatchSchedule);
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(20);
            }
        }

        public void OnPostSignUpForTournament(int idTournament)
        {
            TournamentPlayersLogic logicTP = HttpContext.RequestServices.GetService(typeof(TournamentPlayersLogic)) as TournamentPlayersLogic;
            int idUser = Convert.ToInt32(HttpContext.Session.GetInt32("CurrentUser"));
            bool result = false;
            if(idUser != 0 && idTournament != 0)
            {
                result = logicTP.UserRegisterForTournament(idUser, idTournament);
            }
            else
            {
                Message = "Error when registering.";
            }
            if (result)
            {
                Message = "You have successfully registered for this tournament.";
                this.IsPlayerRegisterd = true;
            }

            using (var cacheEntry = _cache.CreateEntry("myPlayersSignedIn"))
            {
                _cache.Set<int>("myPlayersSignedIn", this.PlayersSignedIn);
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(20);
            }

            using (var cacheEntry = _cache.CreateEntry("myIsPlayerRegisterd"))
            {
                _cache.Set<bool>("myIsPlayerRegisterd", this.IsPlayerRegisterd);
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(20);
            }

            GetTournamentFromCache(idTournament);
        }

        public void OnPostDERegisterForTournament(int idTournament)
        {
            TournamentPlayersLogic logicTP = HttpContext.RequestServices.GetService(typeof(TournamentPlayersLogic)) as TournamentPlayersLogic;
            int idUser = Convert.ToInt32(HttpContext.Session.GetInt32("CurrentUser"));
            bool result = false;
            if (idUser != 0 && idTournament != 0)
            {
                result = logicTP.UserDERegisterFromTournament(idUser, idTournament);
            }
            else
            {
                Message = "Error when deregistering.";
            }
            if (result)
            {
                Message = "You have successfully deregistered from this tournament.";
                this.IsPlayerRegisterd = false;
            }
            
            using (var cacheEntry = _cache.CreateEntry("myPlayersSignedIn"))
            {
                _cache.Set<int>("myPlayersSignedIn", this.PlayersSignedIn);
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(20); 
            }

            using (var cacheEntry = _cache.CreateEntry("myIsPlayerRegisterd"))
            {
                _cache.Set<bool>("myIsPlayerRegisterd", this.IsPlayerRegisterd);
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(20);
            }

            GetTournamentFromCache(idTournament);
        }
    }
}
