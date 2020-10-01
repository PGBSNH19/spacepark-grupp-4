using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpacePark.API.Models;
using SpacePark.source.Context;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class ParkinglotRepository : Repository, IParkinglotRepository
    {
        public ParkinglotRepository(SpaceParkContext context, ILogger<ParkinglotRepository> logger) : base(context, logger) { }
        public async Task<Parkinglot[]> GetParkinglots()
        {
            IQueryable<Parkinglot> query = _context.ParkingLots.OrderBy(parkinglot => parkinglot.ParkingLotID);
            _logger.LogInformation($"[LOG] Requesting all parkings");

            return await query.ToArrayAsync();
        }

        public async Task<Parkinglot> GetAvailableParking()
        {
            var availableParking = 
                _context.ParkingLots
                .Where(p => p.Status == ParkingStatus.Available);

            if (availableParking == null)
            {
                _logger.LogInformation($"[LOG] Requested available parkings, all parkings is occupied");
                return null;

            }
            _logger.LogInformation($"[LOG ]Reguested first available parking from DB");
            return await availableParking.FirstOrDefaultAsync();

        }

        public async Task<Parkinglot> GetVisitorParkingspot( int visitorId)
        {
            var parkingspot = _context.ParkingLots.Where(p => p.VisitorID == visitorId).FirstOrDefaultAsync();
            if (parkingspot == null)
            {
                _logger.LogInformation($"[LOG] There were no parking with visitor id: {visitorId}");
                return null;
            }
            
            _logger.LogInformation($"[LOG] Requested parking with visitor id: {visitorId}");
            return await parkingspot;
        }
    }
}
