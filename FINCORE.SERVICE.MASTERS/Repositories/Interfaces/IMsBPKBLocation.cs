using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsBPKBLocation
    {
        Task<APIResponse> GetBPKBLocation(string branchid);
    }
}
