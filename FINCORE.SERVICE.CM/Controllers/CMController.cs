using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.CM.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.CM.Controllers
{
    [Route("api/v0/services/acquisition/cm/")]
    [ApiController]
    public class CMController : ControllerBase
    {
        private readonly ICM iCM;

        public CMController(ICM _iCM)
        {
            iCM = _iCM;
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>
        /// <param name="command"></param>
        [HttpPost("ef/insert-cm")]
        public async Task<IActionResult> InsertCM(TrCM TrCMModel)
        {
            return Ok(await iCM.InsertCM(TrCMModel));
        }

        [HttpPost("ef/approve-cm")]
        public async Task<IActionResult> ApproveCM(TrCM TrCMModel)
        {
            return Ok(await iCM.ApproveCM(TrCMModel));
        }

        [HttpPost("ef/rfa-cm")]
        public async Task<IActionResult> RFACM(TrCM TrCMModel)
        {
            return Ok(await iCM.RFACM(TrCMModel));
        }

        [HttpGet("ef/get-Tr_CM")]
        public async Task<IActionResult> Get_Tr_CM(string credit_id, string CreatedBy)
        {
            return Ok(await iCM.Get_Tr_CM(credit_id, CreatedBy));
        }

        [HttpGet("ef/get-approval_reason")]
        public async Task<IActionResult> Get_Approval_Reason(string UserId, string reason_id)
        {
            return Ok(await iCM.Get_Approval_Reason(UserId, reason_id));
        }

        [HttpGet("ef/get-history_approval")]
        public async Task<IActionResult> Get_History_Approval(string credit_id)
        {
            return Ok(await iCM.Get_History_Approval(credit_id));
        }

        [HttpGet("ef/get-ms_application_type")]
        public async Task<IActionResult> Get_ms_application_type()
        {
            return Ok(await iCM.Get_ms_application_type());
        }

        [HttpGet("ef/get-ms_product_finance")]
        public async Task<IActionResult> Get_ms_product_finance()
        {
            return Ok(await iCM.Get_ms_product_finance());
        }

        [HttpGet("ef/get-ms_item_brand")]
        public async Task<IActionResult> Get_ms_item_brand(string item_id)
        {
            return Ok(await iCM.Get_ms_item_brand(item_id));
        }

        [HttpGet("ef/get-ms_item_brand_type")]
        public async Task<IActionResult> Get_ms_item_brand_type()
        {
            return Ok(await iCM.Get_ms_item_brand_type());
        }

        [HttpGet("ef/get-ms_asset_kind_class")]
        public async Task<IActionResult> Get_ms_asset_kind_class(string item_id)
        {
            return Ok(await iCM.Get_ms_asset_kind_class(item_id));
        }

        [HttpGet("ef/get-year")]
        public async Task<IActionResult> Get_year(string item_id, string Item_Brand_Id, string asset_kind_class_id, string asset_type_id)
        {
            return Ok(await iCM.Get_year(item_id, Item_Brand_Id, asset_kind_class_id, asset_type_id));
        }

        [HttpGet("ef/get-ms_product")]
        public async Task<IActionResult> Get_ms_product(string where)
        {
            return Ok(await iCM.Get_ms_product(where));
        }

        [HttpGet("ef/get-ms_product_marketing")]
        public async Task<IActionResult> Get_ms_product_marketing(string company_id, string asset_kind_id)
        {
            return Ok(await iCM.Get_ms_product_marketing(company_id, asset_kind_id));
        }

        [HttpGet("ef/get-ms_STNK_name")]
        public async Task<IActionResult> Get_ms_STNK_name(string where)
        {
            return Ok(await iCM.Get_ms_STNK_name(where));
        }

        [HttpGet("ef/get-ms_provenance_pooling_order")]
        public async Task<IActionResult> Get_ms_provenance_pooling_order(string where)
        {
            return Ok(await iCM.Get_ms_provenance_pooling_order(where));
        }

        [HttpGet("ef/get-ms_usage_type")]
        public async Task<IActionResult> Get_ms_usage_type(string where)
        {
            return Ok(await iCM.Get_ms_usage_type(where));
        }

        [HttpGet("ef/get-ms_account_receiveable")]
        public async Task<IActionResult> Get_ms_account_receiveable(string where)
        {
            return Ok(await iCM.Get_ms_account_receiveable(where));
        }

        [HttpGet("ef/get-ms_insurance_cover_type")]
        public async Task<IActionResult> Get_ms_insurance_cover_type(string where)
        {
            return Ok(await iCM.Get_ms_insurance_cover_type(where));
        }

        [HttpGet("ef/get-ms_insurance_type")]
        public async Task<IActionResult> Get_ms_insurance_type(string where)
        {
            return Ok(await iCM.Get_ms_insurance_type(where));
        }

        [HttpGet("ef/get-ms_interest_rate_type")]
        public async Task<IActionResult> Get_ms_interest_rate_type(string where)
        {
            return Ok(await iCM.Get_ms_interest_rate_type(where));
        }

        [HttpGet("ef/get-ms_asset_kind")]
        public async Task<IActionResult> Get_ms_asset_kind(string asset_kind_id)
        {
            return Ok(await iCM.Get_ms_asset_kind(asset_kind_id));
        }

        [HttpGet("ef/get-InsuranceFee")]
        public async Task<IActionResult> Get_InsuranceFee(string asset_kind_id, string OTR, string CompanyId, string BranchId, string Tenor)
        {
            return Ok(await iCM.Get_InsuranceFee(asset_kind_id, OTR, CompanyId, BranchId, Tenor));
        }

        [HttpGet("ef/get-MarketPrice")]
        public async Task<IActionResult> Get_MarketPrice(string asset_kind_id, string CompanyId, string BranchId, string asset_type_id, string Year, string credit_id, string tipe_kerja_sama)
        {
            return Ok(await iCM.Get_MarketPrice(asset_kind_id, CompanyId, BranchId, asset_type_id, Year, credit_id, tipe_kerja_sama));
        }

        [HttpPost("ef/insert-cm_photo_detail")]
        public async Task<IActionResult> InsertCM_Photo_Detail(Tr_CM_photo_detail Tr_CM_photo_detailModel)
        {
            return Ok(await iCM.InsertCM_Photo_Detail(Tr_CM_photo_detailModel));
        }

        [HttpGet("ef/get-Tr_CM_photo_detail")]
        public async Task<IActionResult> Get_Tr_CM_photo_detail(string credit_id, string photo_type_id, string photo_id)
        {
            return Ok(await iCM.Get_Tr_CM_photo_detail(credit_id, photo_type_id, photo_id));
        }

        [HttpGet("ef/get-ms_photo_type")]
        public async Task<IActionResult> Get_ms_photo_type()
        {
            return Ok(await iCM.Get_ms_photo_type());
        }

        [HttpGet("ef/get-ms_general_parameter")]
        public async Task<IActionResult> Get_ms_general_parameter(string parameter)
        {
            return Ok(await iCM.Get_ms_general_parameter(parameter));
        }

        [HttpGet("ef/get-tipe_perantara")]
        public async Task<IActionResult> Get_tipe_perantara()
        {
            return Ok(await iCM.Get_tipe_perantara());
        }

        [HttpGet("ef/get-account_owner")]
        public async Task<IActionResult> Get_account_owner()
        {
            return Ok(await iCM.Get_account_owner());
        }
    }
}