using Microsoft.EntityFrameworkCore;
using SpacePark.API.Models;
using SpacePark.source.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class VisitorRepository : Repository, IVisitorRepository
    {

        public VisitorRepository(SpaceParkContext context) : base(context)
        {


        }
        public async Task<List<Visitor>> GetVisitors()
        {
            var visitors = await _context.Visitors.ToListAsync();
            return visitors;
        }
        public async Task<Visitor> AddVisitor(Visitor newVisitor)
        {
            await _context.Visitors.AddAsync(newVisitor);
            await _context.SaveChangesAsync();

            return newVisitor;
        }


    }
}
