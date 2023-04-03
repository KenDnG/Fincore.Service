using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsTypeOfServiceBureauNecessity
    {
        Task<APIResponse> GetTypeOfService();
    }
}
