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

    }
}
