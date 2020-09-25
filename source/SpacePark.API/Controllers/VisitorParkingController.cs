using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpacePark.API.Models;
using SpacePark.API.Services;
using SpacePark.source.Context;

namespace SpacePark.API.Controllers
{
    [Route("API/v1.0/[controller]")]
    [ApiController]
    public class VisitorParkingController : ControllerBase
    {
        private IVisitorparkingRepository _visitorParking;
        public VisitorParkingController(IVisitorparkingRepository visitorParking)
        {
            _visitorParking = visitorParking;
        }
        [HttpPost("VisitorParking")]
        public void AddVisitorParking(Visitor visitor)
        {
            _visitorParking.ParkShip(visitor);
        }
    }
}