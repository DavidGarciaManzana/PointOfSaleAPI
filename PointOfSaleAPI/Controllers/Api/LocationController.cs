using Microsoft.AspNetCore.Mvc;
using PointOfSaleAPI.Models;
using PointOfSaleAPI.Services;
namespace PointOfSaleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    public class LocationController: ControllerBase
    {
        ILocationService locationServiceParameter;
        public LocationController(ILocationService locationServiceParameter)
        {
            this.locationServiceParameter = locationServiceParameter;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(locationServiceParameter.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] LocationModel locationModelParameter)
        {
            locationServiceParameter.Save(locationModelParameter);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LocationModel locationModelParameter)
        {
            locationServiceParameter.Update(id, locationModelParameter);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            locationServiceParameter.Delete(id);
            return Ok();
        }
    }
}
