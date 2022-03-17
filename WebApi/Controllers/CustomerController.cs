using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Abstracts;
using Entity.Models;
using Entity.ModelsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "CustomerManeger,Admin")]
    public class CustomerController : CustomBaseController
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;


        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            this._customerService = customerService;
            this._logger = logger;
        }
        // GET: api/Customer
        //[HttpGet(Name = "Get")]
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var response = await _customerService.GetAllAsync();

            return ActionResultInstance(response);
            //return new ObjectResult(response) {  StatusCode= response.StatusCode};
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var response = await _customerService.GetByIdAsync(id);
            return ActionResultInstance(response);
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDto dto)
        {
            dto.LastUpdateUser = HttpContext.User.Identity.Name;
            var response = await _customerService.CreateAsync(dto);
            return ActionResultInstance(response);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDto dto)
        {
            dto.LastUpdateUser = HttpContext.User.Identity.Name;
            var response = await _customerService.Update(dto);
            return ActionResultInstance(response);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            CustomerDto dto = new CustomerDto { Id = id };
            var response = await _customerService.Delete(dto);
            return ActionResultInstance(response);
        }

    }
}
