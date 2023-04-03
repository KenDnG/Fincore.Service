using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsLocation
    {
        Task<APIResponse> GetLocationByIdAsync(int locationId);

        Task<APIResponse> GetLocationAsync();
    }
}