using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class OverflowDbContext : DbContext, IOverflowDbContext
    {
        public OverflowDbContext(DbContextOptions<OverflowDbContext> options) : base(options)
        {
        }
        
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OverflowDbContext).Assembly);
        }
    }
}