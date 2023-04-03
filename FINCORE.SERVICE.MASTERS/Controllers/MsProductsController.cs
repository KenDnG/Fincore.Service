using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    public class MsProductsController : ControllerBase
    {
        public IActionResult GetProducts()
        {
            return Ok();
        }
    }
}