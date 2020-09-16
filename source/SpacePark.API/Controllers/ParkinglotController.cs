using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacePark.API.Models;
using SpacePark.API.Services;

namespace SpacePark.API.Controllers
{
    [ApiKeyAuth]
    [Route(API/v1.0/"[controller]")]
    [ApiController]
    public class ParkinglotController : ControllerBase
    { 
        private readonly IParkinglotRepository _parkinglotRepository;
        public ParkinglotController(IParkinglotRepository parkinglotRepository)
        {
            _parkinglotRepository= parkinglotRepository;

        }
        
        [HttpGet(Name = "GetParkinglots")]
        public async Task<ActionResult<ParkinglotServices[]>> GetParkinglots()
        {
            try
            {
                var result = await _parkinglotRepository.GetParkinglots();

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