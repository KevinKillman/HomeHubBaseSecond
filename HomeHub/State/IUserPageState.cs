namespace HomeHub.State
{
  public interface IUserPageState
  {
    public event EventHandler? PageDataStateChanged;

    /// <summary>
    /// {filterName, value}
    /// </summary>
    public ICollection<KeyValuePair<string, object>>? FilterKeyValuePairs { get; set; }
    public void SetContextLoading(bool contextLoading);
    public bool GetContextLoading();
    public void PageStateDidChange();

  }
}