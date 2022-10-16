using Microsoft.AspNetCore.Mvc;
using PointOfSaleAPI.Models;
using PointOfSaleAPI.Services;
namespace PointOfSaleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    public class PruebaController : ControllerBase
    {
        IPruebaService pruebaServiceParameter;
        public PruebaController(IPruebaService pruebaServiceParameter)
        {
            this.pruebaServiceParameter = pruebaServiceParameter;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(pruebaServiceParameter.Get());
        }
    }
}
