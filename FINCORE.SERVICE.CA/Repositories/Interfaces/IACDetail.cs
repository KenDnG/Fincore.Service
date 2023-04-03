using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.Model.Acquisition;

namespace FINCORE.SERVICE.CA.Repositories.Interfaces
{
    public interface IACDetail
    {
        Task<APIResponse> GetFoto(string Id, string PhotoTypeID);

        Task<APIResponse> GetFotoCek(string Id, string PhotoID, string PhotoTypeID);

        Task<APIResponse> InsertFoto(Year ACDetailModel);

        Task<APIResponse> UpdateFoto(Year ACDetailModel);
    }
}