using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacePark.API.Models;

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

                if(result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {exception.Message}");

            }
        }
        // //POST:     api/v1.0/spaceport
        // [HttpPost(Name="PostSpaceport")]
        // public async Task<ActionResult<Spaceport>> PostSpaceport()
        // {
        //     try
        //     {
        //         var createdSpaceport = new Spaceport()
        //         {
 
        //             Parkinglots = new Parkinglot[5]
        //         };

        //         for (int i = 0; i < createdSpaceport.Parkinglots.Length; i++)
        //         {
        //             createdSpaceport.Parkinglots[i].ParkingLotID = i;
        //         }

        //         _spaceportRepository.Add(createdSpaceport);
        //         if(await _spaceportRepository.Save())
        //             return Created($"api/v1.0/spaceport/{createdSpaceport}", createdSpaceport);
        //     }
        //     catch (Exception e)
        //     {

        //         return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
        //     }
        //     return BadRequest();
        // }
    }
}
