namespace PointOfSaleAPI.Models
{
    public class WarehouseModel
    {
        public int WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public int LocationId { get; set; }
        public virtual ICollection<InventoryModel> InventoryModels { get; set; }
        public virtual LocationModel LocationModels { get; set; }

    }
}
