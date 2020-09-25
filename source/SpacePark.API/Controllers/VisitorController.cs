using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpacePark.API.Models;
using SpacePark.API.Services;
using SpacePark.source.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark.API.Controllers
{
    [Route("API/v1.0/[controller]")]
    [ApiController]

    public class VisitorController : ControllerBase
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly SpaceParkContext _context;

        public VisitorController(IVisitorRepository visitorRepository, SpaceParkContext context)
        {
            _visitorRepository = visitorRepository;
            _context = context;
        }
        [HttpGet(Name = "GetVisitors")]
        public async Task<ActionResult<Visitor>> GetVisitors()
        {
            try
            {
                var result = await _visitorRepository.GetVisitors();

                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }

            }
            catch (Exception exeption)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {exeption.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Visitor>> PostVisitor(Visitor visitor)
        {
            await ParkShip(visitor);
            return Ok(await _visitorRepository.AddVisitor(visitor));
        }

        public async Task<VisitorParking[]> GetVisitorParkings()
        {
            IQueryable<VisitorParking> query = _context.VisitorParkings.OrderBy(visitorparking => visitorparking.VistorParkingID);

            return await query.ToArrayAsync();
        }
        public async Task<ActionResult> ParkShip(Visitor visitor)
        {
            var parkings = GetVisitorParkings();
            var parking = parkings.Result.Where(x => x.Parkinglot.Status == ParkingStatus.Available).FirstOrDefault();
            // parking.Parkinglot.Status = ParkingStatus.Occupied;
            // parking.VisitorID= visitor.VisitorID;

            var parkinglot = _context.ParkingLots.Where(x => x.ParkingLotID == parking.ParkingLotID).FirstOrDefault();
            //parkinglot.Status= ParkingStatus.Occupied;

            var visitorparking = new VisitorParking
            {
                VisitorID = visitor.VisitorID,
                ParkingLotID = parkinglot.ParkingLotID,
                DateOfEntry = DateTime.Now
            };

            await _context.VisitorParkings.AddAsync(visitorparking);
            return Ok(await _context.SaveChangesAsync());
        }
        [HttpDelete("{name}")]
        public async Task<ActionResult<Visitor>> DeleteVisitor(string name)
        {

            var visitorToRemove = _visitorRepository.GetVisitor(name);

            if (visitorToRemove == null)
            {
                return NotFound();
            }
            else
            {
                _visitorRepository.Delete(visitorToRemove);
                if (await _visitorRepository.Save())
                {
                    return NoContent();
                }

            }
            return null;
        }
    }
}
