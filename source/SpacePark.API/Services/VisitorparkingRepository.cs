using Microsoft.EntityFrameworkCore;
using SpacePark.API.Models;
using SpacePark.source.Context;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class VisitorparkingRepository : Repository, IVisitorparkingRepository
    {
        public VisitorparkingRepository(SpaceParkContext context) : base(context) { }
        public async Task<VisitorParking[]> GetVisitorParkings()
        {
            IQueryable<VisitorParking> query = _context.VisitorParkings.OrderBy(visitorparking => visitorparking.VistorParkingID);

            return await query.ToArrayAsync();
        }
    }
}
