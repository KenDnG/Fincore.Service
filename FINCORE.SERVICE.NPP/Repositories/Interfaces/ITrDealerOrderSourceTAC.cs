using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.NPP.Repositories.Interfaces
{
    public interface ITrDealerOrderSourceTAC
    {
        Task<APIResponse> GetRealDataByCreditId(string creditId);

        Task<APIResponse> GetManipulateDataByCreditId(string creditId);
    }
}