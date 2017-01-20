﻿using System.ComponentModel.DataAnnotations;

namespace dnd.Code.Models.Auth
{
    //public class LoginModel
    //{
    //    public string Login { get; set; }
    //    [DataType(DataType.Password)]
    //    public string Password { get; set; }
    //    public bool IsRememberMe { get; set; }
    //}

    public class UserLoginModel
    {
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}