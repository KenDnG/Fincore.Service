using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;

namespace FINCORE.SERVICE.NPP.Repositories.Interfaces
{
    public interface ITrCM
    {
        Task<TrCm> GetCMByCreditId(string creditId);

        Task<APIResponse> GetProcessCMByCreditId(string creditId);
    }
}