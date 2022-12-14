namespace DbContexts.Nfl_Db.Tables
{
  public partial class Team
  {
    public long TeamId { get; set; }
    public string? TeamName { get; set; }
    public string? TeamConference { get; set; }
    public string? TeamDivision { get; set; }
    public string? FormattedTeamName { get; set; }

  }
}
