using System;
using System.Threading.Tasks;
using Data.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Data.Concretes
{
    public abstract class UnitOfWork<TContext> : IDisposable, IUnitOfWork<TContext> where TContext : DbContext//, new()
    {
        private readonly DbContext _context;
        public UnitOfWork(TContext context)
        {
            _context = context;
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                GC.SuppressFinalize(this);
            }

        }
    }
}
