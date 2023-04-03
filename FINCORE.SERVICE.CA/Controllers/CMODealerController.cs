using FINCORE.SERVICE.CA.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.CA.Controllers
{
    [Route("api/v0/services/acquisition/cmo-dealer/")]
    [ApiController]
    public class CMODealerController : ControllerBase
    {
        private readonly ICMODealer CMODealer;

        public CMODealerController(ICMODealer _CMODealer)
        {
            this.CMODealer = _CMODealer;
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>
        /// <param name="command"></param>
        [HttpGet("ef/get-cmo/{Id}")]
        public async Task<IActionResult> GetListCMOEF(string Id)
        {
            return Ok(await CMODealer.GetListCMO(Id));
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>
        /// <param name="command"></param>
        [HttpGet("ef/get-dealer/{Id}")]
        public async Task<IActionResult> GetListDealerEF(string Id)
        {
            return Ok(await CMODealer.GetListDealer(Id));
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>
        /// <param name="command"></param>
        [HttpGet("ef/dealer-cmo/{Id}")]
        public async Task<IActionResult> GetCMODealerEF(string Id)
        {
            return Ok(await CMODealer.GetCMODealer(Id));
        }
    }
}