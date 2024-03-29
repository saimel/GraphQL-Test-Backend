﻿ 
using Microsoft.EntityFrameworkCore;
using MLBStats.Core.Models;

namespace MLBStats.Data
{
    public sealed class MLBStatsContext : DbContext
    {
        public MLBStatsContext(DbContextOptions options)
            : base(options)
        {
           // these are mutually exclusive, migrations cannot be used with EnsureCreated()
           // Database.EnsureCreated();
           Database.Migrate();
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Season> Seasons { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
