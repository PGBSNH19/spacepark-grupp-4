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
        //private readonly SpaceParkContext _context;

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

        //POST:     api/v1.0/visitors
        [HttpPost(Name = "PostVisitor")]
        public async Task<ActionResult<Visitor>> PostVisitor(Visitor visitor)
        {
            try
            {
                _visitorRepository.Add(visitor);
                if (await _visitorRepository.Save())
                    return Created($"api/v1.0/visitors/{visitor.VisitorID}", visitor);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
           
            return BadRequest();
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
