using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MINIAPI.DbContexts;
using FINCORE.SERVICE.MINIAPI.Repositories.ADO;
using FINCORE.SERVICE.MINIAPI.Repositories.EF;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MINIAPI.Controllers.Acquisition
{
    [Route("api/v0/services/acquisition/BPKB/")]
    [ApiController]
    public class BPKBController : ControllerBase
    {
        private ConnectionConfigServices connectionConfigServices = new ConnectionConfigServices();
        //private DbContext dbContextADO;
        //private BPKBRepositoryADO bpkbRepositoryADO;

        private AcquisitionContext dbContext;
        private BPKBRepositoryEF bpkbRepository;

        public BPKBController(AcquisitionContext _db, MastersContext _ma)
        {
            this.dbContext = _db;
            this.bpkbRepository = new BPKBRepositoryEF(_db, _ma);

            //this.dbContextADO = new DbContext(this.connectionConfigServices.GetConnection(connectionConfigServices.GetConnAcquisition()));
            //this.bpkbRepositoryADO = new BPKBRepositoryADO(this.dbContextADO);
        }

        #region EF
        [HttpGet("EF/BPKB/LIST/[Action]")]
        public async Task<IActionResult> GetBPKBLookupNPP(string? SearchTerm,string BranchID, int PageIndex
                                                  , int PageSize, int? RecordCount)
        {
            return Ok(await bpkbRepository.GetBPKBLookupNPP(SearchTerm,BranchID, PageIndex, PageSize, RecordCount));
        }
        [HttpGet("EF/BPKB/LIST/[Action]")]
        public async Task<IActionResult> GetBPKBReceiverPaginationEF(string? SearchTerm, int PageIndex
                                                  , int PageSize, int? RecordCount)
        {
            return Ok(await bpkbRepository.GetBPKBReceiverLookup(SearchTerm, PageIndex, PageSize, RecordCount));
        }
        [HttpGet("EF/BPKB/LIST/[Action]")]
        public async Task<IActionResult> GetBPKBListPaginationEF(string? SearchTerm, string BranchID, int PageIndex
                                                  , int PageSize, int? RecordCount)
        {
            return Ok(await bpkbRepository.GetBPKBPaging(SearchTerm, BranchID, PageIndex, PageSize, RecordCount));
        }
        [HttpGet("EF/BPKB/LIST/[Action]")]
        public async Task<IActionResult> GetBPKBPagingTypeOfBureau(string? SearchTerm, int PageIndex
                                                  , int PageSize, int? RecordCount)
        {
            return Ok(await bpkbRepository.GetBPKBPagingTypeOfBureau(SearchTerm, PageIndex, PageSize, RecordCount));
        }
        [HttpGet("EF/BPKB/LIST/[Action]")]
        public async Task<IActionResult> GetBPKBPagingDealer(string? SearchTerm, string CreditID, int PageIndex
                                                  , int PageSize, int? RecordCount)
        {
            return Ok(await bpkbRepository.GetBPKBPagingDealer(SearchTerm, CreditID, PageIndex, PageSize, RecordCount));
        }
        [HttpGet("EF/BPKB/LIST/[Action]")]
        public async Task<IActionResult> GetBPKBPagingAsuransi(string? SearchTerm, int PageIndex
                                                  , int PageSize, int? RecordCount)
        {
            return Ok(await bpkbRepository.GetBPKBPagingAsuransi(SearchTerm, PageIndex, PageSize, RecordCount));
        }
        [HttpGet("EF/BPKB/LIST/[Action]")]
        public async Task<IActionResult> GetBPKBPagingBiroJasa(string? SearchTerm, int PageIndex
                                                  , int PageSize, int? RecordCount)
        {
            return Ok(await bpkbRepository.GetBPKBPagingBiroJasa(SearchTerm, PageIndex, PageSize, RecordCount));
        }
        #endregion
    }
}
