using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.Model.Acquisition;

namespace FINCORE.SERVICE.CA.Repositories.Interfaces
{
    public interface IACHeader
    {
        Task<APIResponse> GetAnalisa(string Id);

        Task<APIResponse> InsertAnalisa(ACHeaderModel ACHeaderModel);

        Task<APIResponse> UpdateAnalisa(ACHeaderModel ACHeaderModel);
    }
}