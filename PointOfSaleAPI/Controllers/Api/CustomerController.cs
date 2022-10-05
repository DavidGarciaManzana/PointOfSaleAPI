using Microsoft.AspNetCore.Mvc;
using PointOfSaleAPI.Models;
using PointOfSaleAPI.Services;

namespace PointOfSaleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        ICustomerService customerServiceParameter;
        public CustomerController(ICustomerService customerServiceParameter)
        {
            this.customerServiceParameter = customerServiceParameter;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customerServiceParameter.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] CustomerModel customerModelParameter)
        {
            customerServiceParameter.Save(customerModelParameter);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerModel customerModelParameter)
        {
            customerServiceParameter.Update(id, customerModelParameter);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            customerServiceParameter.Delete(id);
            return Ok();
        }
    }
}
