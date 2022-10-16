using PointOfSaleAPI.Context;
using PointOfSaleAPI.Models;

namespace PointOfSaleAPI.Services
{
    public class OrderService : IOrderService
    {
        private PointOfSaleContext context;
        public OrderService(PointOfSaleContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderModel> Get()
        {
            return context.OrderModels;
        }

        public async Task Save(OrderModel orderParameter)
        {
            context.Add(orderParameter);
            await context.SaveChangesAsync();
        }

        public async Task Update(int OrderId, OrderModel orderParameter)
        {
            var actualOrder = context.OrderModels.Find(OrderId);
            if (actualOrder != null)
            {
                actualOrder.OrderId = OrderId;
                actualOrder.CustomerId = orderParameter.CustomerId;
                actualOrder.Status = orderParameter.Status;
                actualOrder.SalesManId = orderParameter.SalesManId;
                actualOrder.OrderDate = orderParameter.OrderDate;
                actualOrder.GrandTotal = orderParameter.GrandTotal;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int OrderId)
        {
            var actualOrder = context.CustomerModels.Find(OrderId);
            if (actualOrder != null)
            {
                context.Remove(actualOrder);

                await context.SaveChangesAsync();
            }
                
        }
    } 
        public interface IOrderService
        {
            IEnumerable<OrderModel> Get();
            Task Save(OrderModel orderParameter);
            Task Update(int OrderId, OrderModel orderParameter);
            Task Delete(int OrderId);
        }
    
}
