using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.BPKB.DbContexts;
using FINCORE.SERVICE.BPKB.Models;
using FINCORE.SERVICE.BPKB.Repositories.EF;
using FINCORE.SERVICE.BPKB.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.BPKB.Controllers
{
    [Route("api/v0/services/acquisition/BPKB/")]
    [ApiController]
    public class BPKBController:ControllerBase
    {
        private ConnectionConfigServices connectionConfigServices = new ConnectionConfigServices();
        private AcquisitionContext dbContext;
        private BPKBRepositoryEF bpkbRepository;

        private DbContext dbContextADO;
        public BPKBController(AcquisitionContext _db,MastersContext _ma)
        {
            try
            {
                this.dbContext = _db;
                this.bpkbRepository = new BPKBRepositoryEF(_db);

                this.dbContextADO = new DbContext(this.connectionConfigServices.GetConnection(connectionConfigServices.GetConnAcquisition()));
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #region EF
        /// <summary>
        /// Command with Store Procedure.
        /// </summary>
        /// <param name="command"></param>
       
        [HttpPost("EF/BPKB/CRUD/[Action]")]
        public async Task<IActionResult> GetBPKB(TrBpkb BPKBModel)
        {
            return Ok(await bpkbRepository.GetBPKB(BPKBModel));
        }
        [HttpPost("EF/BPKB/CRUD/[Action]")]
        public async Task<IActionResult> InsertBPKBEF(BPKBCustomModel BPKBModel)
        {
            return Ok(await bpkbRepository.InsertBPKB(BPKBModel));
        }
        [HttpPost("EF/BPKB/CRUD/[Action]")]
        public async Task<IActionResult> UpdateBPKBEF(TrBpkb BPKBModel)
        {
            return Ok(await bpkbRepository.UpdateBPKB(BPKBModel));
        }
        [HttpPost("EF/BPKB/CRUD/[Action]")]
        public async Task<IActionResult> DeleteBPKBEF(TrBpkb BPKBModel)
        {
            return Ok(await bpkbRepository.DeleteBPKB(BPKBModel));
        }
        [HttpPost("EF/BPKB/CRUD/[Action]")]
        public async Task<IActionResult> SaveBPKBPinjamEF(TrBpkbLoan BPKBModel)
        {
            return Ok(await bpkbRepository.SaveBPKBPinjam(BPKBModel));
        }
        [HttpPost("EF/BPKB/CRUD/[Action]")]
        public async Task<IActionResult> ReEntryPinjamEF(BPKBCustomModel BPKBModel)
        {
            return Ok(await bpkbRepository.ReEntryBPKB(BPKBModel));
        }
        [HttpPost("EF/BPKB/CRUD/[Action]")]
        public async Task<IActionResult> OutBPKBEF(BPKBCustomModel BPKBModel)
        {
            return Ok(await bpkbRepository.OutBPKB(BPKBModel));
        }
        [HttpPost("EF/BPKB/CRUD/[Action]")]
        public async Task<IActionResult> GetCM(TrBpkb BPKBModel)
        {
            return Ok(await bpkbRepository.GetCM(BPKBModel));
        }
        [HttpPost("EF/BPKB/REPORT/[Action]")]
        public async Task<IActionResult> GetBastDetail(TrBpkb BPKBModel)
        {
            return Ok(await bpkbRepository.GetBASTData(BPKBModel));
        }
        [HttpPost("EF/BPKB/REPORT/[Action]")]
        public async Task<IActionResult> GetSKDetail(TrBpkb BPKBModel)
        {
            return Ok(await bpkbRepository.GetSKData(BPKBModel));
        }
        [HttpPost("EF/BPKB/REPORT/[Action]")]
        public async Task<IActionResult> GetPinjamDetail(TrBpkb BPKBModel)
        {
            return Ok(await bpkbRepository.GetPinjamData(BPKBModel));
        }
        [HttpPost("EF/BPKB/REPORT/[Action]")]
        public async Task<IActionResult> GetBastInDetail(TrBpkb BPKBModel)
        {
            return Ok(await bpkbRepository.GetBASTINData(BPKBModel));
        }
        [HttpPost("EF/BPKB/REPORT/[Action]")]
        public async Task<IActionResult> GetThirdPartyDetail(TrBpkb BPKBModel)
        {
            return Ok(await bpkbRepository.Get3PData(BPKBModel));
        }
        [HttpPost("EF/BPKB/CRUD/[Action]")]
        public async Task<IActionResult> UpdatePrintBPKBEF(TrBpkb BPKBModel)
        {
            return Ok(await bpkbRepository.UpdatePrintBPKB(BPKBModel));
        }

        #endregion
    }
}
