public class MarkerModel : IMapMarker
{
  public string? Name { get; set; } = "Default";
  public string? GeoPoint { get; set; } = "USA";
  public string? Path { get; set; } = "./assets/football_marker.png";
  public string? TooltipText { get; set; } = "tooltip text";

}