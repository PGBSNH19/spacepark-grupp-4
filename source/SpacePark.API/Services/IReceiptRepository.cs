using SpacePark.API.Models;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public interface IReceiptRepository : IRepository
    {
        Task<Receipt[]> GetReceipts();
    }
}
