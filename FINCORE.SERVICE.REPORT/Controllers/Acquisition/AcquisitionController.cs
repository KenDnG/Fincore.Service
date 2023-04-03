using FINCORE.SERVICE.REPORT.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.REPORT.Controllers.Acquisition
{
    [Route("api/v1/services/report/acquisition/")]
    [ApiController]
    public class AcquisitionController : ControllerBase
    {
        private readonly IAcquisition iAcquisition;

        public AcquisitionController(IAcquisition _iAcquisition)
            => this.iAcquisition = _iAcquisition;

        [HttpGet("print/po-mobil")]
        public async Task<IActionResult> PrintPOMobil(string poNo, string branchId, string printBy)
        {
            return Ok(await iAcquisition.PrintPOMobilAsync(poNo, branchId, printBy));
        }

        [HttpGet("print/po-motor")]
        public async Task<IActionResult> PrintPOMotor(string poNo, string branchId, string printBy)
        {
            return Ok(await iAcquisition.PrintPOMotorAsync(poNo, branchId, printBy));
        }
    }
}