using Microsoft.AspNetCore.Mvc;
using PointOfSaleAPI.Models;
using PointOfSaleAPI.Services;
namespace PointOfSaleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        IInventoryService inventoryServiceParameter;
        public InventoryController(IInventoryService inventoryServiceParameter)
        {
            this.inventoryServiceParameter = inventoryServiceParameter;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(inventoryServiceParameter.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] InventoryModel inventoryModelParameter)
        {
            inventoryServiceParameter.Save(inventoryModelParameter);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InventoryModel inventoryModelParameter)
        {
            inventoryServiceParameter.Update(id, inventoryModelParameter);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            inventoryServiceParameter.Delete(id);
            return Ok();
        }
    }
}
