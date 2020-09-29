using Microsoft.EntityFrameworkCore;
using SpacePark.API.Models;
using SpacePark.source.Context;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class SpaceportRepository : Repository, ISpaceportRepository
    {
        public SpaceportRepository(SpaceParkContext context) : base(context) { }

        public async Task<Spaceport[]> GetSpaceports()
        {
            IQueryable<Spaceport> query = _context.SpacePorts.OrderBy(spaceport => spaceport.SpacePortID);

            return await query.ToArrayAsync();
        }
    }
}
