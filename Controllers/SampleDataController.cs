using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ng2.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public List<TypeAheadResponse> TypeAheadRequest(string input)
        {
            List<string> candidate = new List<string>(new string[] { "what", "am", "I", "doing" });
            List<string> constituency = new List<string>(new string[] { "I", "am", "trying", "to", "code" });
            List<string> election = new List<string>(new string[] { "Hope", "I", "make", "what", "I", "want", "to", "make" });


            List<TypeAheadResponse> listResponse = new List<TypeAheadResponse>();
            listResponse.AddRange(prepareResponse(candidate,"candidate"));
            listResponse.AddRange(prepareResponse(constituency, "constituency"));
            listResponse.AddRange(prepareResponse(election, "election"));
            return listResponse;
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        private List<TypeAheadResponse> prepareResponse (List<string> raw, string inputtype)
        {
            List<TypeAheadResponse> toReturn = new List<TypeAheadResponse>();
            foreach (var item in raw)
            {
                TypeAheadResponse dummy = new TypeAheadResponse
                {
                    value = item,
                    type = inputtype
                };
                toReturn.Add(dummy);
            }
            return toReturn;
        }

        public class TypeAheadResponse
        {
            public string value;
            public string type;
        }
    }
}
