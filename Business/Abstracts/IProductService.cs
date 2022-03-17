using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entity.Models;
using Entity.ModelsDtos;

namespace Business.Abstracts
{
    public interface IProductService
    {
        Task<Response<ProductDto>> CreateAsync(ProductDto entity);
        Task<Response<ProductDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<ProductDto>>> GetAllAsync();


        Response<IEnumerable<ProductDto>> FindByCondition(Expression<Func<Product, bool>> expression);

        Task<Response<ProductDto>> Update(ProductDto entity);
        Task<Response<NoDataDto>> Delete(ProductDto entity);
    }
}
