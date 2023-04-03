using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsMonthlyOtherInstallmentRepositoryEF : IMsMonthlyOtherInstallment
    {
        private MastersContext mastersContext;

        public MsMonthlyOtherInstallmentRepositoryEF(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
        }

        public async Task<APIResponse> GetOtherInstallmentAsync()
        {
            try
            {
                var data = await mastersContext.GetProcedures().sp_get_monthly_other_installmentAsync();
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }
    }
}