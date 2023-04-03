using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsBPKBLocationRepository : IMsBPKBLocation
    {
        private MastersContext masterContext;

        public MsBPKBLocationRepository(MastersContext masterContext)
        {
            this.masterContext = masterContext;
        }
        public async Task<APIResponse> GetBPKBLocation(string branchid)
        {
            try
            {
                var data = this.masterContext.MsBpkbLocation.Where(w => w.BranchId == branchid && w.IsActive == true).Select(x => new { x.LocationCode, x.LocationName }).ToList();

                return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,Collection.Status.FAILED,ex.Message+ex.InnerException.Message,null);
            }
        }

    }
}
