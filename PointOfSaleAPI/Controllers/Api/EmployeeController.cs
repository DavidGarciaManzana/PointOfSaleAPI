using PointOfSaleAPI.Models;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleAPI.Services;

namespace PointOfSaleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService employeeServiceParameter;
        public EmployeeController(IEmployeeService employeeServiceParameter)
        {
            this.employeeServiceParameter = employeeServiceParameter;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employeeServiceParameter.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel employeeModelParameter)
        {
            employeeServiceParameter.Save(employeeModelParameter);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeModel employeeModelParameter)
        {
            employeeServiceParameter.Update(id, employeeModelParameter);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            employeeServiceParameter.Delete(id);
            return Ok();
        }
    }
}
