using Castle.Components.DictionaryAdapter;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels;
using FINCORE.LIBRARY.DTO.Model.Acquisition.NPP;
using FINCORE.SERVICE.NPP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.NPP.Controllers
{
    [Route("api/v1/services/acquisition/npp/")]
    [ApiController]
    public class TrNPPController : ControllerBase
    {
        private readonly TrNPPRepository trNPPRepo;
        private readonly TrCMRepository trCMRepo;

        public TrNPPController(AcquisitionContext _acquisitionContext, MastersContext _mastersContext)
        {
            this.trNPPRepo = new TrNPPRepository(_acquisitionContext, _mastersContext);
            this.trCMRepo = new TrCMRepository(_acquisitionContext);
        }

        [HttpGet("viewById/{creditId}/{userId}")]
        public async Task<IActionResult> GetNppViewById(string creditId, string userId)
        {
            return Ok(await trNPPRepo.GetNppViewById(creditId, userId));
        }

        [HttpGet("editById/{creditId}")]
        public async Task<IActionResult> GetNppEditById(string creditId)
        {
            return Ok(await trNPPRepo.GetNppEditById(creditId));
        }

        [HttpGet("collectionByCreditId/{creditId}")]
        public async Task<IActionResult> GetNppDataByCreditId(string creditId)
        {
            return Ok(await trNPPRepo.GetNppDataById(creditId));
        }

        [HttpGet("CMByCreditId/{creditId}")]
        public async Task<IActionResult> GetCMByCreditId(string creditId)
        {
            return Ok(await trCMRepo.GetProcessCMByCreditId(creditId));
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertTrNPP([FromBody] TrNppRequest NPP)
        {
            return Ok(await trNPPRepo.InsertMotorcyleTrNPPAsync(NPP));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTrNpp([FromBody] TrNppRequest NPP)
        {
            return Ok(await trNPPRepo.UpdateMotorcycleTrNPPAsync(NPP));
        }

        [HttpPost("car/insert")]
        public async Task<IActionResult> InsertTrNPPCar([FromBody] TrNppRequest NPP)
        {
            return Ok(await trNPPRepo.InsertCarTrNPPAsync(NPP));
        }

        [HttpPost("car/update")]
        public async Task<IActionResult> UpdateTrNppCar([FromBody] TrNppRequest NPP)
        {
            return Ok(await trNPPRepo.UpdateCarTrNPPAsync(NPP));
        }

        [HttpPost("approval")]
        public async Task<IActionResult> ApprovalNpp([FromBody] TrNppRequest NPP)
        {
            return Ok(await trNPPRepo.ApprovalNPPAsync(NPP));
        }
        [HttpPost("checkrapindo")]
        public async Task<IActionResult> CheckRapindo(string ChassisNo,String BranchName,String BranchId,string UserName,string CompanyId)
        {
            return Ok(await trNPPRepo.CheckRapindo(ChassisNo,BranchName,BranchId,UserName,CompanyId));
        }
    }
}