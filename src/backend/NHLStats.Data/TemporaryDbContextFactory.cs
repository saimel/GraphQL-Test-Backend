 
 
 
using Microsoft.EntityFrameworkCore;
 

namespace NHLStats.Data
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
