
using System.Collections.Generic;
using System.Threading.Tasks;
using MLBStats.Core.Models;

namespace MLBStats.Core.Data
{
    public interface IPlayerRepository
    {
        Task<Player> Get(int id);

        Task<Player> GetRandom();

        Task<List<Player>> All();

        Task<Player> Add(Player player);
    }
}
