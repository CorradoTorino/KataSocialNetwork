using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class SocialNetworkContext: DbContext
    {
        public SocialNetworkContext(DbContextOptions<SocialNetworkContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
