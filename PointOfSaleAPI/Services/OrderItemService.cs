using PointOfSaleAPI.Context;
using PointOfSaleAPI.Models;

namespace PointOfSaleAPI.Services
{
    public class OrderItemService: IOrderItemService
    {
        private PointOfSaleContext context;
        public OrderItemService(PointOfSaleContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderItemModel> Get()
        {
            return context.OrderItemModels;
        }

        public async Task Save(OrderItemModel orderItemParameter)
        {
            context.Add(orderItemParameter);
            await context.SaveChangesAsync();
        }

        public async Task Update(int ItemId, OrderItemModel orderItemParameter)
        {
            var actualOrderItem = context.OrderItemModels.Find(ItemId);
            if (actualOrderItem != null)
            {
                actualOrderItem.ItemId = ItemId;
                actualOrderItem.OrderId = orderItemParameter.OrderId;
                actualOrderItem.ProductId = orderItemParameter.ProductId;
                actualOrderItem.Quantity = orderItemParameter.Quantity;
                actualOrderItem.UnitPrice = orderItemParameter.UnitPrice;
                actualOrderItem.TotalPrice = orderItemParameter.TotalPrice;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int ItemId)
        {
            var actualOrderItem = context.OrderItemModels.Find(ItemId);
            if (actualOrderItem != null)
            {
                context.Remove(actualOrderItem);

                await context.SaveChangesAsync();
            }
        }
    }
    public interface IOrderItemService
    {
        IEnumerable<OrderItemModel> Get();
        Task Save(OrderItemModel orderItemParameter);
        Task Update(int ItemId, OrderItemModel orderItemParameter);
        Task Delete(int ItemId);
    }
}
