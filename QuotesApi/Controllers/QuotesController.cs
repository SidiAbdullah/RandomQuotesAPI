using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace QuotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly string[] quotes;

        public QuotesController()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "quotes.txt");

            if (System.IO.File.Exists(filePath))
            {
                quotes = System.IO.File.ReadAllLines(filePath);
            }
            else
            {
                quotes = new string[]
                {
                    "Stay hungry, stay foolish.",
                    "Success is not final; failure is not fatal."
                };
            }
        }

        [HttpGet]
        public IActionResult GetRandomQuote()
        {
            var random = new Random();
            var quote = quotes[random.Next(quotes.Length)];
            return Ok(new { quote });
        }
    }
}
