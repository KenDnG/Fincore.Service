using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.Model.Acquisition;

namespace FINCORE.SERVICE.CA.Repositories.Interfaces
{
    public interface ITrCAS_CreditAnalyst
    {
        Task<APIResponse> SaveCAS_CreditAnalyst(TrCAS_CreditAnalyst trCAS_CreditAnalyst);
    }
}