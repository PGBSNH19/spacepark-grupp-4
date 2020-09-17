using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<SpacportServices[]>> GetSpaceports()
        {
            try
            {
                var result = await _spaceportRepository.GetSpaceports();

                if(result.IsNullOrEmpty()) 
                    return NotFound();

                return Ok(result);
            }
            catch (Exception exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {exception.Message}");

            }
        }
    }
}