using System;
using Data.Concretes;

namespace Data.Abstracts
{
    public interface IUnitOfWorkSecondDb : IUnitOfWork<SecondDbContext>
    {
        ICustomerRepository CustomerRepository { get; }
    }
}
