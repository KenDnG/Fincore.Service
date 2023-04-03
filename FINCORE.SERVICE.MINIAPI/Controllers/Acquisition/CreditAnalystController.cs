using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces.Credit_Analyst;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MINIAPI.Controllers.Acquisition
{
    [Route("api/v0/services/acquisition/")]
    public class CreditAnalystController : ControllerBase
    {
        private readonly ICA iCA;

        public CreditAnalystController(ICA _iCA)
        {
            this.iCA = _iCA;
        }

        [HttpGet("EF/CA/[Action]")]
        public async Task<IActionResult> GetCAListPaginationEF(string? SearchTerm, int PageIndex
                                                 , int PageSize, int? RecordCount)
        {
            return Ok(await iCA.GetCAListPagination(SearchTerm, PageIndex, PageSize, RecordCount));
        }

        [HttpGet("EF/CA/[Action]")]
        public async Task<IActionResult> GetCALookupHistory(string CANo, string TransTypeId)
        {
            return Ok(await iCA.GetCALookupHistory(CANo, TransTypeId));
        }

        [HttpGet("EF/CA/[Action]")]
        public async Task<IActionResult> GetCALookupViewDokumen(string Id, string PhotoTypeID)
        {
            return Ok(await iCA.GetCALookupViewDokumen(Id, PhotoTypeID));
        }

        [HttpGet("EF/CA/[Action]")]
        public async Task<IActionResult> GetCAPagingLookupApprovalScheme(string BranchID, string TransTypeId, string? SearchTerm, int PageIndex
                                                 , int PageSize, int? RecordCount)
        {
            return Ok(await iCA.GetCAPagingLookupApprovalScheme(BranchID, TransTypeId, SearchTerm, PageIndex, PageSize, RecordCount));
        }

        [HttpGet("EF/CA/[Action]")]
        public async Task<IActionResult> GetCAApprovalScheme(string BranchID, string TransTypeId)
        {
            return Ok(await iCA.GetCAApprovalScheme(BranchID, TransTypeId));
        }

        [HttpGet("EF/CA/[Action]")]
        public async Task<IActionResult> GetCAApprovalUser(string ApprovalSchemeID, string ApprovalLevelDesc)
        {
            return Ok(await iCA.GetCAApprovalUser(ApprovalSchemeID, ApprovalLevelDesc));
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //FCL
        [HttpGet("EF/CA/[Action]")]
        public async Task<IActionResult> GetFCLId(string CASId)
        {
            return Ok(await iCA.GetFCLId(CASId));
        }

        [HttpGet("EF/CA/[Action]")]
        public async Task<IActionResult> GetFCLHeaderSLIK(string fclid)
        {
            return Ok(await iCA.GetFCLHeaderSLIK(fclid));
        }

        [HttpGet("EF/CA/[Action]")]
        public async Task<IActionResult> GetFCLSummarySLIK(string fclid, string? SearchTerm, int PageIndex
                                                 , int PageSize, int? RecordCount)
        {
            return Ok(await iCA.GetFCLSummarySLIK(fclid, SearchTerm, PageIndex, PageSize, RecordCount));
        }

        [HttpGet("EF/CA/[Action]")]
        public async Task<IActionResult> GetFCLHistoryKolSLIK(string fclid, string? SearchTerm, int PageIndex
                                                 , int PageSize, int? RecordCount)
        {
            return Ok(await iCA.GetFCLHistoryKolSLIK(fclid, SearchTerm, PageIndex, PageSize, RecordCount));
        }

        [HttpGet("EF/CA/[Action]")]
        public async Task<IActionResult> GetFCLDetailKreditSLIK(string fclid, string? SearchTerm, int PageIndex
                                                 , int PageSize, int? RecordCount)
        {
            return Ok(await iCA.GetFCLDetailKreditSLIK(fclid, SearchTerm, PageIndex, PageSize, RecordCount));
        }

        [HttpGet("EF/CA/[Action]")]
        public async Task<IActionResult> GetFCLDetailKonsumenSLIK(string fclid, string? SearchTerm, int PageIndex
                                                 , int PageSize, int? RecordCount)
        {
            return Ok(await iCA.GetFCLDetailKonsumenSLIK(fclid, SearchTerm, PageIndex, PageSize, RecordCount));
        }
    }
}