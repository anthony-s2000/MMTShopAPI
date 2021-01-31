using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MMTShopAPI.Models;
using MMTShopAPI.Service;

namespace MMTShopAPI.Controllers
{
    [ApiController]
    

    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: api/products/all
        [Route("api/[controller]/all")]
        [HttpGet]
        public async Task<ActionResult<Products>> GetAllProducts()
        {
            try
            {
                var result = await _service.GetAllProductsAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/products/featured
        [Route("api/[controller]/featured")]
        [HttpGet]
        public async Task<ActionResult<Products>> GetFeaturedProducts()
        {
            try
            {
                var result = await _service.GetFeaturedProductsAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
