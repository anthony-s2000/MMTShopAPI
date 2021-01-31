using System.Collections.Generic;
using System.Threading.Tasks;
using MMTShopAPI.Models;


namespace MMTShopAPI.Service
{
    public interface IProductService
    {
        Task<List<Products>> GetAllProductsAsync();

        Task<List<Products>> GetFeaturedProductsAsync();

    }
}
