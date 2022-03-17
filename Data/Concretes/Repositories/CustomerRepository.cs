using System;
using Data.Abstracts;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Concretes
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Customer> _dbSet;
        public CustomerRepository(DbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Customer>();
        }
    }
}
