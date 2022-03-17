using System;
using System.Threading.Tasks;
using Data.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Data.Concretes
{
 

    public class UnitOfWorkFirstDb : UnitOfWork<FirstDbContext>, IUnitOfWorkFirstDb
    {
        private readonly FirstDbContext _context;
        private IProductRepository _productRepository;
        private IUserRefreshTokenRepository _userRefreshTokenRepository;
        public UnitOfWorkFirstDb(FirstDbContext context) : base(context)
        {
            this._context = context;
        }
        public IProductRepository ProductRepository => _productRepository = _productRepository ?? new ProductRepository(_context);
        //public IProductRepository ProductRepository
        //{
        //    get
        //    {
        //        return this._productRepository ?? (this._productRepository = new ProductRepository(_context));
        //    }
        //}



        public IUserRefreshTokenRepository UserRefreshTokenRepository => _userRefreshTokenRepository = _userRefreshTokenRepository ?? new UserRefreshTokenRepository(_context);
    }
}
