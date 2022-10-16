namespace PointOfSaleAPI.Models
{
    public class InventoryModel
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public virtual ProductModel ProductModels { get; set; }
        public virtual WarehouseModel WarehouseModels { get; set; }
    }
}
