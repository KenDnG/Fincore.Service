using FINCORE.SERVICE.REPORT.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.REPORT.Controllers.Acquisition
{
    [Route("api/v1/services/report/vertel/")]
    [ApiController]
    public class VertelReportController : ControllerBase
    {
        private readonly IVertel iVertel;

        public VertelReportController(IVertel iVertel)
        {
            this.iVertel = iVertel;
        }

        [HttpGet("print/print-vertel")]
        public async Task<IActionResult> PrintVerificationCustomer(string transId, string employeeId, string sessBranchId)
        {
            return Ok(await iVertel.PrintVerificationCustomer(transId, employeeId, sessBranchId));
        }


        [HttpGet("print/print-vertel-dokumen")]
        public async Task<IActionResult> PrintVerificationCustomerDokumen(string transId)
        {
            return Ok(await iVertel.PrintVerificationCustomerDokumen(transId));
        }
    }
}
