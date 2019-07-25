
using System.Threading.Tasks;
using System.Collections.Generic;
using MLBStats.Core.Models;

namespace MLBStats.Core.Data
{
    public interface IPlayerStatisticRepository
    {
        Task<IList<PlayerStatistic>> Get(int playerId);

        Task<PlayerStatistic> Add(PlayerStatistic playerStats);
    }
}
