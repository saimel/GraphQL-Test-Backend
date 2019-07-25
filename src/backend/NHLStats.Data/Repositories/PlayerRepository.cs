
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MLBStats.Core.Data;
using MLBStats.Core.Models;

namespace MLBStats.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly MLBStatsContext _db;

        public PlayerRepository(MLBStatsContext db)
        {
            _db = db;
        }

        public async Task<Player> Get(int id)
        {
            return await _db.Players.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Player> GetRandom()
        {
            return await _db.Players.OrderBy(o => Guid.NewGuid()).FirstOrDefaultAsync();
        }

        public async Task<List<Player>> All()
        {
            return await _db.Players
                .Include(p => p.Statistics)
                .ToListAsync();
        }

        public async Task<Player> Add(Player player)
        {
            await _db.Players.AddAsync(player);

            foreach (var stats in player.Statistics)
            {
                stats.PlayerId = player.Id;
                await _db.PlayerStatistics.AddAsync(stats);
            }

            await _db.SaveChangesAsync();
            return player;
        }
    }
}
