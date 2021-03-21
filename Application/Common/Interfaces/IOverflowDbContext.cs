using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public interface IOverflowDbContext
    {
        public DbSet<Job> Jobs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}