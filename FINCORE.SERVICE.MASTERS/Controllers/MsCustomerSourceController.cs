using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/customersource")]
    [ApiController]
    public class MsCustomerSourceController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsCustomerSourceRepositoryEF _customerSourceRepository;

        public MsCustomerSourceController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this._customerSourceRepository = new MsCustomerSourceRepositoryEF(_mastersContext);
        }

        [HttpGet("getcustomersource")]
        public async Task<IActionResult> GetCustomerSource()
        {
            var msCustomerSrc = await this._customerSourceRepository.GetCustomerSourceAsync();
            return base.Ok(msCustomerSrc);
        }
    }
}