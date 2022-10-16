using PointOfSaleAPI.Context;
using PointOfSaleAPI.Models;
namespace PointOfSaleAPI.Services
{
    public class InventoryService: IInventoryService
    {
        private PointOfSaleContext context;
        public InventoryService(PointOfSaleContext context)
        {
            this.context = context;
        }

        public IEnumerable<InventoryModel> Get()
        {
            return context.InventoryModels;
        }

        public async Task Save(InventoryModel inventoryParameter)
        {
            context.Add(inventoryParameter);
            await context.SaveChangesAsync();
        }

        public async Task Update(int ProductId, InventoryModel inventoryParameter)
        {
            var actualInventory = context.InventoryModels.Find(ProductId);
            if (actualInventory != null)
            {
                actualInventory.ProductId = ProductId;
                actualInventory.WarehouseId = inventoryParameter.WarehouseId;
                actualInventory.Quantity = inventoryParameter.Quantity;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int ProductId)
        {
            var actualInventory = context.InventoryModels.Find(ProductId);
            if (actualInventory != null)
            {
                context.Remove(actualInventory);

                await context.SaveChangesAsync();
            }
        }
    }
    public interface IInventoryService
    {
        IEnumerable<InventoryModel> Get();
        Task Save(InventoryModel inventoryParameter);
        Task Update(int ProductId, InventoryModel inventoryParameter);
        Task Delete(int ProductId);
    }
}
