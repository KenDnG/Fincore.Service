using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsROApplicantRelation
    {
        Task<APIResponse> GetROApplicantRelationAsync();
    }
}