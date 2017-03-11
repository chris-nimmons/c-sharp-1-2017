using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class AuthenticationContext :DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AuthenticationContext() : base("Name=AuthenticationContext")
        {

        }
    }
}
