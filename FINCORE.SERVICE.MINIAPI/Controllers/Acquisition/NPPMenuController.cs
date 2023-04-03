using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MINIAPI.Controllers.Acquisition
{
    [Route("api/v1/services/mini/npp/")]
    [ApiController]
    public class NPPMenuController : Controller
    {
        private readonly INPPMenu iNPPMenu;

        public NPPMenuController(INPPMenu iNPPMenu)
        {
            this.iNPPMenu = iNPPMenu;
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPaginationNPPs(string? searchTerm, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await iNPPMenu.GetPaginationNPPs(searchTerm, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("dealer-bank-ref/pagination")]
        public async Task<IActionResult> GetPaginationDealerBankRef(string? searchTerm, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await iNPPMenu.GetPaginationDealerBankAccount(searchTerm, pageIndex, pageSize, totalPage, recCount));
        }
    }
}