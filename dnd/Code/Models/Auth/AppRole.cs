using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace dnd.Code.Models.Auth
{
    public class AppRole : IdentityRole
    {
        public AppRole()  { }
        public AppRole(string name) : base(name) { }
    }
}