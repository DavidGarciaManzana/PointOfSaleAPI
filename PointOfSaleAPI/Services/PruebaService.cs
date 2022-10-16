using PointOfSaleAPI.Context;
using PointOfSaleAPI.Models;

namespace PointOfSaleAPI.Services
{
    public class PruebaService : IPruebaService
    {
        private PointOfSaleContext context;
        public PruebaService(PointOfSaleContext context)
        {
            this.context = context;
        }

        public List<PruebaModel> Get()
        {

            var result = new List<PruebaModel> ();
            var anonymousObjResult = from om in this.context.OrderModels
                                     from cm in this.context.CustomerModels
                                     //from dm in this.context.EmployeeModels
                                     where om.CustomerId == cm.CustomerId //and cm.lala==dm.lala
                                     select new { om.Status, cm.Name };
            var newList = anonymousObjResult.ToList();

            foreach (var item in newList)
            {
                result.Add(new PruebaModel(item.Name, item.Status));
            }
            return result;
           
        }

    };
    public interface IPruebaService
    {
        List<PruebaModel> Get();

    }
}
