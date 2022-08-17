using CRUDApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDApi.Data
{
    public class ScrumTeamContext: DbContext
    {
        public ScrumTeamContext(DbContextOptions<ScrumTeamContext> opt) : base(opt)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<DevelopmentTeam> DevelopmentTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(employee => employee.Name)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .Property(employee => employee.Name)
                .HasMaxLength(60);
        }
    }
}
