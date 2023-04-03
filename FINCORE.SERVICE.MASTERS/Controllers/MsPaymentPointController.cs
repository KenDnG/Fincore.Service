using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/paymentpoint")]
    [ApiController]
    public class MsPaymentPointController : ControllerBase
    {
        private readonly IMsPaymentPoint msPaymentPoint;

        public MsPaymentPointController(IMsPaymentPoint msPaymentPoint)
        {
            this.msPaymentPoint = msPaymentPoint;
        }

        [HttpGet("ef/get")]
        public async Task<IActionResult> GetRODecision(int paymentType)
        {
            return Ok(await msPaymentPoint.GetPaymentPoint(paymentType));
        }
    }
}