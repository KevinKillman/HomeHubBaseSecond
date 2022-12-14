using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeHub.Components.StockComponents
{
  public class StockChartModel
  {
    public DateTime? Date { get; set; }
    public double? Open { get; set; }
    public double? High { get; set; }
    public double? Low { get; set; }
    public double? Close { get; set; }
    public double? SMAData { get; set; }
    public decimal? AvgVolume { get; set; }

  }

}