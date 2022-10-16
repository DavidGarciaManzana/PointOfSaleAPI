using PointOfSaleAPI.Context;
using PointOfSaleAPI.Models;
namespace PointOfSaleAPI.Services
{
    public class LocationService : ILocationService
    {
        private PointOfSaleContext context;
        public LocationService(PointOfSaleContext context)
        {
            this.context = context;
        }

        public IEnumerable<LocationModel> Get()
        {
            return context.LocationModels;
        }

        public async Task Save(LocationModel locationParameter)
        {
            context.Add(locationParameter);
            await context.SaveChangesAsync();
        }

        public async Task Update(int LocationId, LocationModel locationParameter)
        {
            var actualLocation = context.LocationModels.Find(LocationId);
            if (actualLocation != null)
            {
                actualLocation.LocationId = LocationId;
                actualLocation.Address = locationParameter?.Address;
                actualLocation.PostalCode = locationParameter?.PostalCode;
                actualLocation.City = locationParameter?.City;
                actualLocation.State = locationParameter?.State;
                actualLocation.CountryId = locationParameter.CountryId;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int LocationId)
        {
            var actualLocation = context.LocationModels.Find(LocationId);
            if (actualLocation != null)
            {
                context.Remove(actualLocation);

                await context.SaveChangesAsync();
            }
        }

    }
    public interface ILocationService
    {
        IEnumerable<LocationModel> Get();
        Task Save(LocationModel locationParameter);
        Task Update(int LocationId, LocationModel locationParameter);
        Task Delete(int LocationId);
    }
}
