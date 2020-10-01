using SpacePark.source.Context;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class Repository : IRepository
    {
        protected readonly SpaceParkContext _context;
        public Repository(SpaceParkContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
