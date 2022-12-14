using DbContexts.Nfl_Db.Tables;
using Microsoft.EntityFrameworkCore;

namespace DbContexts.Nfl_Db
{
  public interface INFLContext : IDisposable
  {
    DbSet<Game> Games { get; set; }
    DbSet<SeasonsTeamStat> SeasonsTeamStats { get; set; }
    DbSet<Stadium> Stadiums { get; set; }
    DbSet<Station> Stations { get; set; }
    DbSet<Team> Teams { get; set; }
    public IEnumerable<T> GetSeasonStatsGridDataModel<T>() where T : INflSeasonStatsGridDataModel, new();
    public Task<List<T>> GetStadiumLocationMarkersAsync<T>() where T : class, IMapMarker, new();
    public Task<List<T>> GetStationMarkersAsync<T>() where T : class, IMapMarker, new();
    public Station GetStationByGame(long GameId);
    public Task<T?> GetStadiumMarkerAsync<T>(string stadium_name) where T : class, IMapMarker, new();

    public IEnumerable<T> GetGamesByTeamAsync<T>(long idTeam) where T : IGamesStatsModel, new();

    public Task<T> GetStationMarkerByGame<T>(long GameId) where T : IMapMarker, new();

  }
}