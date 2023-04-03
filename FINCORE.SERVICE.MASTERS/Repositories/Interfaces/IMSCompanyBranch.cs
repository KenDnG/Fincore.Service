using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMSCompanyBranch
    {
        Task<APIResponse> GetCompanyBranch(string company_id, string NIK);
        Task<APIResponse> GetBranchDetail(string company_id);
    }
}