using System;
using Data.Concretes;

namespace Data.Abstracts
{
    public interface IUnitOfWorkFirstDb : IUnitOfWork<FirstDbContext>
    {
        IProductRepository ProductRepository { get; }
        IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
    }
}
