using HahaAPI.Entities;
using HahaAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HahaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //==============================================================================================

        ProductServices productServices = new ProductServices();

        [HttpGet]
        [Route("Product/All")]
        public List<Product> GetAllProducts()
        {
            return productServices.GetAllProducts();
        }

        [HttpPost]
        [Route("Product/Add")]
        public IActionResult AddProduct(Product product)
        {
            productServices.AddProduct(product);
            return StatusCode(201);
        }

        [HttpDelete]
        [Route("Product/Delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            productServices.DeleteProduct(id);
            return StatusCode(200);
        }
    }
}
