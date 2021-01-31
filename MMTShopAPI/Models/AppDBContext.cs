using Microsoft.EntityFrameworkCore;


namespace MMTShopAPI.Models
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }

        public DbSet<Categories> Categories { get; set; }


    }
}
