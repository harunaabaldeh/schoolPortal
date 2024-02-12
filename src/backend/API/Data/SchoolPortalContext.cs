using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SchoolPortalContext : DbContext
    {
        public SchoolPortalContext(DbContextOptions<SchoolPortalContext> options) : base(options)
        {
            
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}