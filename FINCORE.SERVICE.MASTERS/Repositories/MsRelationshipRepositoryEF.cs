using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsRelationshipRepositoryEF : IMsRelationship
    {
        private MastersContext mastersContext;

        public MsRelationshipRepositoryEF(MastersContext _mastersContext)
                => this.mastersContext = _mastersContext;

        public async Task<APIResponse> GetRelationshipAsync()
        {
            try
            {
                var data = await mastersContext.GetProcedures().sp_get_relationshipAsync();
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message);
            }
        }
    }
}