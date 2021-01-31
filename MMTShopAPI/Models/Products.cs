using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMTShopAPI.Models
{
    public class Products
    {
        [Key]
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,4)")] 
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
