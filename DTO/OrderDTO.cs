namespace DynamicStore.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int StoreId { get; set; }
        public ICollection<OrderItemDTO> OrderItems { get; set; }
    }
}