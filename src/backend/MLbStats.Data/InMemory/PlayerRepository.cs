﻿
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MLBStats.Core.Data;
using MLBStats.Core.Models;

namespace MLBStats.Data.InMemory
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<Player> _players = new List<Player> {
            new Player() { Id = 1, Name = "Babe Ruth" }
        };

        public Task<Player> Get(int id)
        {
            return Task.FromResult(_players.FirstOrDefault(p => p.Id == id));
        }

        public Task<Player> GetRandom()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Player>> All()
        {
            throw new System.NotImplementedException();
        }

        public Task<Player> Add(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}
