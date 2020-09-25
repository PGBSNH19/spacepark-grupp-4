using SpacePark.API.Models;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public interface IVisitorparkingRepository : IRepository
    {
        Task<VisitorParking[]> GetVisitorParkings();
        void ParkShip(Visitor visitor);
    }
}
