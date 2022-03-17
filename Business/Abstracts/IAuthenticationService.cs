using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Entity.Models;
using Entity.ModelsDtos;

namespace Business.Abstracts
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> LoginAsync(UserForLoginDto entity);
        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);
    }
}
