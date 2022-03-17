using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entity.Models;
using Entity.ModelsDtos;

namespace Business.Abstracts
{
    public interface ICustomerService
    {
        Task<Response<CustomerDto>> CreateAsync(CustomerDto entity);
        Task<Response<CustomerDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();


        Response<IEnumerable<CustomerDto>> FindByCondition(Expression<Func<Customer, bool>> expression);

        Task<Response<CustomerDto>> Update(CustomerDto entity);
        Task<Response<NoDataDto>> Delete(CustomerDto entity);
    }
}
