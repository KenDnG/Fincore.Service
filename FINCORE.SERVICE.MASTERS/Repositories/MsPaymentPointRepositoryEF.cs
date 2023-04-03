using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsPaymentPointRepositoryEF : IMsPaymentPoint
    {
        private MastersContext mastersContext;

        public MsPaymentPointRepositoryEF(MastersContext mastersContext)
        {
            this.mastersContext = mastersContext;
        }

        public async Task<APIResponse> GetPaymentPoint(int paymentTypeId)
        {
            try
            {
                var data = mastersContext.MsPaymentPoint
                                                .Where(m => m.IsActive.Equals(true)
                                                && m.PaymentTypeId.Equals(paymentTypeId))
                                                .ToList();
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }
    }
}