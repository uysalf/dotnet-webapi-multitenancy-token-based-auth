using System;
using System.Threading.Tasks;
using Data.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Data.Abstracts
{
    public interface IUnitOfWork<TContext> where TContext : DbContext, IDisposable
    {
        //IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int Commit();
        Task<int> CommitAsync();
    }
    //public interface IUnitOfWorkFirst<FirstDbContext> :  IUnitOfWork<FirstDbContext>
    //{
    //    IProductRepository productRepository { get; }
    //    IUserRefreshTokenRepository userRefreshTokenRepository { get; }
    //}

    //public interface IUnitOfWorkSecond<SecondDbContext> :  IUnitOfWork<SecondDbContext>
    //{
    //    ICustomerRepository customerRepository { get; }
    //}
}
