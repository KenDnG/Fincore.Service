using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/")]
    [ApiController]
    public class msMenuTreeController : ControllerBase
    {
        private readonly IMSMenu trMenu;

        public msMenuTreeController(IMSMenu trMenu)
        {
            this.trMenu = trMenu;
        }

        [HttpGet("ef/getMenuTree")]
        public async Task<IActionResult> GetMenutree(string NIK)
        {
            var data = await trMenu.GetMenuTree(NIK);
            return Ok(data);
        }
    }
}