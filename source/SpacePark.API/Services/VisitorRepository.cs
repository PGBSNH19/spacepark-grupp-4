using Microsoft.EntityFrameworkCore;
using SpacePark.API.Models;
using SpacePark.source.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class VisitorRepository : Repository, IVisitorRepository
    {
        public VisitorRepository(SpaceParkContext context) : base(context)
        {
        }
        public Visitor GetVisitor(string name)
        {
            var visitor = _context.Visitors.Where(x => x.Name == name).First();
            return visitor;
        }
        public async Task<List<Visitor>> GetVisitors()
        {
            var visitors = await _context.Visitors.ToListAsync();
            return visitors;
        }
    }
}
