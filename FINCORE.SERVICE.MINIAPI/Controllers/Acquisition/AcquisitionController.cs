using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.SERVICE.MINIAPI.Repositories.EF.Acquisition;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MINIAPI.Controllers.Acquisition
{
    [Route("api/v1/services/mini/acquisition/")]
    [ApiController]
    public class AcquisitionController : ControllerBase
    {
        private AcquisitionContext acquisitionContext;
        private AcquisitionRepository acquisitionRepository;

        public AcquisitionController(AcquisitionContext _acquisitionContext)
        {
            this.acquisitionContext = _acquisitionContext;
            this.acquisitionRepository = new AcquisitionRepository(_acquisitionContext);
        }

        [HttpGet("pagination/mobil")]
        public async Task<IActionResult> PaginationTrCreditCar(string branch_id, string? searchTerm, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            return Ok(await acquisitionRepository.GetPaginationAcquisitionMobil(branch_id, searchTerm, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("pagination/motor")]
        public async Task<IActionResult> PaginationTrCreditMotor(string branch_id, string? searchTerm, string? searchTerm1, int pageIndex, int pageSize, int? totalPage, int? recCount)
        {
            searchTerm = searchTerm is null ? string.Empty : searchTerm;
            searchTerm1 = searchTerm1 is null ? string.Empty : searchTerm1;
            return Ok(await acquisitionRepository.GetPaginationAcquisitionMotor(branch_id, searchTerm, searchTerm1, pageIndex, pageSize, totalPage, recCount));
        }

        [HttpGet("pagination/nik_konsumen")]
        public async Task<IActionResult> PaginationNikKonsumen(string employeeName, string? branchId, bool isKonsol, bool includePos, int pageIndex, double pageSize, int? totalPage, double? recCount) 
        {
            employeeName = employeeName is null ? string.Empty : employeeName;
            branchId = branchId is null ? string.Empty : branchId;
            return Ok(acquisitionRepository.GetPaginationNikKonsumen(employeeName, branchId, isKonsol, includePos, pageIndex, pageSize, totalPage, recCount));
        }
    }
}