using System;
using System.Collections.Generic;

namespace DbContexts.Nfl_Db.Tables
{
    public partial class Station
    {
        public Station()
        {
            Games = new HashSet<Game>();
            Stadia = new HashSet<Stadium>();
        }

        public long StationId { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? St { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public string? Ghcnd { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Stadium> Stadia { get; set; }
    }
}
