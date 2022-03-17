using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Data.Abstracts;
using Entity.Models;
using Entity.ModelsDtos;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class UserRefreshTokenService : IUserRefreshTokenService
    {
        private readonly IUnitOfWorkFirstDb _unitOfWorkFirst;
        private readonly IMapper _mapper;
        public UserRefreshTokenService(IUnitOfWorkFirstDb unitOfWorkFirst, IMapper mapper)
        {
            this._unitOfWorkFirst = unitOfWorkFirst;
            this._mapper = mapper;
        }

        public async Task<UserRefreshToken> CreateAsync(UserRefreshToken entity)
        {
            await _unitOfWorkFirst.UserRefreshTokenRepository.CreateAsync(entity);
            await _unitOfWorkFirst.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<UserRefreshToken>> FindByCondition(Expression<Func<UserRefreshToken, bool>> expression)
        {
            var list = await _unitOfWorkFirst.UserRefreshTokenRepository.FindByCondition(expression).ToListAsync();
            return list;
        }

        public async Task<UserRefreshToken> Update(UserRefreshToken entity)
        {
            var _refToken =_unitOfWorkFirst.UserRefreshTokenRepository.GetByIdAsync(entity.Id);
            if (_refToken != null)
            {
                _refToken.Result.Code = entity.Code;
            }
            await _unitOfWorkFirst.CommitAsync();

            return entity;
        }

    }
}
