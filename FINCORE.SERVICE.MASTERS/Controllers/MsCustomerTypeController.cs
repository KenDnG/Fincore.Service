using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/customertype")]
    [ApiController]
    public class MsCustomerTypeController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsCustomerTypeRepositoryEF msCustomerType;

        public MsCustomerTypeController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.msCustomerType = new MsCustomerTypeRepositoryEF(_mastersContext);
        }

        [HttpGet("getcustomertype")]
        public async Task<IActionResult> GetMsSource()
        {
            var msCustomerType = await this.msCustomerType.GetCustomerTypeAsync();
            return base.Ok(msCustomerType);
        }
    }
}