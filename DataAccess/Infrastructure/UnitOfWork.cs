using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
