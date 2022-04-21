using Microsoft.EntityFrameworkCore;
using myhealthhub.api.Interfaces;
using myhealthhub.api.Models;

namespace myhealthhub.api.Services
{
    public class DatabaseManager : IDatabaseManager
    {
        private readonly MyHealthHubContext _context;

        public DatabaseManager(MyHealthHubContext context)
        {
            _context = context;
        }

        public async Task Create<T>(T entity) where T : class
        {        
            Type type = entity.GetType();
            await _context.Set<T>().AddAsync(entity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            } 
        }
    }
}