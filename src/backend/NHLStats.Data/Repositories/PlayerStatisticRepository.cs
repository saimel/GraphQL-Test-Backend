﻿
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NHLStats.Core.Data;
using NHLStats.Core.Models;

namespace NHLStats.Data.Repositories
{
    public class PlayerStatisticRepository : IPlayerStatisticRepository
    {
        private readonly MLBStatsContext _db;

        public PlayerStatisticRepository(MLBStatsContext db)
        {
            _db = db;
        }

        public async Task<IList<PlayerStatistic>> Get(int playerId)
        {
            return await _db.PlayerStatistics
                .Include(ps => ps.Season)
                .Include(ps => ps.Team)
                .Include(ps => ps.Team.League)
                .Where(ps => ps.PlayerId == playerId)
                .ToListAsync();
        }

        public async Task<PlayerStatistic> Add(PlayerStatistic playerStats)
        {
            await _db.PlayerStatistics.AddAsync(playerStats);

            await _db.SaveChangesAsync();

            return playerStats;
        }
    }
}