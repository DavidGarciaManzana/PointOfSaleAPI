using Microsoft.AspNetCore.Mvc;
using PointOfSaleAPI.Models;
using PointOfSaleAPI.Services;
namespace PointOfSaleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        IWarehouseService warehouseServiceParameter;
        public WarehouseController(IWarehouseService warehouseServiceParameter)
        {
            this.warehouseServiceParameter = warehouseServiceParameter;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(warehouseServiceParameter.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] WarehouseModel warehouseModelParameter)
        {
            warehouseServiceParameter.Save(warehouseModelParameter);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WarehouseModel warehouseModelParameter)
        {
            warehouseServiceParameter.Update(id, warehouseModelParameter);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            warehouseServiceParameter.Delete(id);
            return Ok();
        }
    }
}
