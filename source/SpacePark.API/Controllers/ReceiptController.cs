using Microsoft.AspNetCore.Mvc;

namespace SpacePark.API.Controllers
{
    [ApiKeyAuth]
    [Route(API/v1.0/"[controller]"")]
    [ApiController]
    public class ReceiptController :ControllerBase
    {
        private readonly IReceiptController _receiptRepository;

        public ReceiptController(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }
    }
}