using DbContexts.Nfl_Db.Tables;
using Microsoft.EntityFrameworkCore;

namespace DbContexts.Nfl_Db
{
  public partial class nfl_2018_dbContext : DbContext, INFLContext
  {
    public nfl_2018_dbContext()
    {
    }

    public nfl_2018_dbContext(DbContextOptions<nfl_2018_dbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if ( !optionsBuilder.IsConfigured )
      {
        //Removed Pregenerated code to protect connection string
      }
    }
    public virtual DbSet<Game> Games { get; set; } = null!;
    public virtual DbSet<SeasonsTeamStat> SeasonsTeamStats { get; set; } = null!;
    public virtual DbSet<Stadium> Stadiums { get; set; } = null!;
    public virtual DbSet<Station> Stations { get; set; } = null!;
    public virtual DbSet<Team> Teams { get; set; } = null!;


    public Task<List<T>> GetStadiumLocationMarkersAsync<T>() where T : class, IMapMarker, new()
    {

      return this.Stadiums.Select(x => new T
      {
        Name = x.Name,
        GeoPoint = x.GeoPoint,
        TooltipText = $"Roof: {x.RoofType}"
      }).Distinct().ToListAsync();
    }
    public Task<List<T>> GetStationMarkersAsync<T>() where T : class, IMapMarker, new()
    {
      return this.Stations.Select(x => new T
      {
        Name = x.Name,
        GeoPoint = x.Lat.ToString() + ", " + x.Lon.ToString(),
        Path = "./assets/station_marker.png"
      }).Distinct().ToListAsync();
    }



    public Task<T?> GetStadiumMarkerAsync<T>(string name) where T : class, IMapMarker, new()
    {
      return this.Stadiums.Where(x => x.Name.Contains(name)).Select(x => new T
      {
        Name = x.Name,
        GeoPoint = x.GeoPoint,
        TooltipText = $"Roof: {x.RoofType}"
      }).FirstOrDefaultAsync();
    }

    public IEnumerable<T> GetSeasonStatsGridDataModel<T>() where T : INflSeasonStatsGridDataModel, new()
    {
      return this.SeasonsTeamStats.Select(x => new T
      {
        TeamName = this.Teams.Where(y => y.TeamId == x.TeamId).Select(x => x.FormattedTeamName).FirstOrDefault(),
        Wins = x.W,
        Losses = x.L,
        PointsFor = x.Pf,
        PointsAgainst = x.Pa,
        PointDifference = x.Pd,
        TeamId = x.TeamId,
        Year = x.Year.ToString(),
        Stadium = this.Stadiums.Where(y => y.TeamId == x.TeamId).Select(y => y.Name).FirstOrDefault(),
      }).OrderByDescending(x => x.Year).AsEnumerable<T>();
    }


    public IEnumerable<T> GetGamesByTeamAsync<T>(long idTeam) where T : IGamesStatsModel, new()
    {
      return this.Games.Where(x => x.HomeTeamId == idTeam || x.AwayTeamId == idTeam).Select(x => new T
      {
        GameId = x.GameId,
        Week = x.Week,
        HomeTeamName = this.Teams.Where(y => y.TeamId == x.HomeTeamId).Select(y => y.FormattedTeamName).FirstOrDefault(),
        HomePoints = x.HomeTeamId == x.WinnerId ? x.Ptsw : x.Ptsl,
        HomeYards = x.HomeTeamId == x.WinnerId ? x.Ydsw : x.Ydsl,
        AwayTeamName = this.Teams.Where(y => y.TeamId == x.AwayTeamId).Select(y => y.FormattedTeamName).FirstOrDefault(),
        AwayPoints = x.AwayTeamId == x.WinnerId ? x.Ptsw : x.Ptsl,
        AwayYards = x.AwayTeamId == x.WinnerId ? x.Ydsw : x.Ydsl,
        StadiumName = x.Stadium == null ? "N/A" : x.Stadium.Name,
        Station = x.Station == null ? "N/A" : x.Station.Name,
        Date = x.Date,
        Rain = x.Rain,
        Temp = x.Temp
      }).AsEnumerable();
    }

    public Station GetStationByGame(long GameId)
    {
      return this.Games.Where(x => x.GameId == GameId).Select(x => x.Station).FirstOrDefault();
    }

    public Task<T> GetStationMarkerByGame<T>(long GameId) where T : IMapMarker, new()
    {
      return this.Games.Where(x => x.GameId == GameId).Select(x => new T
      {
        Name = x.Station.Name,
        GeoPoint = x.Station.Lat.ToString() + ", " + x.Station.Lon.ToString(),
        Path = "./assets/station_marker.png",
        TooltipText = $"Lat: {x.Station.Lat}, Lon: {x.Station.Lon}"
      }).FirstAsync();
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Game>(entity =>
      {
        entity.Property(e => e.GameId)
                  .ValueGeneratedNever()
                  .HasColumnName("game_id");

        entity.Property(e => e.AwayTeamId).HasColumnName("away_team_id");

        entity.Property(e => e.Date)
                  .HasColumnType("timestamp without time zone")
                  .HasColumnName("date");

        entity.Property(e => e.HomeTeamId).HasColumnName("home_team_id");

        entity.Property(e => e.LoserId).HasColumnName("loser_id");

        entity.Property(e => e.Ptsl).HasColumnName("ptsl");

        entity.Property(e => e.Ptsw).HasColumnName("ptsw");

        entity.Property(e => e.Rain).HasColumnName("rain");

        entity.Property(e => e.StadiumId).HasColumnName("stadium_id");

        entity.Property(e => e.StationId).HasColumnName("station_id");

        entity.Property(e => e.Temp).HasColumnName("temp");

        entity.Property(e => e.TotalPts).HasColumnName("total_pts");

        entity.Property(e => e.TotalYds).HasColumnName("total_yds");

        entity.Property(e => e.Week).HasColumnName("week");

        entity.Property(e => e.WinnerId).HasColumnName("winner_id");

        entity.Property(e => e.Ydsl).HasColumnName("ydsl");

        entity.Property(e => e.Ydsw).HasColumnName("ydsw");

        entity.Property(e => e.Year).HasColumnName("year");

        entity.HasOne(d => d.Stadium)
                  .WithMany(p => p.Games)
                  .HasForeignKey(d => d.StadiumId)
                  .HasConstraintName("fk_Games_stadium_id");

        entity.HasOne(d => d.Station)
                  .WithMany(p => p.Games)
                  .HasForeignKey(d => d.StationId)
                  .HasConstraintName("fk_Games_station_id");

        entity.HasOne(d => d.SeasonsTeamStat)
                  .WithMany(p => p.GameSeasonsTeamStats)
                  .HasForeignKey(d => new { d.AwayTeamId, d.Year })
                  .HasConstraintName("fk_Games_away_team_id");

        entity.HasOne(d => d.SeasonsTeamStatNavigation)
                  .WithMany(p => p.GameSeasonsTeamStatNavigations)
                  .HasForeignKey(d => new { d.HomeTeamId, d.Year })
                  .HasConstraintName("fk_Games_home_team_id");

        entity.HasOne(d => d.SeasonsTeamStat1)
                  .WithMany(p => p.GameSeasonsTeamStat1s)
                  .HasForeignKey(d => new { d.LoserId, d.Year })
                  .HasConstraintName("fk_Games_loser_id");

        entity.HasOne(d => d.SeasonsTeamStat2)
                  .WithMany(p => p.GameSeasonsTeamStat2s)
                  .HasForeignKey(d => new { d.WinnerId, d.Year })
                  .HasConstraintName("fk_Games_winner_id_year");
      });

      modelBuilder.Entity<SeasonsTeamStat>(entity =>
      {
        entity.HasKey(e => new { e.TeamId, e.Year })
                  .HasName("pk_Seasons_Team_Stats");

        entity.ToTable("Seasons_Team_Stats");

        entity.Property(e => e.TeamId).HasColumnName("team_id");

        entity.Property(e => e.Year).HasColumnName("year");

        entity.Property(e => e.Pa).HasColumnName("PA");

        entity.Property(e => e.Pd).HasColumnName("PD");

        entity.Property(e => e.Pf).HasColumnName("PF");
      });

      modelBuilder.Entity<Stadium>(entity =>
      {
        entity.Property(e => e.StadiumId)
                  .ValueGeneratedNever()
                  .HasColumnName("stadium_id");

        entity.Property(e => e.GeoPoint).HasColumnName("geo_point");

        entity.Property(e => e.Name).HasColumnName("name");

        entity.Property(e => e.RoofType).HasColumnName("roof_type");

        entity.Property(e => e.StationId).HasColumnName("station_id");

        entity.Property(e => e.TeamId).HasColumnName("team_id");

        entity.HasOne(d => d.Station)
                  .WithMany(p => p.Stadia)
                  .HasForeignKey(d => d.StationId)
                  .HasConstraintName("fk_Stadiums_station_id");
      });

      modelBuilder.Entity<Station>(entity =>
      {
        entity.Property(e => e.StationId)
                  .ValueGeneratedNever()
                  .HasColumnName("station_id");

        entity.Property(e => e.Country).HasColumnName("country");

        entity.Property(e => e.Ghcnd).HasColumnName("ghcnd");

        entity.Property(e => e.Lat).HasColumnName("lat");

        entity.Property(e => e.Lon).HasColumnName("lon");

        entity.Property(e => e.Name).HasColumnName("name");

        entity.Property(e => e.St).HasColumnName("st");
      });

      modelBuilder.Entity<Team>(entity =>
      {
        entity.Property(e => e.TeamId)
                  .ValueGeneratedNever()
                  .HasColumnName("team_id");

        entity.Property(e => e.TeamConference).HasColumnName("team_conference");

        entity.Property(e => e.TeamDivision).HasColumnName("team_division");

        entity.Property(e => e.TeamName).HasColumnName("team_name");

        entity.Property(e => e.FormattedTeamName).HasColumnName("formatted_team_name");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public Task<T?> GetGameDataByYearTeam<T>(long TeamId, string Year)
    {
      throw new NotImplementedException();
    }
  }
}
