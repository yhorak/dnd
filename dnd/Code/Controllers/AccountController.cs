using System.Web.Mvc;
using dnd.Code.Models.Auth;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin.Security;

namespace dnd.Code.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                //    var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                //    var authManager = HttpContext.GetOwinContext().Authentication;

                //    var user = userManager.Find(login.Login, login.Password);
                //    if (user != null)
                //    {
                //        var ident = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                //        authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                //        return Redirect(Url.Action("Index", "Home"));
                //    }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }
    }
}