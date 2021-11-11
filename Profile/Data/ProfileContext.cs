using Microsoft.EntityFrameworkCore;
using ProfileManager.Models;

namespace ProfileManager.Data
{
    public class ProfileContext : DbContext
    {

        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
