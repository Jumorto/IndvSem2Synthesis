using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using BusinessLogicLayer;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebAppSynthesis.Pages.Shared
{
    public class LoginPageModel : PageModel
    {
        private User loggedUser { get; set; }
        public string Message { get; set; }

        [BindProperty, Required(ErrorMessage = "The email field is required.")]
        public string email { get; set; }

        [BindProperty, Required(ErrorMessage = "The password field is required."), DataType(DataType.Password)]
        public string password { get; set; }

        public void OnGet()
        {
            UsersLogic logic = HttpContext.RequestServices.GetService(typeof(UsersLogic)) as UsersLogic;
        }

        public IActionResult OnPostLogin(string email, string password)
        {
            if (ModelState.IsValid)
            {
                Message = null;
                UsersLogic logic = HttpContext.RequestServices.GetService(typeof(UsersLogic)) as UsersLogic;
                loggedUser = logic.LoginUserCheck(email, password);
                if (loggedUser != null && loggedUser.ID != 0 && loggedUser.Usertype == 0)
                {
                    HttpContext.Session.SetInt32("CurrentUser", loggedUser.ID);
                    ViewData["CurrentUser"] = HttpContext.Session.GetInt32("CurrentUser");
                    HttpContext.Session.SetString("CurrentEmail", loggedUser.Email);
                    ViewData["CurrentEmail"] = HttpContext.Session.GetString("CurrentEmail");

                    return RedirectToPage("Index");
                }
                else
                {
                    Message = $"No user with such credentials!!!";
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }

   
        public IActionResult OnPostRegister()
        {
            return RedirectToPage("RegisterPage");
        }
    }
}
