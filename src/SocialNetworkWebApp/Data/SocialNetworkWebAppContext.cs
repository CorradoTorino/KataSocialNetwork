using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Models;

namespace SocialNetworkWebApp.Data
{
    public class SocialNetworkWebAppContext : DbContext
    {
        public SocialNetworkWebAppContext (DbContextOptions<SocialNetworkWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
