using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEbAPIAngular.Context
{
    public class User : IdentityUser
    {
        public Guid Signature { get; set; }

        public User()
        {
            Signature = Guid.NewGuid();
        }
    }
}
