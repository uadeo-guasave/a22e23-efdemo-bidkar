using Microsoft.EntityFrameworkCore;

namespace EFDemo.Models
{
    class SqliteDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Profile>? Profiles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Db/demo.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user => {
                user.HasIndex(n => n.Name).IsUnique();
                user.HasIndex(e => e.Email).IsUnique();
                user.HasOne(u => u.Profile).WithOne(p => p.User);
            });

            modelBuilder.Entity<Profile>(profile => {
                profile.HasOne(p => p.User).WithOne(u => u.Profile);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}