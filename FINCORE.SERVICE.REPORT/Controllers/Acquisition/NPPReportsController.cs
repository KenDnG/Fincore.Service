using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.Model.Acquisition.NPP;
using FINCORE.SERVICE.REPORT.Repositories.Acquisition;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.REPORT.Controllers.Acquisition
{
    [Route("api/v1/services/report/acquisition/npp/")]
    [ApiController]
    public class NPPReportsController : ControllerBase
    {
        //private readonly AcquisitionContext acquisitionContext;
        private readonly NPPReportsRepository nppReportsRepository;

        public NPPReportsController(AcquisitionContext acquisitionContext
            /*,NPPReportsRepository nppReportsRepository*/)
        {
            //this.acquisitionContext = acquisitionContext;
            this.nppReportsRepository = new NPPReportsRepository(acquisitionContext);
        }

        [HttpGet("memorandum-of-understanding/{creditId}")]
        public async Task<IActionResult> GetDataMemorandumOfUnderstanding(string creditId)
        {
            var data = await nppReportsRepository.PrintMemorandumOfUnderstanding(creditId);
            return StatusCode(data.code, data);
        }

        [HttpGet("important-notice/{creditId}")]
        public async Task<IActionResult> GetDataImportantNotice(string creditId)
        {
            var data = await nppReportsRepository.PrintImportantNotice(creditId);
            return StatusCode(data.code, data);
        }

        [HttpGet("power-of-attorney-fidusia/{creditId}")]
        public async Task<IActionResult> GetDataPowerOfAttorneyFidusia(string creditId)
        {
            var data = await nppReportsRepository.PrintPowerOfAttorneyFidusia(creditId);
            return StatusCode(data.code, data);
        }

        [HttpGet("power-of-attorney/{creditId}")]
        public async Task<IActionResult> GetDataPowerOfAttorney(string creditId)
        {
            var data = await nppReportsRepository.PrintPowerOfAttorney(creditId);
            return StatusCode(data.code, data);
        }

        [HttpGet("statement-letter/{creditId}")]
        public async Task<IActionResult> GetDataStatementLetter(string creditId)
        {
            var data = await nppReportsRepository.PrintStatementLetter(creditId);
            return StatusCode(data.code, data);

        }

        [HttpGet("statement-letter-second/{creditId}")]
        public async Task<IActionResult> GetDataSecondStatementLetter(string creditId)
        {
            var data = await nppReportsRepository.PrintSecondStatementLetter(creditId);
            return StatusCode(data.code, data);
        }

        [HttpGet("approval-letter/{creditId}")]
        public async Task<IActionResult> GetApprovalLetter(string creditId)
        {
            var data = await nppReportsRepository.PrintApprovalLetter(creditId);
            return StatusCode(data.code, data);
        }

        [HttpGet("consument-statement-letter/{creditId}")]
        public async Task<IActionResult> GetDataConsumentStatementLetter(string creditId)
        {
            var data = await nppReportsRepository.PrintConsumentStatementLetter(creditId);
            return StatusCode(data.code, data);
        }

        [HttpGet("name-change-statement-letter/{creditId}")]
        public async Task<IActionResult> GetDataNameChangeStatementLetter(string creditId)
        {
            var data = await nppReportsRepository.PrintNameChangeStatementLetter(creditId);

            return StatusCode(data.code, data);
        }

        //[HttpGet("name_change_receipt/{creditId}")]
        //public async Task<IActionResult> GetDataNameChangeReceipt(string creditId)
        //{
        //    return Ok(await nppReportsRepository.PrintNameChangeReceipt(creditId));
        //}

        [HttpPost("nppprintlog")]
        public async Task<IActionResult> InsertMemorandumOfUnderstandingLog(TrNppPrintRequest trNppPrintRequest)
        {
            var data = await nppReportsRepository.LogNppPrint(trNppPrintRequest);
            return StatusCode(data.code, data);
        }

    }
}