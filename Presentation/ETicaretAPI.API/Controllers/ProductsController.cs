using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 1",
                    Price = 20,
                    CreatedDate = DateTime.UtcNow,
                    Stock = 10
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 2",
                    Price = 10,
                    CreatedDate = DateTime.UtcNow,
                    Stock = 5
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 3",
                    Price = 50,
                    CreatedDate = DateTime.UtcNow,
                    Stock = 15
                }
            });

            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
