using SpacePark.API.Models;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public interface IVisitorparkingRepository : IRepository
    {
        Task<VisitorParking[]> GetVisitorParkings();
    }
}
