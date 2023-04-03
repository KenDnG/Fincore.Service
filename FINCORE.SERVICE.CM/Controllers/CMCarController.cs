using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.CM.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.CM.Controllers
{
    [Route("api/v0/services/acquisition/cmcar/")]
    [ApiController]
    public class CMCarController : ControllerBase
    {
        private readonly ICMCar iCM;

        public CMCarController(ICMCar _iCM)
        {
            iCM = _iCM;
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>
        /// <param name="command"></param>
        [HttpPost("ef/insert-cm")]
        public async Task<IActionResult> InsertCM(TrCMCar TrCMModel)
        {
            return Ok(await iCM.InsertCM(TrCMModel));
        }

        [HttpPost("ef/approve-cm")]
        public async Task<IActionResult> ApproveCM(TrCMCar TrCMModel)
        {
            return Ok(await iCM.ApproveCM(TrCMModel));
        }

        [HttpGet("ef/get-history_approval")]
        public async Task<IActionResult> Get_History_Approval(string credit_id)
        {
            return Ok(await iCM.Get_History_Approval(credit_id));
        }

        [HttpGet("ef/get-approval_reason")]
        public async Task<IActionResult> Get_Approval_Reason(string UserId,string reason_id)
        {
            return Ok(await iCM.Get_Approval_Reason(UserId, reason_id));
        }

        [HttpGet("ef/get-Tr_CM")]
        public async Task<IActionResult> Get_Tr_CM(string credit_id)
        {
            return Ok(await iCM.Get_Tr_CM(credit_id));
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

        [HttpGet("ef/get-ms_general_parameter")]
        public async Task<IActionResult> Get_ms_general_parameter(string parameter)
        {
            return Ok(await iCM.Get_ms_general_parameter(parameter));
        }

        [HttpGet("ef/get-financing_package")]
        public async Task<IActionResult> Get_financing_package(string Tenor, string OTR, string ARType)
        {
            return Ok(await iCM.Get_financing_package(Tenor, OTR, ARType));
        }

        [HttpGet("ef/get-process-fee")]
        public async Task<IActionResult> Get_process_fee(string Tenor, string OTR, string InsCoverType, string BranchId)
        {
            return Ok(await iCM.Get_process_fee(Tenor, OTR, InsCoverType, BranchId));
        }

        [HttpGet("ef/get-installment")]
        public async Task<IActionResult> Get_installment(string asset_kind_id)
        {
            return Ok(await iCM.Get_installment(asset_kind_id));
        }

        [HttpGet("ef/get-life_insurance_kredit")]
        public async Task<IActionResult> Get_life_insurance_kredit(string OTR, string DP, string AdminFeeKredit, string ProvisiFeeKredit, string BiayaProsesKredit, string BranchIdAsuransi, string Tenor)
        {
            return Ok(await iCM.Get_life_insurance_kredit(OTR, DP, AdminFeeKredit, ProvisiFeeKredit, BiayaProsesKredit, BranchIdAsuransi, Tenor));
        }

        [HttpGet("ef/get-admin_provisi_interest_fee")]
        public async Task<IActionResult> Get_admin_provisi_interest_fee(string PackageID, string Tenor, string OTR, string ARType)
        {
            return Ok(await iCM.Get_admin_provisi_interest_fee(PackageID, Tenor, OTR, ARType));
        }

        [HttpGet("ef/get-process_provisi_ins")]
        public async Task<IActionResult> Get_process_provisi_ins(string BiayaProsesID, string Tenor, string OTR, string InsCoverType, string BranchId, string ItemYear, string credit_id, string modelid, string loss_fee, string loss_fee_kredit, string usage_type_id)
        {
            return Ok(await iCM.Get_process_provisi_ins(BiayaProsesID, Tenor, OTR, InsCoverType, BranchId, ItemYear, credit_id, modelid, loss_fee, loss_fee_kredit, usage_type_id));
        }

        [HttpGet("ef/get-branch_exception")]
        public async Task<IActionResult> Get_branch_exception(string BranchId)
        {
            return Ok(await iCM.Get_branch_exception(BranchId));
        }
    }
}