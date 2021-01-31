using MMTShopAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTShopAPI.Service
{
    public interface ICategoriesService
    {
        Task<List<Categories>> GetCategoriesAsync();
    }
}
