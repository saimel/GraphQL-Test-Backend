 
 
 
using Microsoft.EntityFrameworkCore;
 

namespace MLBStats.Data
{
    public class TemporaryDbContextFactory : DesignTimeDbContextFactoryBase<MLBStatsContext>
    {
        protected override MLBStatsContext CreateNewInstance(
            DbContextOptions<MLBStatsContext> options)
        {
            return new MLBStatsContext(options);
        }
    }
}
