using PointOfSaleAPI.Context;
using PointOfSaleAPI.Models;

namespace PointOfSaleAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private PointOfSaleContext context;
        public CustomerService(PointOfSaleContext context)
        {
            this.context = context;
        }

        public IEnumerable<CustomerModel> Get()
        {
            return context.CustomerModels;
        }

        public async Task Save(CustomerModel customerParameter)
        {
           context.Add(customerParameter);
            await context.SaveChangesAsync();
        }

        public async Task Update(int CustomerId, CustomerModel customerParameter)
        {
            var actualCustomer = context.CustomerModels.Find(CustomerId);
            if(actualCustomer != null)
            { 
                actualCustomer.CustomerId = CustomerId;
                actualCustomer.Name = customerParameter.Name;
                actualCustomer.Address = customerParameter?.Address; 
                actualCustomer.Website = customerParameter?.Website;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int CustomerId)
        {
            var actualCustomer = context.CustomerModels.Find(CustomerId);
            if (actualCustomer != null)
            {
                context.Remove(actualCustomer);

                await context.SaveChangesAsync();
            }
        }

        
    }
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> Get();
        Task Save(CustomerModel customerParameter);
        Task Update(int CustomerId, CustomerModel customerParameter);
        Task Delete(int CustomerId);
    }
}
