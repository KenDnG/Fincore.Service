using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsROCategoryRepositoryEF : IMsROCategory
    {
        private MastersContext mastersContext;

        public MsROCategoryRepositoryEF(MastersContext _mastersContext)
            => this.mastersContext = _mastersContext;

        public async Task<APIResponse> GetROCategoryAsync()
        {
            try
            {
                var data = mastersContext.MsRepeatOrderCategory
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