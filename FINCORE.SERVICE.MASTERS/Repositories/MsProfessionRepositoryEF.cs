using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsProfessionRepositoryEF : IMsProfessions
    {
        private MastersContext mastersContext;

        public MsProfessionRepositoryEF(MastersContext _mastersContext)
            => this.mastersContext = _mastersContext;

        public async Task<APIResponse> GetProfessionAsync()
        {
            try
            {
                var data = await mastersContext.GetProcedures().sp_get_professionAsync();
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }
    }
}