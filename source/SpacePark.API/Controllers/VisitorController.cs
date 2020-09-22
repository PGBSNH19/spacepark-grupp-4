using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacePark.API.Models;
using SpacePark.API.Services;
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

        public VisitorController(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }
        [HttpGet(Name = "GetVisitors")]
        public async Task<ActionResult<Visitor>> GetVisitors()
        {
            try
            {
                var result = await _visitorRepository.GetVisitors();

                if (result == null)
                    return NotFound();

                return Ok(result);

            }
            catch (Exception exeption)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {exeption.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Visitor>> PostVisitor(Visitor visitor)
        {
            return Ok(await _visitorRepository.AddVisitor(visitor));
        }

        [HttpDelete]
        public async Task<ActionResult<Visitor>> DeleteVisitor(string visitorname)
        {
            var allVisitors = await _visitorRepository.GetVisitors();
            var visitorToRemove = allVisitors.Where(x => x.Name == visitorname);

            if (visitorname == null)
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
