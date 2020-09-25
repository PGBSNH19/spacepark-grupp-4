using SpacePark.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public interface ISpaceshipRepository : IRepository
    {
        Spaceship GetSpaceship(string name);
        Task<List<Spaceship>> GetSpaceships();
        Task<Spaceship> AddSpaceship(Spaceship spaceship);
    }
}
