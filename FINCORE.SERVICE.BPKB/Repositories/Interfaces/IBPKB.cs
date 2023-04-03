using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.BPKB.Models;
namespace FINCORE.SERVICE.BPKB.Repositories.Interfaces
{
    public interface IBPKB
    {
        Task<APIResponse> InsertBPKB(BPKBCustomModel BPKBModel);
        Task<APIResponse> UpdateBPKB(TrBpkb BPKBModel);
        Task<APIResponse> DeleteBPKB(TrBpkb BPKBModel);
        Task<APIResponse> GetBPKB(TrBpkb BPKBModel);
        Task<APIResponse> SaveBPKBPinjam(TrBpkbLoan Model);
        Task<APIResponse> ReEntryBPKB(BPKBCustomModel Model);
        Task<APIResponse> OutBPKB(BPKBCustomModel Model);
        Task<APIResponse> GetCM(TrBpkb Model);
        Task<APIResponse> GetBASTData(TrBpkb Model);
        Task<APIResponse> GetSKData(TrBpkb Model);
        Task<APIResponse> Get3PData(TrBpkb Model);
        Task<APIResponse> UpdatePrintBPKB(TrBpkb Model);
        Task<APIResponse> GetPinjamData(TrBpkb Model);
        Task<APIResponse> GetBASTINData(TrBpkb Model);
    }
}
