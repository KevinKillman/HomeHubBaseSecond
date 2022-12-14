namespace DbContexts.Nfl_Db.Tables
{
  public partial class SeasonsTeamStat
  {
    public SeasonsTeamStat()
    {
      GameSeasonsTeamStat1s = new HashSet<Game>();
      GameSeasonsTeamStat2s = new HashSet<Game>();
      GameSeasonsTeamStatNavigations = new HashSet<Game>();
      GameSeasonsTeamStats = new HashSet<Game>();
    }

    public string? Tm { get; set; }
    public string? W { get; set; }
    public string? L { get; set; }
    public string? Pf { get; set; }
    public string? Pa { get; set; }
    public string? Pd { get; set; }
    public long TeamId { get; set; }
    public long Year { get; set; }
    public string? T { get; set; }

    public virtual ICollection<Game> GameSeasonsTeamStat1s { get; set; }
    public virtual ICollection<Game> GameSeasonsTeamStat2s { get; set; }
    public virtual ICollection<Game> GameSeasonsTeamStatNavigations { get; set; }
    public virtual ICollection<Game> GameSeasonsTeamStats { get; set; }


  }
}
