namespace PointOfSaleAPI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public Decimal StandardCost { get; set; }
        public Decimal ListPrice { get; set; }
        public virtual ICollection<OrderItemModel> OrderItemModels { get; set; }
        public virtual ICollection<InventoryModel> InventoryModels { get; set; }

    }
}
