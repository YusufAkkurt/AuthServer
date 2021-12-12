using AuthServer.Core.Dtos;
using AuthServer.Core.Models;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IService<Product, ProductDto> _productService;

        public ProductsController(IService<Product, ProductDto> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => ActionResultInstance(await _productService.GetAllAsync());
        
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto) => ActionResultInstance(await _productService.AddAsync(productDto));

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto) => ActionResultInstance(await _productService.UpdateAsync(productDto, productDto.Id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => ActionResultInstance(await _productService.RemoveAsync(id));
    }
}
