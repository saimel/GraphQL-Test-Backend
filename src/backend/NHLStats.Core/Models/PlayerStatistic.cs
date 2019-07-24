

using System.ComponentModel.DataAnnotations.Schema;

namespace NHLStats.Core.Models
{
    public class PlayerStatistic
    {
        public int Id { get; set; }

        public int SeasonId { get; set; }

        public int TeamId { get; set; }

        public int PlayerId { get; set; }

        public int GamesPlayed { get; set; }

        public int AtBat { get; set; }

        public int Hits { get; set; }

        public int RBIs { get; set; }

        public int HomeRuns { get; set; }

        public virtual Team Team { get; set; }

        public virtual Season Season { get; set; }

        [NotMapped]
        public int Average
        {
            get
            {
                if (AtBat == 0)
                {
                    return 0;
                }

                return 1000 * Hits / AtBat;
            }
        }
    }
}
