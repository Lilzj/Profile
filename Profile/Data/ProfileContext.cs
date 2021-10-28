using Microsoft.EntityFrameworkCore;
using Profile.Models;

namespace Profile.Data
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
