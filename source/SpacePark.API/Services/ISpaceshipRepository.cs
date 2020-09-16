using SpacePark.API.Models;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public interface ISpaceshipRepository
    {
        Task<Spaceship[]> GetSpaceships();
        Task<Spaceship> GetSpaceship();
    }
}
