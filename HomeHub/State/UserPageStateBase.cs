namespace HomeHub.State
{
  public abstract class UserPageStateBase : IUserPageState
  {

    public ICollection<KeyValuePair<string, object>>? FilterKeyValuePairs { get; set; }

    public abstract event EventHandler? PageDataStateChanged;

    public abstract bool GetContextLoading();
    public abstract void PageStateDidChange();
    public abstract void SetContextLoading(bool contextLoading);
  }
}