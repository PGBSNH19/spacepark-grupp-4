using SpacePark.API.Models;
using SpacePark.source.Context;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SpacePark.API.Services
{
    public class SpaceshipRepository : Repository, ISpaceshipRepository
    {
        public SpaceshipRepository(SpaceParkContext context) : base(context)
        { }

        public Spaceship GetSpaceship(string name)
        {
            var spaceship = _context.Spaceships.Where(x => x.Name == name).First();
            return spaceship;
        }

        public Task<List<Spaceship>> GetSpaceships()
        {
            var spaceships = _context.Spaceships.ToListAsync();
            return spaceships;
        }
        public async Task<Spaceship> AddSpaceship(Spaceship newSpaceship)
        {
            await _context.Spaceships.AddAsync(newSpaceship);
            await _context.SaveChangesAsync();

            return newSpaceship;
        }
    }
}
