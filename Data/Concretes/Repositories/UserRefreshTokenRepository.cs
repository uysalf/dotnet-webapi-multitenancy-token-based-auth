using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Abstracts;
using Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Data.Concretes
{
    public class UserRefreshTokenRepository : GenericRepository<UserRefreshToken>, IUserRefreshTokenRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<UserRefreshToken> _dbSet;
        public UserRefreshTokenRepository(DbContext context) : base(context)
        {
            //_context = (_context ?? (FirstDbContext)context);
            _context = context;
            _dbSet = context.Set<UserRefreshToken>();
        }
    }
}
