using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MarketDbContext _context;
        private Dictionary<string, object> _repositories;

        public UnitOfWork(MarketDbContext context)
        {
            _context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            string lTypeName = typeof(TEntity).FullName;

            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            if (!_repositories.ContainsKey(lTypeName))
                _repositories.Add(lTypeName, new Repository<TEntity>(_context));

            return (Repository<TEntity>)_repositories[lTypeName];
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        #region Dispose pattern

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
