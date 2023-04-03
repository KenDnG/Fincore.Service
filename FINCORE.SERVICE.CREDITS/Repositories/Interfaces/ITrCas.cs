using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.Model.Acquisition.CAS;
using FINCORE.LIBRARY.DTO.Model.Acquisition.CAS.ModelHelper;

namespace FINCORE.SERVICE.CREDITS.Repositories.Interfaces
{
    public interface ITrCas
    {
        Task<APIResponse> InsertTrCasMobilAsync(TrCasModels creditsModels);

        Task<APIResponse> InsertTrCasMotorAsync(TrCasModels creditsModels);

        Task<APIResponse> UpdateTrCasMobilAsync(TrCasModels creditsModels);

        Task<APIResponse> UpdateTrCasMotorAsync(TrCasModels creditsModels);

        Task<APIResponse> RecreateTrInstallmentsAsync(TrCasModels creditsModels);

        Task<APIResponse> GenerateCreditId(string branchId);

        Task<APIResponse> InsertGenerateCodeHistoryAsync(TrGenerateCodeHistory codeHistory);

        Task<APIResponse> GetTrCasByCreditId(string creditId);

        Task<APIResponse> GetTrReferencesByreditId(string creditId);

        Task<APIResponse> GetBankMasterAsync();

        Task<APIResponse> CheckBlacklistAsync(string ktpNo);

        Task<APIResponse> CheckApupptsAsync(ApupptParamModels apupptParam);

        Task<APIResponse> FindCreditIdByOrderIdAsync(string orderId);

        Task<APIResponse> GetNPPLamaROAsync(string ktpNo);

        Task<APIResponse> GetDataPoolingOrderAsync(string orderId);

        Task<APIResponse> CheckDataReferensiByNik(string nik);
        Task<APIResponse> GetDealerById(string dealerCode);
        Task<APIResponse> GetNikKonsumen(string employeeName, string branchId, bool isKonsol, bool includePos);
    }
}