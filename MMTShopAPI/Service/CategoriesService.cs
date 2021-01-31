using Microsoft.EntityFrameworkCore;
using MMTShopAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTShopAPI.Service
{
    public class CategoriesService : ICategoriesService
    {
        private readonly AppDBContext _context;

        public CategoriesService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Categories>> GetCategoriesAsync()
        {
            List<Categories> categories = new List<Categories>();
            var result = await _context.Categories.FromSqlRaw(@"exec sp_getAllCategories").ToListAsync();

            foreach (var row in result)
            {
                categories.Add(new Categories
                {
                    ID = row.ID,
                    Name = row.Name
                });

            }
            return categories;
        }
    }
}
