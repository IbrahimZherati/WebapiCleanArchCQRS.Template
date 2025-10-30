﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebapiCleanArchCQRS.Template.Shared.Helpers.ErrorMessages
{
    public static class AuthErrorMessage
    {
        public const string UserCannotFound = "user can not found";
        public const string PasswordNotCorrect = "password not correct";
        public const string LoginFailed = "login failed";
        public const string LogoutFailed = "logout failed";
        public const string RegisterFailed = "Register Failed";
    }
}
