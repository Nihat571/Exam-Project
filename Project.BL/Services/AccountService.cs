using Microsoft.AspNetCore.Identity;
using Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services
{
   
    public class AccountService
    {
        private readonly UserManager<AppUser> _manager;

        public AccountService(UserManager<AppUser> manager)
        {
            _manager = manager;
        }

        public void Register()
        {

        }

    }
}
