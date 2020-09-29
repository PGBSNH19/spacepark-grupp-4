using SpacePark.API.Services;
using System.Threading.Tasks;

namespace SpacePark.API.Models
{
    public interface ISpaceportRepository : IRepository
    {
        Task<Spaceport[]> GetSpaceports();
    }
}
