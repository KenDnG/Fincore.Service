using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.Model.Acquisition;

namespace FINCORE.SERVICE.CM.Repositories.Interfaces
{
    public interface ICMCar
    {
        Task<APIResponse> InsertCM(TrCMCar TrCMModel);

        Task<APIResponse> ApproveCM(TrCMCar TrCMModel);

        Task<APIResponse> Get_History_Approval(string credit_id);
        Task<APIResponse> Get_Approval_Reason(string UserId, string reason_id);
        Task<APIResponse> Get_Tr_CM(string credit_id);

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

        Task<APIResponse> Get_ms_general_parameter(string parameter);

        Task<APIResponse> Get_financing_package(string Tenor, string OTR, string ARType);

        Task<APIResponse> Get_process_fee(string Tenor, string OTR, string InsCoverType, string BranchId);

        Task<APIResponse> Get_installment(string asset_kind_id);

        Task<APIResponse> Get_life_insurance_kredit(string OTR, string DP, string AdminFeeKredit, string ProvisiFeeKredit, string BiayaProsesKredit, string BranchIdAsuransi, string Tenor);

        Task<APIResponse> Get_admin_provisi_interest_fee(string PackageID, string Tenor, string OTR, string ARType);

        Task<APIResponse> Get_process_provisi_ins(string BiayaProsesID, string Tenor, string OTR, string InsCoverType, string BranchId, string ItemYear, string credit_id, string modelid, string loss_fee, string loss_fee_kredit, string usage_type_id);

        Task<APIResponse> Get_branch_exception(string BranchId);
    }
}