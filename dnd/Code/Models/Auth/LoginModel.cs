using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dnd.Code.Models.Auth
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsRememberMe { get; set; }
    }
}