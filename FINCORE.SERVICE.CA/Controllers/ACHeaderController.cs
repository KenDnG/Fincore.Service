using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.CA.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.CA.Controllers
{
    [Route("api/v0/services/acquisition/ac-header/")]
    [ApiController]
    public class ACHeaderController : ControllerBase
    {
        private readonly IACHeader iACHeader;

        public ACHeaderController(IACHeader _iACHeader)
        {
            this.iACHeader = _iACHeader;
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>
        /// <param name="command"></param>
        [HttpGet("ef/ac-header/{Id}")]
        public async Task<IActionResult> GetAnalisaEF(string Id)
        {
            return Ok(await iACHeader.GetAnalisa(Id));
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>
        /// <param name="command"></param>
        [HttpPost("ef/update-ac-header")]
        public async Task<IActionResult> UpdateAnalisaEF(ACHeaderModel ACHeaderModel)
        {
            return Ok(await iACHeader.UpdateAnalisa(ACHeaderModel));
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>
        /// <param name="command"></param>
        [HttpPost("ef/insert-ac-header")]
        public async Task<IActionResult> InsertAnalisaEF(ACHeaderModel ACHeaderModel)
        {
            return Ok(await iACHeader.InsertAnalisa(ACHeaderModel));
        }
    }
}