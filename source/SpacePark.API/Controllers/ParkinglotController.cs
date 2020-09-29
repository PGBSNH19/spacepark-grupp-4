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
    public class ParkinglotController : ControllerBase
    {
        private readonly IParkinglotRepository _parkinglotRepository;
        public ParkinglotController(IParkinglotRepository parkinglotRepository)
        {
            _parkinglotRepository = parkinglotRepository;

        }

        [HttpGet(Name = "GetParkinglots")]
        public async Task<ActionResult<Parkinglot[]>> GetParkinglots()
        {
            try
            {
                var result = await _parkinglotRepository.GetParkinglots();

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {exception.Message}");
            }
        }

        [HttpGet]
        [Route("Check")]
        public async Task<ActionResult<bool>> GetAvailableParking()
        {
            try
            {
                var availableParking = await _parkinglotRepository
                    .GetAvailableParking();
                if (availableParking == null)
                    return NotFound($"Can't find any available parkings");
                return Ok(true);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");

            }
        }

        [HttpPut]
        [Route("Checkin")]
        public async Task<ActionResult<Parkinglot>> CheckInShip(Visitor visitor)
        {
            try
            {
                var availableParking = await _parkinglotRepository
                    .GetAvailableParking();
                if (availableParking == null)
                    return NotFound($"Can't find any available parkings");
                availableParking.Status = ParkingStatus.Occupied;
                availableParking.VisitorID = visitor.VisitorID;
                _parkinglotRepository.Update(availableParking);
                if (await _parkinglotRepository.Save())
                    return NoContent();
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("Checkout/id")]
        public async Task<ActionResult<Parkinglot>> CheckOutShip(int id)
        {
            try
            {
                var visitorParking = await _parkinglotRepository
                    .GetVisitorParkingspot(id);
                if (visitorParking == null)
                    return NotFound($"Can't find any parking with visitor id: {id}");
                visitorParking.Status = ParkingStatus.Available;
                visitorParking.VisitorID = null;
                _parkinglotRepository.Update(visitorParking);
                if (await _parkinglotRepository.Save())
                    return NoContent();
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");

            }
            return BadRequest();
        }
    }
}
