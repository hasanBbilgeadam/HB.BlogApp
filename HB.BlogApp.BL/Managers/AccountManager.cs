using HB.BlogApp.BL.Services;
using HB.BlogApp.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.BL.Managers
{
    public class AccountManager : IAccountService
    {

        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public void Regiser()
        {
            throw new NotImplementedException();
        }


    }
}
