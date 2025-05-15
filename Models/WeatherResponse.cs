namespace WeatherApp.Models
{
  public class WeatherResponse
  {
    public Location? Location { get; set; }
    public Current? Current { get; set; }
  }

  public class Location
  {
    public string? Name { get; set; }
    public string? Region { get; set; }
    public string? Country { get; set; }
  }

  public class Current
  {
    public double Temp_C { get; set; }
    public Condition? Condition { get; set; }
  }

  public class Condition
  {
    public string? Text { get; set; }
    public string? Icon { get; set; }
  }
}
