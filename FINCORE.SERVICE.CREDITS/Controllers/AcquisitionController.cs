using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.SERVICE.CREDITS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.CREDITS.Controllers
{
    [Route("api/v1/services/acquisition/")]
    [ApiController]
    public class AcquisitionController : ControllerBase
    {
        public readonly IAcquisition acquisition;

        public AcquisitionController(IAcquisition acquisition)
                    => this.acquisition = acquisition;

        [HttpGet("get/pono-bycredit")]
        public async Task<IActionResult> GetPOByCreditId(string creditId)
        {
            var data = await acquisition.GetPONumberByCreditIdAsync(creditId);
            return Ok(data);
        }

        [HttpPost("insert/trpo-sendemail")]
        public async Task<IActionResult> InsertTrPoSendEmail(TrPoSendToEmail items)
        {
            var data = await acquisition.InsertTrPOSendEmailAsync(items);
            return Ok(data);
        }

        [HttpGet("email/sendemail-po")]
        public async Task<IActionResult> SendEmailPrintPO(string poNo)
        {
            var data = await acquisition.SendEmailPrintPO(poNo);
            return Ok(data);
        }

        [HttpPost("update/sumprint-po")]
        public async Task<IActionResult> UpdateSumPrintPO(string poNo, string printBy)
        {
            var data = await acquisition.UpdateSumPrintPO(poNo, printBy);
            return Ok(data);
        }

        [HttpPost("transaction/open-cm")]
        public async Task<IActionResult> OpenCM(string poNo, string creditId)
        {
            var data = await acquisition.OpenCM(poNo, creditId);
            return Ok(data);
        }

        [HttpPost("check/user-allow-printpo")]
        public async Task<IActionResult> CheckUserPrintPO(string employeeId)
        {
            var data = await acquisition.CheckUserPositionPrintPO(employeeId);
            return Ok(data);
        }
    }
}