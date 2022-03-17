using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Entity.ModelsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService usertService, ILogger<UserController> logger)
        {
            this._userService = usertService;
            this._logger = logger;
        }

        //api/user

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserInfoFromLogined()
        {
            var response = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);
            //return new ObjectResult(response);
            return ActionResultInstance(response);

        }

        // GET: api/User/5
        [HttpGet("{userName}", Name = "GetUserLogin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserLogin(string userName)
        {
            var response = await _userService.GetUserByNameAsync(userName);
            //return new ObjectResult(response);
            return ActionResultInstance(response);

        }


        [HttpPost]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var response = await _userService.CreateUserAsync(userForRegisterDto);
            return ActionResultInstance(response);
        }


        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var response = _userService.GetAllRoles();
            return ActionResultInstance(response);
        }
    }
}
