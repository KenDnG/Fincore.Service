using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsCustomerType
    {
        Task<APIResponse> GetCustomerTypeAsync();
    }
}