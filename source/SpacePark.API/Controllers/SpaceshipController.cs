using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacePark.API.Models;
using SpacePark.API.Services;
using System;
using System.Threading.Tasks;

namespace SpacePark.API.Controllers
{
    [Route("API/v1.0/[controller]")]
    [ApiController]
    public class SpaceshipController : ControllerBase
    {
        private readonly ISpaceshipRepository _spaceshipRepository;

        public SpaceshipController(ISpaceshipRepository spaceshipRepository)
        {
            _spaceshipRepository = spaceshipRepository;
        }

        [HttpGet(Name = "GetSpaceships")]
        public async Task<ActionResult<Spaceship[]>> GetSpaceships()
        {
            try
            {
                var result = await _spaceshipRepository.GetSpaceships();

                if (result == null)
                    return NotFound();


                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure {exception.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Spaceship>> PostSpaceship(Spaceship spaceship)
        {
            return Ok(await _spaceshipRepository.AddSpaceship(spaceship));
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<Spaceship>> DeleteSpaceship(string name)
        {
            var spaceshipToRemove = _spaceshipRepository.GetSpaceship(name);

            if (spaceshipToRemove == null)
            {
                return NotFound();
            }
            else
            {
                _spaceshipRepository.Delete(spaceshipToRemove);
                if (await _spaceshipRepository.Save())
                {
                    return NoContent();
                }
            }
            return null;
        }
    }
}
