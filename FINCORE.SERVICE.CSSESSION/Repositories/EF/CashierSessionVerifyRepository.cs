using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentContext;
using FINCORE.SERVICE.CSSESSION.DTO;
using FINCORE.SERVICE.CSSESSION.Repositories.Interfaces;

namespace FINCORE.SERVICE.CSSESSION.Repositories.EF
{
    public class CashierSessionVerifyRepository : ICashierSessionVerify
    {
        private readonly PAYMENTContext _paymentContext;

        public CashierSessionVerifyRepository(PAYMENTContext paymentContext)
        {
            _paymentContext = paymentContext;
        }
        public async Task<APIResponse> VerifySession(VerifySessionDTO param)
        {
            try
            {
                await _paymentContext.GetProcedures().sp_update_cashier_session_verifyAsync(param.SessionId, param.EmployeeId);

                return new APIResponse(
                    Collection.Codes.SUCCESS,
                    Collection.Status.SUCCESS,
                    "Session verification was successful",
                    new { });
            }
            catch (Exception ex)
            {
                return new APIResponse(
                    Collection.Codes.INTERNAL_SERVER_ERROR,
                    Collection.Status.FAILED,
                    ex.Message,
                    new { });
            }
        }
    }
}
