using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using WEbAPIAngular.Controllers;

namespace WEbAPIAngular.Context
{
    public class ColbysContext : IdentityDbContext<User>
    {
        public DbSet<Beer> Beers { get; set; }
    }
}