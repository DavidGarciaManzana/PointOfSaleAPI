using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleAPI.Models;
using PointOfSaleAPI.Services;

namespace PointOfSaleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        IOrderService orderServiceParameter;
        public OrderController(IOrderService orderServiceParameter)
        {
            this.orderServiceParameter = orderServiceParameter;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(orderServiceParameter.Get());
        }
        [EnableCors()]
        [HttpPost]
        public IActionResult Post([FromBody] OrderModel orderModelParameter)
        {
            orderServiceParameter.Save(orderModelParameter);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderModel orderModelParameter)
        {
            orderServiceParameter.Update(id, orderModelParameter);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            orderServiceParameter.Delete(id);
            return Ok();
        }
    }

}
