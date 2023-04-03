using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.CA.Repositories.Interfaces
{
    public interface ICMODealer
    {
        Task<APIResponse> GetListCMO(string Id);

        Task<APIResponse> GetListDealer(string Id);

        Task<APIResponse> GetCMODealer(string Id);
    }
}