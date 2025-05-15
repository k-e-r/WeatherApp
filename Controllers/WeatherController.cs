using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
  public class WeatherController : Controller
  {
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _config;
    private readonly ILogger<WeatherController> _logger;

    public WeatherController(IHttpClientFactory httpClientFactory, IConfiguration config, ILogger<WeatherController> logger)
    {
      _httpClientFactory = httpClientFactory;
      _config = config;
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Result(string city)
    {
      var apiKey = _config["WEATHER_API_KEY"];
      var baseUrl = "https://api.weatherapi.com/v1/";
      var url = $"{baseUrl}current.json?key={apiKey}&q={city}&aqi=no";

      // _logger.LogInformation("Requesting weather data from: {Url}", url.Replace(apiKey, "***"));

      var client = _httpClientFactory.CreateClient();
      var response = await client.GetAsync(url);

      if (!response.IsSuccessStatusCode)
      {
        ViewBag.Error = "Failed to retrieve weather information.";
        return View("Index");
      }

      var json = await response.Content.ReadAsStringAsync();
      var weather = JsonSerializer.Deserialize<WeatherResponse>(json, new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      });

      return View(weather);
    }
  }
}
