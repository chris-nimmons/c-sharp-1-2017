using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Models
{
   public class AuthenticationContext : DbContext
    {
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

       public AuthenticationContext() : base("Name=AuthenticationContext")
        {

        }
        
    }
}
