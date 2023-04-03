using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.SERVICE.MINIAPI.Repositories.EF.Acquisition.CAS;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MINIAPI.Controllers.Acquisition.CAS
{
    [Route("api/v1/services/mini/cas/")]
    [ApiController]
    public class TrCasController : ControllerBase
    {
        private AcquisitionContext acquisitionContext;
        private TrCasRepositoryEF trCasRepository;

        public TrCasController(AcquisitionContext _acquisitionContext)
        {
            this.acquisitionContext = _acquisitionContext;
            this.trCasRepository = new TrCasRepositoryEF(_acquisitionContext);
        }

        [HttpGet("ef/pagination/location")]
        public async Task<IActionResult> GetPaginationLocations(string? searchTerm, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await trCasRepository.GetPaginationLocations(searchTerm, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("ef/pagination/msbank")]
        public async Task<IActionResult> GetPaginationMsBank(string? searchTerm, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await trCasRepository.GetPaginationBank(searchTerm, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("ef/pagination/poolingorder")]
        public async Task<IActionResult> GetPaginationPoolingOrder(string? tipeOrder, string? branchId, string? searchTerm, int pageIndex, double pageSize, int? totalPage, double? recCount)
        {
            return Ok(await trCasRepository.GetPaginationPoolingOrder(tipeOrder, branchId, searchTerm, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("ef/pagination/agreementold")]
        public async Task<IActionResult> GetPaginationAgreementOld(string? searchTerm, string lesseeId, int pageIndex, double pageSize, int? totalPage, double? recCount)
        {
            return Ok(await trCasRepository.GetPaginationAgreementOld(searchTerm, lesseeId, pageIndex, pageSize, totalPage, recCount));
        }
    }
}