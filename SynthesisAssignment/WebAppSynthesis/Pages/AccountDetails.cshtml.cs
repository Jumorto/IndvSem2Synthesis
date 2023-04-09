using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogicLayer;
using Models;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebAppSynthesis.Pages
{
    public class AccountDetailsModel : PageModel
    {
        public User ObjPlayer { get; set; }
        
        private readonly IMemoryCache _cache;

        public string Message { get; set; }

        [BindProperty, Required(ErrorMessage = "The password field is required."), DataType(DataType.Password)]
        public string PrevPassword { get; set; }

        [BindProperty, Required, MinLength(6, ErrorMessage = "Password must be atleast 6 symbols long."), DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [BindProperty, Required(ErrorMessage = "The confirm password field is required."),
        Compare(nameof(NewPassword), ErrorMessage = "Make sure both passwords are the same!"), DataType(DataType.Password)]
        public string Cnfpass { get; set; }

        public AccountDetailsModel(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void OnGet()
        {
            GetValuesFromSession();
            GetUser(Convert.ToInt32(ViewData["CurrentUser"]));
        }

        private void GetValuesFromSession()
        {
            ViewData["CurrentUser"] = HttpContext.Session.GetInt32("CurrentUser");
            ViewData["CurrentEmail"] = HttpContext.Session.GetString("CurrentEmail");
        }

        private void GetUser(int idUser)
        {
            UsersLogic logic = HttpContext.RequestServices.GetService(typeof(UsersLogic)) as UsersLogic;
            this.ObjPlayer = logic.GetByID(idUser);

            if (this.ObjPlayer != null)
            {
                using (var cacheEntry = _cache.CreateEntry("myObjPlayer"))
                {
                    _cache.Set<User>("myObjPlayer", this.ObjPlayer);
                    cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(20);
                }               
            }

        }

        private void GetUserFromCache(int idUser)
        {
            User myEntryObjPlayer;
            if (_cache.TryGetValue("myObjPlayer", out myEntryObjPlayer))
            {
                // the cache entry has been retrieved
                this.ObjPlayer = myEntryObjPlayer;
            }
            else
            {
                GetUser(idUser); // nothing in the cache ==> reload from DB
            }
        }

        //For changing password
    
        public IActionResult OnPostConfirm(string NewPassword, string PrevPassword, int idUser)
        {
            User myObjUser;
                if (_cache.TryGetValue("myObjPlayer", out myObjUser))
                {
                    // the cache entry has been retrieved
                    this.ObjPlayer = myObjUser;
                }

                if (this.ObjPlayer != null && this.ObjPlayer.Password == PrevPassword)
                {
                    this.ObjPlayer.Password = NewPassword;
                    UsersLogic logic = HttpContext.RequestServices.GetService(typeof(UsersLogic)) as UsersLogic;
                    logic.UpdateUser(this.ObjPlayer);

                    using (var cacheEntry = _cache.CreateEntry("myObjPlayer"))
                    {
                        _cache.Set<User>("myObjPlayer", this.ObjPlayer);
                        cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(20);
                    }

                Message = "New password saved.";
                return RedirectToPage("Index");
            }
            else
            {
                Message = "Previous password is incorrect.";
                GetUserFromCache(idUser);
                GetValuesFromSession();
                return Page();

            }        

        }

    }
}
