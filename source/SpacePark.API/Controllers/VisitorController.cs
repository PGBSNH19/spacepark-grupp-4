using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;

namespace SpacePark.API.Controllers
{
    [ApiKeyAuth]
    [Route(API/v1.0/"[controller]"")]
    [ApiController]

    public class VisitorController : ControllerBase
    {
        private readonly IVisitorsController _visitorsController;

        public VisitorController(IVisitorsController visitorsController)
        {
            _visitorsController = visitorsController;
        }
        [HttpGet(Name = "GetVisitors")]
        public async Task<ActionResult<VisitorController[]>> GetVisitors()
        {
            try
            {
                var result = await _visitorsController.GetVisitors();

                if(result.IsNullOrEmpty()) 
                    return NotFound();

                return Ok(result);

            }
            catch (Exception exeption)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {exeption.Message}");
            }
        }
    }
}