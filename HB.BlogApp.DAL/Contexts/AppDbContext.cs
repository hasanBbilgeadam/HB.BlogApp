using HB.BlogApp.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.DAL.Contexts
{
    public class AppDbContext:IdentityDbContext<AppUser,AppRole,string>
    {

        //dbsetler ekleyeceğim
        //konfigürasyonları tanıtacağım

        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {
                
        }

       
    }
}
