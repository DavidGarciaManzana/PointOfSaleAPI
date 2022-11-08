using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleAPI.Models;
using PointOfSaleAPI.Services;
namespace PointOfSaleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    public class OrderItemController:ControllerBase
    {
        IOrderItemService orderItemServiceParameter;
        public OrderItemController(IOrderItemService orderItemServiceParameter)
        {
            this.orderItemServiceParameter = orderItemServiceParameter;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(orderItemServiceParameter.Get());
        }
        [EnableCors()]
        [HttpPost]
        public IActionResult Post([FromBody] OrderItemModel orderItemModelParameter)
        {
           
            
            try
            {
                orderItemServiceParameter.Save(orderItemModelParameter);
                return Ok();
            }
            catch 
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderItemModel orderItemModelParameter)
        {
            orderItemServiceParameter.Update(id, orderItemModelParameter);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            orderItemServiceParameter.Delete(id);
            return Ok();
        }
    }
}
