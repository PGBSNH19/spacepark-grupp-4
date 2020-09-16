using SpacePark.API.Models;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public interface IVisitorRepository : IRepository
    {
        Task<Visitor[]> GetVisitors();
        Task<Visitor> AddVisitor(Visitor visitor);

    }
}
