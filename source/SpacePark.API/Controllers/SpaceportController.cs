using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacePark.API.Models;
using System;
using System.Threading.Tasks;

namespace SpacePark.API.Controllers
{
    [Route("API/v1.0/[controller]")]
    [ApiController]
    public class SpaceportController : ControllerBase
    {
        private readonly ISpaceportRepository _spaceportRepository;

        public SpaceportController(ISpaceportRepository spaceportRepository)
        {
            _spaceportRepository = spaceportRepository;
        }

        [HttpGet(Name = "GetSpaceports")]
        public async Task<ActionResult<Spaceport[]>> GetSpaceports()
        {
            try
            {
                var result = await _spaceportRepository.GetSpaceports();

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {exception.Message}");

            }
        }
    }
}
