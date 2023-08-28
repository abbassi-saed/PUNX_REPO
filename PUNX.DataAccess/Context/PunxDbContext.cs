using Microsoft.EntityFrameworkCore;
using PUNX.Domain.Entities;

namespace PUNX.DataAccess.Context
{
    public class PunxDbContext : DbContext
    {
        public PunxDbContext(DbContextOptions<PunxDbContext> options) : base(options)
        {

        }

        // DbSet for entities
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Line> Lines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
