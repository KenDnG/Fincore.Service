using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.CA.Interfaces
{
    public interface ICA
    {
        Task<APIResponse> GetCAList();
    }
}