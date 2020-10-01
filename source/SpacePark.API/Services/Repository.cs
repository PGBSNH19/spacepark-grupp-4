using Microsoft.Extensions.Logging;
using SpacePark.source.Context;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public class Repository : IRepository
    {
        protected readonly SpaceParkContext _context;
        protected readonly ILogger<Repository> _logger;

        public Repository(SpaceParkContext context, ILogger<Repository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"[LOG] Added object of type{entity.GetType()}");
            _context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"[LOG] Deleted object of type{entity.GetType()}");
            _context.Remove(entity);
        }
        public async Task<bool> Save()
        {
            _logger.LogInformation($"[LOG] Saving changes in DB");
            return (await _context.SaveChangesAsync()) >= 0;
        }
        public void Update<T>(T entity) where T : class
        {
            _logger.LogInformation($"[LOG] Update object of type {entity.GetType()}");
            _context.Update(entity);
        }
    }
}
