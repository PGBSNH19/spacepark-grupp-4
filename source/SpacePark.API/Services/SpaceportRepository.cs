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

        public async Task<Spaceport> PostSpacePort()
        {
            var spacePortData = _context.SpacePorts.FirstOrDefault();

            if (spacePortData == null)
            {

                var spacePort = new Spaceport
                {
                    Parkinglots = new Parkinglot[5],
                    Status = PortStatus.Open
                };
                await _context.SpacePorts.AddAsync(spacePort);
                await _context.SaveChangesAsync();
                return spacePort;
            }
            return null;
        }
    }
}
