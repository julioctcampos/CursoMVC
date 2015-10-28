using GTAC.GTACAir.Web.Identity;
using GTAC.GTACAir.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Host;
using Microsoft.AspNet.Identity.Owin;

namespace GTAC.GTACAir.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser([Bind(Include = "Name,Email,Password")]UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                UserStore<IdentityUser> userStore = new UserStore<IdentityUser>(new GTACIdentityDbContext());
                UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);

                IdentityUser user = new IdentityUser
                {
                    Email = viewModel.Email,
                    UserName = viewModel.Email,
                };
                IdentityResult result = userManager.Create(user, viewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    string errorMessage = "Não foi possível criar o usuário" + Environment.NewLine;
                    result.Errors.ToList().ForEach((error) =>
                    {
                        errorMessage += error + Environment.NewLine;
                    });
                    ModelState.AddModelError("error_on_create_user", errorMessage);

                    return View(viewModel);
                }
            }
            else
                return View(viewModel);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Email, Password")]UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userManager = Request.GetOwinContext().GetUserManager<UserManager<IdentityUser>>();
                IdentityUser user = userManager.Find(viewModel.Email, viewModel.Password);
                if (user != null)
                {
                    var authManager = Request.GetOwinContext().Authentication;
                    var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(identity);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("no_login", "Nome de usuário e/ou senha errado");
                    return View(viewModel);
                }
            }
            else
                return View(viewModel);
        }

        [HttpGet]
        public ActionResult Logoff()
        {
            var authManager = Request.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        [HttpGet]
        public ActionResult MyInfo()
        {
            return View();
        }
    }
}