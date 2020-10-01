using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpacePark.API.Models;
using SpacePark.source.Context;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class SpaceportRepository : Repository, ISpaceportRepository
    {
        public SpaceportRepository(SpaceParkContext context, ILogger<SpaceportRepository> logger) : base(context, logger) { }

        public async Task<Spaceport[]> GetSpaceports()
        {
            IQueryable<Spaceport> query = _context.SpacePorts.OrderBy(spaceport => spaceport.SpacePortID);
            _logger.LogInformation($"[LOG] Requesting all Spaceports");
            return await query.ToArrayAsync();
        }
    }
}
