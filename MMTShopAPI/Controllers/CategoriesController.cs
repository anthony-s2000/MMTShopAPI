using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MMTShopAPI.Models;
using MMTShopAPI.Service;

namespace MMTShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _service;

        public CategoriesController(ICategoriesService service)
        {
            _service = service;
        }


        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<Categories>> GetCategoriesAsync()
        {
            try
            {
                var result = await _service.GetCategoriesAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
