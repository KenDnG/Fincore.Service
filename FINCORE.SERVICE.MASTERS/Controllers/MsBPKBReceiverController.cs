using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/BPKBReceiver/")]
    [ApiController]
    public class MsBPKBReceiverController : Controller
    {
        private MastersContext mastersContext;
        private readonly MsBPKBReceiverRepository repository;

        public MsBPKBReceiverController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.repository = new MsBPKBReceiverRepository(mastersContext);
        }
        
        [HttpGet("getPaging")]
        public async Task<IActionResult> GetBPKBReceiverPaging(string? SearchTerm, int PageIndex
                                                  , int PageSize, int? RecordCount)
        {
            return Ok(await repository.GetBPKBReceiverLookup(SearchTerm, PageIndex, PageSize, RecordCount));
        }
    }
}
