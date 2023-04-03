using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/dealer-bank-reference/")]
    [ApiController]
    public class MsDealerBankReferenceController : ControllerBase
    {
        private MastersContext mastersContext;
        private readonly MsDealerBankReferenceRepository repository;

        public MsDealerBankReferenceController(MastersContext mastersContext)
        {
            this.mastersContext = mastersContext;
            this.repository = new MsDealerBankReferenceRepository(mastersContext);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDealerBankReference()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpGet("byId/{DealerCode}")]
        public async Task<IActionResult> GetAllDealerBankReferenceByDealerCode(string DealerCode)
        {
            return Ok(await repository.GetByIdAsync(DealerCode));
        }

        [HttpGet("byId")]
        public async Task<IActionResult> GetAllDealerBankReferenceById(int Id
                                                                        , string DealerCode
                                                                        , string DealerAccountType)
        {
            return Ok(await repository.GetByIdAndDealerCodeAsync(Id, DealerCode, DealerAccountType));
        }
    }
}