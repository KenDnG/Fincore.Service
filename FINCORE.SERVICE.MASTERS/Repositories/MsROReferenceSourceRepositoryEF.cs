using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsROReferenceSourceRepositoryEF : IMsROReferenceSource
    {
        private MastersContext mastersContext;

        public MsROReferenceSourceRepositoryEF(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
        }

        public async Task<APIResponse> GetReferenceSourceAsync()
        {
            try
            {
                var data = mastersContext.MsRepeatOrderReferenceSource
                                                .Where(m => m.IsActive.Equals(true))
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