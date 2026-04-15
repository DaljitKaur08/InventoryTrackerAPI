using System.ComponentModel.DataAnnotations;

namespace InventoryTrackerAPI.DTOs
{
    public class CategoryDTO
    {
        [Required]   
        public string CategoryName { get; set; }
    }
}