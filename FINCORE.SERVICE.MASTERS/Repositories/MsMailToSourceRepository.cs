using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories
{
    public class MsMailToSourceRepository : IMsMailToSource
    {
        private MastersContext mastersContext;

        public MsMailToSourceRepository(MastersContext mastersContext)
        {
            this.mastersContext = mastersContext;
        }

        public async Task<APIResponse> GetMailToSourceAsync()
        {
            var data = mastersContext.MsMailToSource.Where(m => m.IsActive.Equals(true)).ToList();
            return new APIResponse(data);
        }

        public async Task<APIResponse> GetMailToSourceByIdAsync(int id)
        {
            var data = mastersContext.MsMailToSource.Where(m => m.IsActive.Equals(true) && m.MailToSourceId.Equals(id))
                            .ToList();
            return new APIResponse(data);
        }
    }
}