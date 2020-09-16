using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using SpacePark.API.Models;
namespace SpacePark.API.Controllers
{
    [ApiKeyAuth]
    [Route(API/v1.0/"[controller]"")]
    [ApiController]

    public class VisitorController : ControllerBase
    {
        private readonly IVisitorController _visitorController;

        public VisitorController(IVisitorController visitorController)
        {
            _visitorController = visitorController;
        }
        [HttpGet(Name = "GetVisitors")]
        public async Task<ActionResult<VisitorController[]>> GetVisitors()
        {
            try
            {
                var result = await _visitorController.GetVisitors();

                if(result.IsNullOrEmpty()) 
                    return NotFound();

                return Ok(result);

            }
            catch (Exception exeption)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {exeption.Message}");
            }
        }

        [HttpPost(Name ="PostVisitor")]
        public async Task<ActionResult<VisitorController[]>> PostVisitor(Visitor visitor)
        {

            return Ok(await _visitorController)
        }
    }
}
