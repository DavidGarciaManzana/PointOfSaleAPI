using Microsoft.AspNetCore.Mvc;
using PointOfSaleAPI.Models;
using PointOfSaleAPI.Services;
namespace PointOfSaleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    public class ProductController: ControllerBase
    {
        IProductService productServiceParameter;
        public ProductController(IProductService productServiceParameter)
        {
            this.productServiceParameter = productServiceParameter;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(productServiceParameter.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] ProductModel productModelParameter)
        {
            productServiceParameter.Save(productModelParameter);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductModel productModelParameter)
        {
            productServiceParameter.Update(id, productModelParameter);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productServiceParameter.Delete(id);
            return Ok();
        }
    }
}
