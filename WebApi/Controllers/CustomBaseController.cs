using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.ModelsDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
 
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
