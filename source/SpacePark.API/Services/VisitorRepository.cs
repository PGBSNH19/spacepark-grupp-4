using Microsoft.EntityFrameworkCore;
using SpacePark.API.Models;
using SpacePark.source.Context;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class VisitorRepository : Repository, IVisitorRepository
    {
        public VisitorRepository(SpaceParkContext context) : base(context)
        { }
        public async Task<Visitor[]> GetVisitors()
        {
            IQueryable<Visitor> query = _context.Visitors.OrderBy(visitor => visitor.VisitorID);

            return await query.ToArrayAsync();
        }
    }
}
