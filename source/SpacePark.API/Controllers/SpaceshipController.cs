using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Threading.Tasks;

namespace SpacePark.API.Controllers
{
    [ApiKeyAuth]
    [Route(API/v1.0/"[controller]")]
    [ApiController]
    public class SpaceshipController : ControllerBase
    {
        private readonly ISpaceshipRepository _spaceshipRepository;
        public SpaceshipController(ISpaceshipRepository spaceshipRepository)
        {
            _spaceshipRepository = spaceshipRepository;
        }

        [HttpGet(Name = "GetSpaceships")]
        public async Task<ActionResult<SpaceshipServices[]>> GetSpaceships()
        {
            try
            {
                var result = await _spaceshipRepository.GetSpaceships();

                if (result.IsNullOrEmpty())
                    return NotFound();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure {exception.Message}");
            }
        }
    }
}
