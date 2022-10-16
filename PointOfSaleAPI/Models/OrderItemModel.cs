namespace PointOfSaleAPI.Models
{
    public class OrderItemModel
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal TotalPrice { get; set; }
        public virtual OrderModel OrderModels { get; set; }
        public virtual ProductModel ProductModels { get; set; }
    }
}
