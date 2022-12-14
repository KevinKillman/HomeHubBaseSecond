namespace HomeHub.Components
{
  public class NflSeasonStatsGridDataModel : INflSeasonStatsGridDataModel
  {
    public long TeamId { get; set; }
    public string? TeamName { get; set; }
    public string? Wins { get; set; }
    public string? Losses { get; set; }
    public string? PointsFor { get; set; }
    public string? PointsAgainst { get; set; }
    public string? Year { get; set; }
    public string? Stadium { get; set; }
    public string? PointDifference { get; set; }
  }

}
