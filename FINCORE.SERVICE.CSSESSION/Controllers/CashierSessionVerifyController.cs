using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentContext;
using FINCORE.SERVICE.CSSESSION.DTO;
using FINCORE.SERVICE.CSSESSION.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.CSSESSION.Controllers
{
    [Route("api/v1/services/payment/cashier-session-verify/")]
    [ApiController]
    public class CashierSessionVerifyController : ControllerBase
    {
        private readonly ICashierSessionVerify cashierSessionVerify;

        public CashierSessionVerifyController(ICashierSessionVerify sessionVerify)
        {
            cashierSessionVerify = sessionVerify;
        }

        [HttpPost("verify-session")]
        public async Task<IActionResult> VerifySession([FromBody] VerifySessionDTO param)
        {
            try
            {
                var result = await cashierSessionVerify.VerifySession(param);

                return result.code switch
                {

                    400 => BadRequest(result),
                    403 => StatusCode(StatusCodes.Status403Forbidden, new APIResponse(
                                    Collection.Codes.FORBIDDEN,
                                    Collection.Status.FAILED,
                                    result.message,
                                    new { })),

                    500 => StatusCode(StatusCodes.Status500InternalServerError, new APIResponse(
                                    Collection.Codes.INTERNAL_SERVER_ERROR,
                                    Collection.Status.FAILED,
                                    result.message,
                                    new { })),
                    _ => Ok(result),
                };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponse(
                    Collection.Codes.INTERNAL_SERVER_ERROR,
                    Collection.Status.FAILED,
                    ex.Message,
                    new { }));
            }
        }

    }
}
