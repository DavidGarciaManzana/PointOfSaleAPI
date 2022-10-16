using PointOfSaleAPI.Context;
using PointOfSaleAPI.Models;

namespace PointOfSaleAPI.Services
{
    public class WarehouseService : IWarehouseService
    {
        private PointOfSaleContext context;
        public WarehouseService(PointOfSaleContext context)
        {
            this.context = context;
        }

        public IEnumerable<WarehouseModel> Get()
        {
            return context.WarehouseModels;
        }

        public async Task Save(WarehouseModel warehouseParameter)
        {
            context.Add(warehouseParameter);
            await context.SaveChangesAsync();
        }

        public async Task Update(int WarehouseId, WarehouseModel warehouseParameter)
        {
            var actualWarehouse = context.WarehouseModels.Find(WarehouseId);
            if (actualWarehouse != null)
            {
                actualWarehouse.WarehouseId = WarehouseId;
                actualWarehouse.WarehouseName = warehouseParameter?.WarehouseName;
                actualWarehouse.LocationId = warehouseParameter.LocationId;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int WarehouseId)
        {
            var actualWarehouse = context.WarehouseModels.Find(WarehouseId);
            if (actualWarehouse != null)
            {
                context.Remove(actualWarehouse);

                await context.SaveChangesAsync();
            }
        }
    }
    public interface IWarehouseService
    {
        IEnumerable<WarehouseModel> Get();
        Task Save(WarehouseModel warehouseParameter);
        Task Update(int WarehouseId, WarehouseModel warehouseParameter);
        Task Delete(int WarehouseId);
    }
}
