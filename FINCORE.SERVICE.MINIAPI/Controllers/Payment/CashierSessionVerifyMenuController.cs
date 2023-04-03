using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentContext;
using FINCORE.SERVICE.MINIAPI.Models;
using FINCORE.SERVICE.MINIAPI.Repositories.EF;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MINIAPI.Controllers.Payment
{
    [Route("api/v1/services/mini/payment/cashier-session-verify/")]
    [ApiController]
    public class CashierSessionVerifyMenuController : ControllerBase
    {
        private readonly PAYMENTContext paymentContext;
        private readonly CashierSessionVerifyRepositoryEF CSVRepo;

        public CashierSessionVerifyMenuController(PAYMENTContext _paymentContext)
        {
            this.paymentContext = _paymentContext;
            this.CSVRepo = new CashierSessionVerifyRepositoryEF(_paymentContext);
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetCashierSession([FromQuery] CashierSessionVerifyModel param)
        {

            if (ModelState.IsValid)
            {
                APIResponse result = await CSVRepo.GetCashierSessionVerifyAsync(param);

                if (result.code == StatusCodes.Status500InternalServerError)
                    return StatusCode(statusCode: StatusCodes.Status500InternalServerError, result);

                return Ok(result);
            }

            return BadRequest(new APIResponse(
                    Collection.Codes.BAD_REQUEST,
                    Collection.Status.FAILED,
                    "One of input not valid",
                    new { }));

        }
    }
}
