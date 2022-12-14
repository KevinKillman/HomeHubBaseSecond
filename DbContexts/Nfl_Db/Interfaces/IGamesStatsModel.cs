public interface IGamesStatsModel
{
  public long GameId { get; set; }
  public long? Week { get; set; }
  public string HomeTeamName { get; set; }
  public string AwayTeamName { get; set; }
  public long? HomePoints { get; set; }
  public long? AwayPoints { get; set; }
  public long? HomeYards { get; set; }
  public long? AwayYards { get; set; }
  public string? StadiumName { get; set; }
  public string? Station { get; set; }
  public DateTime? Date { get; set; }
  public double? Rain { get; set; }
  public double? Temp { get; set; }
}