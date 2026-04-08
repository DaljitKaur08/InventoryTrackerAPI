namespace InventoryTrackerAPI.DTOs
{
    public class OrderDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}