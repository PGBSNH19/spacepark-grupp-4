using Microsoft.AspNetCore.Mvc;
using SpacePark.API.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpacePark.API.Controllers
{

    [Route("API/v1.0/[controller]")]
    [ApiController]
    public class SwapiVisitorController : ControllerBase
    {
        [HttpGet("Character/{visitornName}")]
        public async Task<SwapiVisitorResult> GetStarWarsCharacter(string visitorName)
        {

            using HttpClient client = new HttpClient();

            var response = await client.GetStreamAsync($"https://swapi.dev/api/people/?search={ visitorName }");
            var result = await JsonSerializer.DeserializeAsync<SwapiVisitorResult>(response);

            return result;
        }
    }
}
