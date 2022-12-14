using HomeHub.State;

namespace HomeHub.Pages
{
  public class StocksPageState : UserPageStateBase
  {
    private bool _contextLoading;
    private string _stockTicker = "MCD";
    private string _stockExchangeAbbrev = "US";
    public override event EventHandler? PageDataStateChanged;
    public override void PageStateDidChange() => PageDataStateChanged?.Invoke(this, EventArgs.Empty);
    public override bool GetContextLoading()
    {
      return _contextLoading;
    }
    public override void SetContextLoading(bool contextLoading)
    {
      _contextLoading = contextLoading;
    }
    public string GetStockTickerQueryString()
    {
      return $"{_stockTicker}.{_stockExchangeAbbrev}";
    }
  }
}