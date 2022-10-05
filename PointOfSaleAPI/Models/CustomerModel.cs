namespace PointOfSaleAPI.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        public virtual ICollection<OrderModel> OrderModels { get; set; }
    }
}
