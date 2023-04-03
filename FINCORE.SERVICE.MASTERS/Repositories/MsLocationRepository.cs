using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories
{
    public class MsLocationRepository : IMsLocation
    {
        private MastersContext masterContext;

        public MsLocationRepository(MastersContext masterContext)
        {
            this.masterContext = masterContext;
        }

        public async Task<APIResponse> GetLocationAsync()
        {
            var data = await masterContext.GetProcedures().sp_get_locationAsync();
            return new APIResponse(data);
        }

        public async Task<APIResponse> GetLocationByIdAsync(int locationId)
        {
            var data = await masterContext.GetProcedures().sp_get_location_byidAsync(locationId);
            return new APIResponse(data);
        }
    }
}