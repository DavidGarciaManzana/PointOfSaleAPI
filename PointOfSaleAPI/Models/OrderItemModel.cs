namespace PointOfSaleAPI.Models
{
    public class OrderItemModel
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        public virtual OrderModel OrderModels { get; set; }
        public virtual ProductModel ProductModels { get; set; }
    }
}
