using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsPaymentPoint
    {
        Task<APIResponse> GetPaymentPoint(int paymentTypeId);
    }
}