using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.ModelsDtos;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<Response<UserDto>> CreateUserAsync(UserForRegisterDto userForRegisterDto);

        Task<Response<UserDto>> GetUserByNameAsync(string userName);
        Response<List<string>> GetAllRoles();
    }
}
