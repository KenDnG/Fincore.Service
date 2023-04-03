using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/otherinstallment")]
    [ApiController]
    public class MsOtherInstallmentController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsMonthlyOtherInstallmentRepositoryEF monthlyOtherInstallment;

        public MsOtherInstallmentController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.monthlyOtherInstallment = new MsMonthlyOtherInstallmentRepositoryEF(_mastersContext);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetOtherInstallment()
        {
            var otherInstallment = await monthlyOtherInstallment.GetOtherInstallmentAsync();
            return Ok(otherInstallment);
        }
    }
}