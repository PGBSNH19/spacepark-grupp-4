using SpacePark.API.Models;
using SpacePark.source.Context;
using System;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class SpaceshipRepository : Repository, ISpaceshipRepository
    {
        public SpaceshipRepository(SpaceParkContext context) : base(context)
        { }
        public Task<Spaceship> GetSpaceship()
        {
            throw new NotImplementedException();

        }

        public Task<Spaceship[]> GetSpaceships()
        {
            throw new NotImplementedException();
        }
    }
}
