using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.Model.Acquisition;

namespace FINCORE.SERVICE.CA.Repositories.Interfaces
{
    public interface ICACar
    {
        Task<APIResponse> InsertCM_Photo_Detail(Tr_CM_photo_detail Tr_CM_photo_detailModel);

        Task<APIResponse> Insertcmo_analisa(Tr_CAS_AC_header Tr_CAS_AC_headerModel);

        Task<APIResponse> Get_Tr_CM_photo_detail(string credit_id, string photo_type_id, string photo_id);

        Task<APIResponse> Get_ms_photo_type();

        Task<APIResponse> Get_ca_car_detail(string credit_id, string CreatedBy);
    }
}