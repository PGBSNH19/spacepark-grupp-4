using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpacePark.API.Models;

namespace SpacePark.API.Controllers
{

    [Route("API/v1.0/[controller]")]
    [ApiController]
    public class SwapiShipController : ControllerBase
    {
        [HttpGet("Ship/{shipName}")]
        public async Task<SwapiShipResult> GetStarWarsShip(string shipName)
        {
            using HttpClient client = new HttpClient();

            var response = client.GetStreamAsync($"https://swapi.dev/api/ship/?search={ shipName }");
            var result = await JsonSerializer.DeserializeAsync<SwapiShipResult>(await response);

            return result;
        }
    }
}
