using System.ComponentModel.DataAnnotations;

namespace InventoryTrackerAPI.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }

        [Range(0, 1000)]
        public int Quantity { get; set; }

        [Range(0, 10000)]
        public double Price { get; set; }

        public int CategoryId { get; set; }   
        public int SupplierId { get; set; }   
    }
}