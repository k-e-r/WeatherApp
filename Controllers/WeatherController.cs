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

    public WeatherController(IHttpClientFactory httpClientFactory, IConfiguration config)
    {
      _httpClientFactory = httpClientFactory;
      _config = config;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Result(string city)
    {
      var apiKey = _config["WeatherApi:ApiKey"];
      var baseUrl = _config["WeatherApi:BaseUrl"];
      var url = $"{baseUrl}current.json?key={apiKey}&q={city}&aqi=no";

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
