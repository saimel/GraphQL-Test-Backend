

using System.Collections.Generic;

namespace MLBStats.Core.Models
{
    public class League
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public IList<Team> Teams { get; set; }
    }
}
