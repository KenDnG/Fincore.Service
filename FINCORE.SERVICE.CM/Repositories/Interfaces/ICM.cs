using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.Model.Acquisition;

namespace FINCORE.SERVICE.CM.Repositories.Interfaces
{
    public interface ICM
    {
        Task<APIResponse> InsertCM(TrCM TrCMModel);

        Task<APIResponse> ApproveCM(TrCM TrCMModel);

        Task<APIResponse> RFACM(TrCM TrCMModel);

        Task<APIResponse> Get_account_owner();

        Task<APIResponse> Get_tipe_perantara();
        Task<APIResponse> Get_Approval_Reason(string UserId, string reason_id);
        Task<APIResponse> Get_History_Approval(string credit_id);

        Task<APIResponse> Get_Tr_CM(string credit_id, string CreatedBy);

        Task<APIResponse> Get_ms_asset_kind(string asset_kind_id);

        Task<APIResponse> Get_ms_application_type();

        Task<APIResponse> Get_ms_product_finance();

        Task<APIResponse> Get_ms_item_brand(string item_id);

        Task<APIResponse> Get_ms_item_brand_type();

        Task<APIResponse> Get_ms_asset_kind_class(string item_id);

        Task<APIResponse> Get_year(string item_id, string Item_Brand_Id, string asset_kind_class_id, string asset_type_id);

        Task<APIResponse> Get_ms_product(string where);

        Task<APIResponse> Get_ms_product_marketing(string company_id, string asset_kind_id);

        Task<APIResponse> Get_ms_STNK_name(string where);

        Task<APIResponse> Get_ms_provenance_pooling_order(string where);

        Task<APIResponse> Get_ms_usage_type(string where);

        Task<APIResponse> Get_ms_account_receiveable(string where);

        Task<APIResponse> Get_ms_insurance_cover_type(string where);

        Task<APIResponse> Get_ms_insurance_type(string where);

        Task<APIResponse> Get_ms_interest_rate_type(string where);

        Task<APIResponse> Get_InsuranceFee(string asset_kind_id, string OTR, string CompanyId, string BranchId, string Tenor);

        Task<APIResponse> Get_MarketPrice(string asset_kind_id, string CompanyId, string BranchId, string asset_type_id, string Year, string credit_id, string tipe_kerja_sama);

        Task<APIResponse> InsertCM_Photo_Detail(Tr_CM_photo_detail Tr_CM_photo_detailModel);

        Task<APIResponse> Get_Tr_CM_photo_detail(string credit_id, string photo_type_id, string photo_id);

        Task<APIResponse> Get_ms_photo_type();

        Task<APIResponse> Get_ms_general_parameter(string parameter);
    }
}