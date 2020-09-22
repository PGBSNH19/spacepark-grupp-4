using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpacePark.API.Models;

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

            var response = client.GetStreamAsync($"https://swapi.dev/api/people/?search={ visitorName }");
            var result = await JsonSerializer.DeserializeAsync<SwapiVisitorResult>(await response);

            return result;
        }
    }
}
