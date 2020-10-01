using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpacePark.API.Models;
using SpacePark.source.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class VisitorRepository : Repository, IVisitorRepository
    {

        public VisitorRepository(SpaceParkContext context, ILogger<VisitorRepository> logger) : base(context, logger)
        {


        }
        public Visitor GetVisitor(string name)
        {
            var visitor = _context.Visitors.Where(x => x.Name == name).First();
            _logger.LogInformation($"[LOG] Get visitor with name {name}");
            return visitor;
        }
        public async Task<List<Visitor>> GetVisitors()
        {
            var visitors = await _context.Visitors.ToListAsync();
            _logger.LogInformation($"[LOG] Request all visitors");
            return visitors;
        }
    }
}
