using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacePark.API.Models;
using SpacePark.API.Services;

namespace SpacePark.API.Controllers
{
    [Route("API/v1.0/[controller]")]
    [ApiController]
    public class ReceiptController :ControllerBase
    {
        private readonly IReceiptRepository _receiptRepository;

        public ReceiptController(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        [HttpGet(Name = "GetReceipts")]
        public async Task<ActionResult<Receipt[]>> GetReceipts()
        {
            try
            {
                var result = await _receiptRepository.GetReceipts();

                if(result == null) return NotFound();
                
                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {exception.Message}");
            }
        }
    }
}