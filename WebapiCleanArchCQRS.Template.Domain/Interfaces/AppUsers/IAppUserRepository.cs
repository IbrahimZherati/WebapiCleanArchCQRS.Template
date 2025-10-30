﻿using Microsoft.AspNetCore.Identity;
using WebapiCleanArchCQRS.Template.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebapiCleanArchCQRS.Template.Domain.Interfaces.AppUsers
{
    public interface IAppUserRepository
    {
        Task SignInAsync(AppUser user , bool rememberMe);
        Task<IdentityResult> CreateAsync(AppUser user , string password);

        Task SignOutAsync();

        Task<AppUser?> FindByEmailAsync(string email);

        Task<bool> CheckPasswordSignInAsync(AppUser user , string password , bool logoutOnFialed);
    }
}
