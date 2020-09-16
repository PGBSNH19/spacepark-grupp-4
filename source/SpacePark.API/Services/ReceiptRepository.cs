using SpacePark.API.Models;
using SpacePark.source.Context;
using System;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class ReceiptRepository : Repository, IReceiptRepository
    {
        public ReceiptRepository(SpaceParkContext context) : base(context) { }
        public Task<Receipt[]> GetReceipts()
        {
            throw new NotImplementedException();
        }
    }
}
