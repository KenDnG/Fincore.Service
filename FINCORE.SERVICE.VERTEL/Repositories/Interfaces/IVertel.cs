using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.Model.Acquisition.Vertel;
using FINCORE.SERVICE.VERTEL.Models;
using TrVerificationConsumenModels = FINCORE.LIBRARY.DTO.Model.Acquisition.Vertel.TrVerificationConsumenModels;

namespace FINCORE.SERVICE.VERTEL.Repositories.Interfaces
{
    public interface IVertel
    {
        Task<APIResponse> InsertVertel(TrVerificationConsumenModels trVerificationConsumen);

        Task<APIResponse> UpdateVertel(TrVerificationConsumenModels trVerificationConsumen);
        
        Task<APIResponse> DeleteVertel(CfverifikasiKonsumen CfverifikasiKonsumen);

        Task<APIResponse> GetDataVertelSelect(CfverifikasiKonsumen CfverifikasiKonsumen);

        Task<APIResponse> GetVertelList();

        Task<APIResponse> GetVertelListPagination( string? SearchTerm, int PageIndex, int PageSize, int? RecordCount );

        Task<APIResponse> GetVertelLookupNPP(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount);

        Task<APIResponse> GetDocField(string CMNo);
        Task<APIResponse> GetDataVerifikasiKonsumen(string VerifikasiNo);
        Task<APIResponse> GetPriceAwal(string creditId);
        Task<APIResponse> GetApproverReason(string typeApproval);
        Task<APIResponse> ApprovalProcess(VertelApprovalModels data);
    }
}
