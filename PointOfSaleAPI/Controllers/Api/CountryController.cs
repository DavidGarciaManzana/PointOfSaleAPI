using Microsoft.AspNetCore.Mvc;
using PointOfSaleAPI.Models;
using PointOfSaleAPI.Services;
namespace PointOfSaleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    public class CountryController: ControllerBase
    {
        ICountryService countryServiceParameter;
        public CountryController(ICountryService countryServiceParameter)
        {
            this.countryServiceParameter = countryServiceParameter;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(countryServiceParameter.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] CountryModel countryModelParameter)
        {
            countryServiceParameter.Save(countryModelParameter);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CountryModel countryModelParameter)
        {
            countryServiceParameter.Update(id, countryModelParameter);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            countryServiceParameter.Delete(id);
            return Ok();
        }
    }
}
