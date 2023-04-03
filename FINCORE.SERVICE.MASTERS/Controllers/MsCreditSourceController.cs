using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/creditsource")]
    [ApiController]
    public class MsCreditSourceController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsCreditSourceRepositoryEF creditSourceRepository;

        public MsCreditSourceController(MastersContext mastersContext)
        {
            this.mastersContext = mastersContext;
            this.creditSourceRepository = new MsCreditSourceRepositoryEF(mastersContext);
        }

        [HttpGet("getcreditsource")]
        public async Task<IActionResult> GetCreditSource()
        {
            var creditSource = await creditSourceRepository.GetCreditSourceAsync();
            return Ok(creditSource);
        }
    }
}