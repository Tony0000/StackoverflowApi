using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class OverflowDbContextFactory : DesignTimeDbContextFactoryBase<OverflowDbContext>
    {
        protected override OverflowDbContext CreateNewInstance(DbContextOptions<OverflowDbContext> options)
        {
            return new OverflowDbContext(options);
        }
    }
}