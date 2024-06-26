using ETicaretAPI.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _manager;

        public ProductsController(IProductService manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var product = _manager.GetProducts();
            return Ok(product);
        }
    }
}
