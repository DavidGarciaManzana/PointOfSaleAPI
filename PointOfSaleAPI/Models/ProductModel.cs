namespace PointOfSaleAPI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public int StandardCost { get; set; }
        public int ListPrice { get; set; }
        public virtual ICollection<OrderItemModel> OrderItemModels { get; set; }
        public virtual ICollection<InventoryModel> InventoryModels { get; set; }

    }
}
