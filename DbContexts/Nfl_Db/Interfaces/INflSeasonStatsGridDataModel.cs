public interface INflSeasonStatsGridDataModel
{
  long TeamId { get; set; }
  string? TeamName { get; set; }
  string? Wins { get; set; }
  string? Losses { get; set; }
  string? PointsFor { get; set; }
  string? PointDifference { get; set; }
  string? PointsAgainst { get; set; }
  string? Year { get; set; }
  string? Stadium { get; set; }
}