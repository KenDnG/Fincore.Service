using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.Model.Acquisition.NPP;

namespace FINCORE.SERVICE.NPP.Repositories.Interfaces
{
    public interface ITrNPP
    {
        Task<TrNpp> GetNppRelationalById(string creditId);

        Task<APIResponse> GetNppDataById(string creditId);

        Task<APIResponse> GetNppViewById(string creditId, string userId);
        Task<APIResponse> GetNppEditById(string creditId);

        Task<APIResponse> InsertMotorcyleTrNPPAsync(TrNppRequest NPPRequest);

        Task<APIResponse> UpdateMotorcycleTrNPPAsync(TrNppRequest NPPRequest);

        Task<APIResponse> InsertCarTrNPPAsync(TrNppRequest NPPRequest);

        Task<APIResponse> UpdateCarTrNPPAsync(TrNppRequest NPPRequest);

        Task<APIResponse> ApprovalNPPAsync(TrNppRequest NPPRequest);

        Task<APIResponse> CheckRapindo(string ChassisNo, string BranchName, string BranchId, string UserName, string CompanyId);
    }
}