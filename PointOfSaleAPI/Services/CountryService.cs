using PointOfSaleAPI.Context;
using PointOfSaleAPI.Models;
namespace PointOfSaleAPI.Services
{
    public class CountryService: ICountryService
    {
        private PointOfSaleContext context;
        public CountryService(PointOfSaleContext context)
        {
            this.context = context;
        }

        public IEnumerable<CountryModel> Get()
        {
            return context.CountryModels;
        }

        public async Task Save(CountryModel countryParameter)
        {
            context.Add(countryParameter);
            await context.SaveChangesAsync();
        }

        public async Task Update(int CountryId, CountryModel countryParameter)
        {
            var actualCountry = context.CountryModels.Find(CountryId);
            if (actualCountry != null)
            {
                actualCountry.CountryId = CountryId;
                actualCountry.CountryName = countryParameter?.CountryName;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int CountryId)
        {
            var actualCountry = context.CountryModels.Find(CountryId);
            if (actualCountry != null)
            {
                context.Remove(actualCountry);

                await context.SaveChangesAsync();
            }
        }
    }
    public interface ICountryService
    {
        IEnumerable<CountryModel> Get();
        Task Save(CountryModel countryParameter);
        Task Update(int CountryId, CountryModel countryParameter);
        Task Delete(int CountryId);
    }
}
