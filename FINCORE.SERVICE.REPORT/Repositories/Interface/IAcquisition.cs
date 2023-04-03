using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.REPORT.Repositories.Interface
{
    public interface IAcquisition
    {
        Task<APIResponse> PrintPOMobilAsync(string poNo, string branchId, string userId);

        Task<APIResponse> PrintPOMotorAsync(string poNo, string branchId, string userId);
    }
}