using System.Web;
using System.Web.Mvc;
using dnd.Code.Models.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

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
            return View(new UserLoginModel());
        }

        public ActionResult Role()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return Redirect(Url.Action("Index", "Home"));
        }

        [HttpPost]
        public ActionResult Role(string roleName)
        {
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<ApplicationRole>>();

            if (!roleManager.RoleExists(roleName))
                roleManager.Create(new ApplicationRole(roleName));
            // rest of code
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel registration)
        {
            if (ModelState.IsValid)
            {
                if (registration.Password != registration.PasswordConfirm)
                {
                    ModelState.AddModelError("Password", "Пароль з підтвердженням не співпадають");
                    return View();
                }

                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var result = userManager.Create(new ApplicationUser() { Email = registration.Email, UserName = registration.Name, }, registration.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                    return View();
                }

                var authManager = HttpContext.GetOwinContext().Authentication;
                var user = userManager.Find(registration.Name, registration.Password);
                if (user == null) return View();
                var ident = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                return Redirect(Url.Action("Index", "Home"));
            }
            // rest of code
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginModel z)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                var user = userManager.Find(z.Name, z.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = z.RememberMe }, ident);
                    return Redirect(Url.Action("Index", "Home"));
                }
            }
            ModelState.AddModelError("", "Неправильний логін або пароль");
            return View(z);
        }
    }
}