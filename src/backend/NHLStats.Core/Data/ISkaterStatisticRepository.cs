
using System.Threading.Tasks;
using System.Collections.Generic;
using NHLStats.Core.Models;

namespace NHLStats.Core.Data
{
    public interface IPlayerStatisticRepository
    {
        Task<IList<PlayerStatistic>> Get(int playerId);

        Task<PlayerStatistic> Add(PlayerStatistic playerStats);
    }
}
