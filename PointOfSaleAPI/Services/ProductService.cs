using PointOfSaleAPI.Context;
using PointOfSaleAPI.Models;
namespace PointOfSaleAPI.Services
{
    public class ProductService : IProductService
    {
        private PointOfSaleContext context;
        public ProductService(PointOfSaleContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductModel> Get()
        {
            return context.ProductModels;
        }

        public async Task Save(ProductModel productParameter)
        {
            context.Add(productParameter);
            await context.SaveChangesAsync();
        }

        public async Task Update(int ProductId, ProductModel productParameter)
        {
            var actualProduct = context.ProductModels.Find(ProductId);
            if (actualProduct != null)
            {
                actualProduct.ProductId = ProductId;
                actualProduct.ProductName = productParameter.ProductName;
                actualProduct.Description = productParameter?.Description;
                actualProduct.StandardCost = productParameter.StandardCost;
                actualProduct.ListPrice = productParameter.ListPrice;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int ProductId)
        {
            var actualProduct = context.ProductModels.Find(ProductId);
            if (actualProduct != null)
            {
                context.Remove(actualProduct);

                await context.SaveChangesAsync();
            }
        }
    }
    public interface IProductService
    {
        IEnumerable<ProductModel> Get();
        Task Save(ProductModel productParameter);
        Task Update(int ProductId, ProductModel productParameter);
        Task Delete(int ProductId);
    }
}
