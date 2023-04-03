
using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.Model.Acquisition.Vertel;
using FINCORE.SERVICE.VERTEL.DbContexts;
using FINCORE.SERVICE.VERTEL.Models;
using FINCORE.SERVICE.VERTEL.Repositories.ADO;
using FINCORE.SERVICE.VERTEL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrVerificationConsumenModels = FINCORE.LIBRARY.DTO.Model.Acquisition.Vertel.TrVerificationConsumenModels;

namespace FINCORE.SERVICE.VERTEL.Controllers
{


    [Route("api/v0/services/vertel/[action]")]
    [ApiController]
    public class VertelController : ControllerBase
    {
        private ConnectionConfigServices connectionConfigServices = new ConnectionConfigServices();
        private DbContext dbContext;
        private VertelRepository VertelRepository;
        private readonly IVertel ivertel;

        public VertelController(IVertel ivertel)
        {

            this.dbContext = new DbContext(this.connectionConfigServices.GetConnection());
            this.VertelRepository = new VertelRepository(this.dbContext);
            this.ivertel = ivertel;
        }

        [HttpGet]
        public IActionResult GetVertelList()
        {
            var list = VertelRepository.GetVertelList().Result;

            return Ok(list);

        }

        [HttpGet]
        public IActionResult GetVertelListPagination(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount)
        {
            return Ok(VertelRepository.GetVertelListPagination(SearchTerm, PageIndex, PageSize, RecordCount).Result);

        }

        [HttpGet]

        public IActionResult GetVertelLookUPNPP(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount)
        {
            return Ok(ivertel.GetVertelLookupNPP(SearchTerm, PageIndex, PageSize, RecordCount).Result);
        }

        [HttpGet]
        public async Task<IActionResult> GetDocumentField(string CMNo)
        {
            return Ok(await ivertel.GetDocField(CMNo));
        }

        [HttpGet]
        public IActionResult GetDataVerifikasiKonsumen(string VerifikasiNo)
        {
            return Ok(ivertel.GetDataVerifikasiKonsumen(VerifikasiNo).Result);
        }

        [HttpPost]
        public IActionResult GetPriceAwal(string creditId)
        {
            return Ok(ivertel.GetPriceAwal(creditId).Result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertVertel([FromBody] TrVerificationConsumenModels trVerificationConsumen)
        {
            return Ok(await ivertel.InsertVertel(trVerificationConsumen));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVertel([FromBody] TrVerificationConsumenModels trVerificationConsumenn)
        {
            return Ok(await ivertel.UpdateVertel(trVerificationConsumenn));
        }

        [HttpGet]
        public async Task<ActionResult> GetApproverReason(string typeApproval)
        {
            return Ok(await ivertel.GetApproverReason(typeApproval));
        }


        [HttpPost]
        public async Task<IActionResult> ApprovalAction([FromBody] VertelApprovalModels data)
        {
            return Ok(await ivertel.ApprovalProcess(data));
        }


    }
}
