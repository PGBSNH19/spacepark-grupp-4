using SpacePark.API.Models;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public interface IParkinglotRepository : IRepository
    {
        Task<Parkinglot[]> GetParkinglots();
    }
}
