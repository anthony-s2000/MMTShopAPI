using System.ComponentModel.DataAnnotations;

namespace MMTShopAPI.Models
{
    public class Categories
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
