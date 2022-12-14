using HomeHub.State;

namespace HomeHub.Pages
{
  public class NflProjectPageState : UserPageStateBase
  {
    public List<IMapMarker>? markerData { get; set; }
    private bool _contextLoading { get; set; }
    private long _selectedTeamId { get; set; } = 0;
    private string _selectedYear { get; set; } = "";
    public override event EventHandler? PageDataStateChanged;
    public virtual event EventHandler? MarkersUpdated;
    public virtual event EventHandler? YearChanged;
    public virtual event EventHandler? TeamChanged;
    public virtual event EventHandler? ResetMarkers;
    public virtual event EventHandler? StationMarkersHid;
    public virtual void MarkersDidReset() => ResetMarkers?.Invoke(this, EventArgs.Empty);
    public virtual void YearDidChange() => YearChanged?.Invoke(this, EventArgs.Empty);
    public virtual void TeamDidChange() => TeamChanged?.Invoke(this, EventArgs.Empty);
    public virtual void MarkersDidUpdate() => MarkersUpdated?.Invoke(this, EventArgs.Empty);
    /// <summary>
    /// Hides Station Markers
    /// </summary>
    public virtual void HideStations() => StationMarkersHid?.Invoke(this, EventArgs.Empty);
    public override void PageStateDidChange() => PageDataStateChanged?.Invoke(this, EventArgs.Empty);
    public override void SetContextLoading(bool contextLoading)
    {
      _contextLoading = contextLoading;
    }

    public override bool GetContextLoading()
    {
      return _contextLoading;
    }
    /// <summary>
    /// Call without param to reset teamId to 0 which is the default value
    /// </summary>
    /// <param name="teamId">Optional: Defaults to 0</param>
    public void SetTeamId(long? teamId = null)
    {
      _selectedTeamId = teamId == null ? 0 : (long)teamId;
      Console.WriteLine(_selectedTeamId);
      TeamDidChange();
    }

    public long GetTeamId()
    {
      return _selectedTeamId;
    }

    public void SetYear(string year)
    {
      _selectedYear = year;
      YearDidChange();
    }

    public string GetYear()
    {
      return _selectedYear;
    }

    public void UpdateMarker(IMapMarker? marker)
    {
      if (marker != null)
      {
        markerData = null;
        markerData = new List<IMapMarker>();
        markerData.Add(marker);
        MarkersDidUpdate();
        HideStations();
      }
    }

    public void UpdateMultipleMarkers<T>(List<T> markers) where T : IMapMarker
    {
      markerData = null;
      markerData = markers.Cast<IMapMarker>().ToList();
      MarkersDidUpdate();
      HideStations();
    }
  }
}




