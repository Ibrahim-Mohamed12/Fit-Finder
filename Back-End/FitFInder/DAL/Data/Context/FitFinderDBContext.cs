using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL.Data.Context
{
    public class FitFinderDBContext : IdentityDbContext<ApplicationUser>
    {
        public FitFinderDBContext(DbContextOptions<FitFinderDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
