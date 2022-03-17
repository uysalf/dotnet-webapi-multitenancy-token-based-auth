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
    [Authorize(Roles = "ProductManager,Admin")]
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;


        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this._productService = productService;
            this._logger = logger;
        }
        // GET: api/Product
        //[HttpGet(Name = "Get")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _productService.GetAllAsync();

            return ActionResultInstance(response);
            //return new ObjectResult(response) {  StatusCode= response.StatusCode};
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = await _productService.GetByIdAsync(id);
            return ActionResultInstance(response);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto dto)
        {
            dto.LastUpdateUser = HttpContext.User.Identity.Name;
            var response = await _productService.CreateAsync(dto);
            return ActionResultInstance(response);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductDto dto)
        {
            dto.LastUpdateUser = HttpContext.User.Identity.Name;
            var response = await _productService.Update(dto);
            return ActionResultInstance(response);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ProductDto dto = new ProductDto { Id = id };
            var response = await _productService.Delete(dto);
            return ActionResultInstance(response);
        }

    }
}
