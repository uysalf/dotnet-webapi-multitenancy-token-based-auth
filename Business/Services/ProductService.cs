using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstracts;
using Data.Abstracts;
using Data.Concretes;
using Entity.Models;
using Entity.ModelsDtos;
using AutoMapper;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWorkFirstDb _unitOfWorkFirst;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWorkFirstDb unitOfWorkFirst, IMapper mapper)
        {
            this._unitOfWorkFirst = unitOfWorkFirst;
            this._mapper = mapper;
        }

        public async Task<Response<ProductDto>> CreateAsync(ProductDto dto)
        {
            Product entity = _mapper.Map<Product>(dto);
            entity.CreateUser = dto.LastUpdateUser;
            await _unitOfWorkFirst.ProductRepository.CreateAsync(entity);
            await _unitOfWorkFirst.CommitAsync();
            var retModel = _mapper.Map<ProductDto>(entity);
            return Response<ProductDto>.Success(retModel, 200);
        }

        public async Task<Response<ProductDto>> GetByIdAsync(int id)
        {
            var entity = await _unitOfWorkFirst.ProductRepository.GetByIdAsync(id);
            if (entity == null)
            {
                var errors = new List<string>();
                errors.Add("ürün id'si bulunamadı");
                return Response<ProductDto>.Fail(404, errors);
            }
            var retModel = _mapper.Map<ProductDto>(entity);
            return Response<ProductDto>.Success(retModel, 200);
        }


        public async Task<Response<IEnumerable<ProductDto>>> GetAllAsync()
        {
            var entities = await _unitOfWorkFirst.ProductRepository.GetAllAsync();
            var retModel = _mapper.Map<List<ProductDto>>(entities);
            return Response<IEnumerable<ProductDto>>.Success(retModel, 200);
        }

        public Response<IEnumerable<ProductDto>> FindByCondition(Expression<Func<Product, bool>> expression)
        {
            var list = _unitOfWorkFirst.ProductRepository.FindByCondition(expression);
            var retModel = _mapper.Map<List<ProductDto>>(list.ToListAsync());
            return Response<IEnumerable<ProductDto>>.Success(retModel, 200);
        }


        public async Task<Response<ProductDto>> Update(ProductDto dto)
        {
            var isExistEntity = await _unitOfWorkFirst.ProductRepository.GetByIdAsync(dto.Id);
            if (isExistEntity == null)
            {
                var errors = new List<string>();
                errors.Add("Güncellem yapılacak ürün id'si bulunamadı");
                return Response<ProductDto>.Fail(404, errors);
            }

            isExistEntity.Name = dto.Name;
            isExistEntity.Description = dto.Description;
            isExistEntity.Price = dto.Price;
            isExistEntity.LastUpdateUser = dto.LastUpdateUser;
            isExistEntity.LastUpdate = DateTime.Now;
            _unitOfWorkFirst.ProductRepository.Update(isExistEntity);
            await _unitOfWorkFirst.CommitAsync();
            var retModel = _mapper.Map<ProductDto>(isExistEntity);
            return Response<ProductDto>.Success(retModel, 200);
        }


        public async Task<Response<NoDataDto>> Delete(ProductDto dto)
        {
            Product entity = _mapper.Map<Product>(dto);
            var isExistEntity = await _unitOfWorkFirst.ProductRepository.GetByIdAsync(entity.Id);
            if (isExistEntity == null)
            {
                var errors = new List<string>();
                errors.Add("Silinecek ürünün id'si bulunamadı");
                return Response<NoDataDto>.Fail(404, errors);
            }
            _unitOfWorkFirst.ProductRepository.Delete(isExistEntity);
            await _unitOfWorkFirst.CommitAsync();
            return Response<NoDataDto>.Success(null, 200);

        }
    }
}
