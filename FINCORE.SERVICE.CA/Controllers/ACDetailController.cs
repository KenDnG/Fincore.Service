using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.CA.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.CA.Controllers
{
    [Route("api/v0/services/acquisition/ac-detail/")]
    [ApiController]
    public class ACDetailController : ControllerBase
    {
        private readonly IACDetail iACDetail;

        public ACDetailController(IACDetail _iACDetail)
        {
            this.iACDetail = _iACDetail;
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>
        /// <param name="command"></param>
        [HttpGet("ef/ac-detail/[Action]")]
        public async Task<IActionResult> GetFotoEF(string Id, string PhotoTypeID)
        {
            return Ok(await iACDetail.GetFoto(Id, PhotoTypeID));
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>
        /// <param name="command"></param>
        [HttpGet("ef/ac-detail/[Action]")]
        public async Task<IActionResult> GetFotoCekEF(string Id, string PhotoID, string PhotoTypeID)
        {
            return Ok(await iACDetail.GetFotoCek(Id, PhotoID, PhotoTypeID));
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("ef/-update-ac-detail")]
        public async Task<IActionResult> UpdateFotoEF(Year ACDetailModel)
        {
            return Ok(await iACDetail.UpdateFoto(ACDetailModel));
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>
        /// <param name="command"></param>
        [HttpPost("ef/insert-ac-detail")]
        public async Task<IActionResult> InsertFotoEF(Year ACDetailModel)
        {
            return Ok(await iACDetail.InsertFoto(ACDetailModel));
        }
    }
}