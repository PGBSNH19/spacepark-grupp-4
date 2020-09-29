using Microsoft.EntityFrameworkCore;
using SpacePark.API.Models;
using SpacePark.source.Context;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class ParkinglotRepository : Repository, IParkinglotRepository
    {
        public ParkinglotRepository(SpaceParkContext context) : base(context) { }
        public async Task<Parkinglot[]> GetParkinglots()
        {
            IQueryable<Parkinglot> query = _context.ParkingLots.OrderBy(parkinglot => parkinglot.ParkingLotID);

            return await query.ToArrayAsync();
        }

        public async Task<Parkinglot> GetAvailableParking()
        {
            var availableParking = 
                _context.ParkingLots
                .Where(p => p.Status == ParkingStatus.Available);

            if (availableParking == null)
                return null;
            return await availableParking.FirstOrDefaultAsync();

        }

        public async Task<Parkinglot> GetVisitorParkingspot( int visitorId)
        {
            var parkingspot = _context.ParkingLots.Where(p => p.VisitorID == visitorId).FirstOrDefaultAsync();
            if (parkingspot == null)
                return null;
            return await parkingspot;
        }
    }
}
