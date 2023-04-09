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
    public class RegisterPageModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty, Required]
        public string username { get; set; }

        [BindProperty, Required, EmailAddress]
        public string email { get; set; }

        [BindProperty, Required, MinLength(6, ErrorMessage = "Password must be atleast 6 symbols long."), DataType(DataType.Password)]
        public string password { get; set; }

        [BindProperty, Required(ErrorMessage = "The confirm password field is required."),
            Compare(nameof(password), ErrorMessage = "Make sure both passwords are the same!"), DataType(DataType.Password)]
        public string cnfpass { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPostRegister(string username, string email, string password)
        {
            
            bool ok = false;
            Message = null;
            UsersLogic logic = HttpContext.RequestServices.GetService(typeof(UsersLogic)) as UsersLogic;
            if (logic.CheckForExistingUser(email))
            {
                Message = "Email taken!";
            }
            else
            {
                int idUser = logic.CreateNewUserWeb(username, email, password);

                if (idUser != 0)
                {
                    HttpContext.Session.SetInt32("CurrentUser", idUser);
                    ViewData["CurrentUser"] = HttpContext.Session.GetInt32("CurrentUser");
                    HttpContext.Session.SetString("CurrentEmail", email);
                    ViewData["CurrentEmail"] = HttpContext.Session.GetString("CurrentEmail");                    
                    ok = true;
                }
            }

            if (ok)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
    }
}
