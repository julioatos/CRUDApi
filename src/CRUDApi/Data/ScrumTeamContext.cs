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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Profile)
            .WithOne(p => p.Employee)
            .HasForeignKey<Profile>(p => p.EmployeeId);
        }
    }
}
