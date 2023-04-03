using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces.CM;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MINIAPI.Controllers.Acquisition.CM
{
    [Route("api/v0/services/acquisition/cm/")]
    [ApiController]
    public class CMController : ControllerBase
    {
        private readonly ICM iCM;

        public CMController(ICM _iCM)
        {
            iCM = _iCM;
        }

        [HttpGet("ef/get-paginationitem")]
        public async Task<IActionResult> GetPaginationItem(string? searchTerm, string? item_id, string? item_brand_id, string asset_kind_class_id, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await iCM.GetPaginationItem(searchTerm, item_id, item_brand_id, asset_kind_class_id, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("ef/get-paginationdealer")]
        public async Task<IActionResult> GetPaginationDealer(string? searchTerm, string? item_id, string? is_item_new, string? branch_id, string? item_merk, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await iCM.GetPaginationDealer(searchTerm, item_id, is_item_new, branch_id, item_merk, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("ef/get-paginationsurveyor")]
        public async Task<IActionResult> GetPaginationSurveyor(string? searchTerm, string? item_id, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await iCM.GetPaginationSurveyor(searchTerm, item_id, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("ef/get-paginationmarketinghead")]
        public async Task<IActionResult> GetPaginationMarketingHead(string? searchTerm, string? item_id, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await iCM.GetPaginationMarketingHead(searchTerm, item_id, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("ef/get-paginationCGSNo")]
        public async Task<IActionResult> GetPaginationCGSNo(string? searchTerm, string? BranchId, string CompanyId, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await iCM.GetPaginationCGSNo(searchTerm, BranchId, CompanyId, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("ef/get-paginationOldNPP")]
        public async Task<IActionResult> GetPaginationOldNPP(string? searchTerm, string? BranchId, string CompanyId, string ItemMerkTypeID, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await iCM.GetPaginationOldNPP(searchTerm, BranchId, CompanyId, ItemMerkTypeID, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("ef/get-paginationPerantara")]
        public async Task<IActionResult> GetPaginationPerantara(string? searchTerm, string? BranchId, string CompanyId, string TipePerantara, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await iCM.GetPaginationPerantara(searchTerm, BranchId, CompanyId, TipePerantara, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("ef/get-paginationBankName")]
        public async Task<IActionResult> GetPaginationBankName(string? searchTerm, string? BranchId, string CompanyId, string PemilikRekening, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await iCM.GetPaginationBankName(searchTerm, BranchId, CompanyId, PemilikRekening, pageIndex, pageSize, totalPage, recCount));
        }
    }
}