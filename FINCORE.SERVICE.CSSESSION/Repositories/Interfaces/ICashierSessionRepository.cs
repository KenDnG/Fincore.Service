using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentModel;
using FINCORE.SERVICE.CSSESSION.DTO;

namespace FINCORE.SERVICE.CSSESSION.Repositories.Interfaces
{
    public interface ICashierSessionRepository
    {
        Task<APIResponse> InsertCashierSessionAsync(TrCashierSession CashierSession);

        Task<bool> GetOpenedCashierSesionAsync(string branchId);

        Task<APIResponse> GetCashierSessionAsync(string SessionId);

        Task<APIResponse> GetCashierSessionAsync(QueryParamDTO queryParamDTO);

        Task<APIResponse> CloseCashierSessionAsync(UpdateCashierSessionDTO updateCashierSessionDTO);


    }
}
