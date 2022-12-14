using System;

namespace DbContexts.Nfl_Db.Tables
{
    public partial class Game
    {
        public long GameId { get; set; }
        public long? Week { get; set; }
        public long? Ptsw { get; set; }
        public long? Ptsl { get; set; }
        public long? Ydsw { get; set; }
        public long? Ydsl { get; set; }
        public long? WinnerId { get; set; }
        public long? LoserId { get; set; }
        public long? HomeTeamId { get; set; }
        public long? AwayTeamId { get; set; }
        public DateTime? Date { get; set; }
        public long? Year { get; set; }
        public long? StadiumId { get; set; }
        public long? StationId { get; set; }
        public long? TotalPts { get; set; }
        public long? TotalYds { get; set; }
        public double? Rain { get; set; }
        public double? Temp { get; set; }

        public virtual SeasonsTeamStat? SeasonsTeamStat { get; set; }
        public virtual SeasonsTeamStat? SeasonsTeamStat1 { get; set; }
        public virtual SeasonsTeamStat? SeasonsTeamStat2 { get; set; }
        public virtual SeasonsTeamStat? SeasonsTeamStatNavigation { get; set; }
        public virtual Stadium? Stadium { get; set; }
        public virtual Station? Station { get; set; }
    }
}
