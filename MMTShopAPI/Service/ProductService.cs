using System.Collections.Generic;
using System.Threading.Tasks;
using MMTShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MMTShopAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext _context;

        public ProductService(AppDBContext context)
        {
            _context = context;
        }


        public async Task<List<Products>> GetAllProductsAsync()
        {
            List<Products> products = new List<Products>();
            var result = await _context.Products.FromSqlRaw(@"exec sp_getAllProducts").ToListAsync();

            foreach (var row in result)
            {
                products.Add(new Products
                {
                    Sku = row.Sku,
                    Name = row.Name,
                    Description = row.Description,
                    Price = row.Price,
                    CategoryId = row.CategoryId
                });

            }
            return products;
        }


        public async Task<List<Products>> GetFeaturedProductsAsync()
        {
            List<Products> products = new List<Products>();
            
            var result = await _context.Products.FromSqlRaw(@"exec sp_getFeaturedProducts").ToListAsync();

            foreach (var row in result)
            {
                products.Add(new Products
                {
                    Sku = row.Sku,
                    Name = row.Name,
                    Description = row.Description,
                    Price = row.Price,
                    CategoryId = row.CategoryId
                });

            }
            return products;
        }

    }

}
