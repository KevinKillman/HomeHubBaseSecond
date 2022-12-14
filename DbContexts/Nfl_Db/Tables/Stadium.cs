using System;
using System.Collections.Generic;

namespace DbContexts.Nfl_Db.Tables
{
    public partial class Stadium
    {
        public Stadium()
        {
            Games = new HashSet<Game>();
        }

        public long StadiumId { get; set; }
        public long? TeamId { get; set; }
        public string? Name { get; set; }
        public string? GeoPoint { get; set; }
        public string? RoofType { get; set; }
        public long? StationId { get; set; }

        public virtual Station? Station { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
