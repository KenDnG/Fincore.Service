using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.CM.Repositories.Interfaces;

namespace FINCORE.SERVICE.CM.Repositories.EF
{
    public class CMCarRepositoryEF : ICMCar
    {
        private AcquisitionContext acquisitionContext;

        public CMCarRepositoryEF(AcquisitionContext _acquisitionContext)
        {
            this.acquisitionContext = _acquisitionContext;
        }

        #region Save

        public async Task<APIResponse> InsertCM(TrCMCar TrCMModel)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_insert_cm_carAsync(
                            TrCMModel.credit_id,
                            TrCMModel.application_type_id,
                            TrCMModel.product_finance_id,
                            TrCMModel.is_item_new,
                            TrCMModel.asset_kind_id,
                            TrCMModel.item_brand_id,
                            TrCMModel.item_brand_type_id,
                            TrCMModel.asset_kind_class_id,
                            TrCMModel.year,
                            TrCMModel.product_id,
                            TrCMModel.dealer_code,
                            TrCMModel.surveyor_id,
                            TrCMModel.marketinghead_id,
                            TrCMModel.product_marketing_id,
                            TrCMModel.provenance_PO_id,
                            TrCMModel.CC,
                            TrCMModel.usage_type_id,
                            TrCMModel.account_receiveable,
                            TrCMModel.tipe_cover,
                            //TrCMModel.insurance_type_id,
                            TrCMModel.interest_rate_type_id
                            , TrCMModel.tenor
                            , TrCMModel.asset_cost
                            , TrCMModel.gross_down_payment
                            , TrCMModel.admin_fee
                            , TrCMModel.admin_fee_kredit
                            , TrCMModel.biaya_provisi
                            , TrCMModel.biaya_provisi_kredit
                            , TrCMModel.insurance_fee
                            , TrCMModel.uang_muka_murni_kons
                            , TrCMModel.jml_pembiayaan
                            , TrCMModel.amount_installment
                            , TrCMModel.effective_rate
                            , TrCMModel.flat_rate
                            , TrCMModel.disc_deposit
                            , TrCMModel.overdue_rate
                            , TrCMModel.CGSCabangNo
                            , TrCMModel.STNK_name_id
                            , TrCMModel.STNK_name_description
                            , TrCMModel.disc_type
                            , TrCMModel.TAC_max
                            , TrCMModel.komper_max
                            , TrCMModel.is_avalis
                            , TrCMModel.installment_type
                            , TrCMModel.package_id
                            , TrCMModel.biaya_proses_id
                            , TrCMModel.nominal_biaya_proses
                            , TrCMModel.nominal_biaya_proses_kredit
                            , TrCMModel.loss_fee
                            , TrCMModel.loss_fee_kredit
                            , TrCMModel.provisi_ins_fee
                            , TrCMModel.provisi_ins_fee_kredit
                            , TrCMModel.customer_pay_amount
                            , TrCMModel.installment_code
                            , TrCMModel.residual_value
                            , TrCMModel.discount_dealer
                            , TrCMModel.ongkos_BBN
                            , TrCMModel.ongkos_tagih
                            , TrCMModel.SubsidiFinance
                            , TrCMModel.SubsidiDealer
                            , TrCMModel.SubsidiMainDealer
                            , TrCMModel.SubsidiATPM
                            , TrCMModel.SubsidiPihakKetiga
                            , TrCMModel.SubsidiBunga
                            , TrCMModel.mega_insurance_fee
                            , TrCMModel.mega_insurance_fee_kredit
                            , TrCMModel.handphone_fee
                            , TrCMModel.handphone_fee_kredit
                            , TrCMModel.branch_id
                            , TrCMModel.is_life_ins                            
                            , TrCMModel.company_id
                            , TrCMModel.skema_id
                            , TrCMModel.perantara_type_id
                            , TrCMModel.agent_id
                            , TrCMModel.agent_name
                            , TrCMModel.ownership_account_type_id
                            , TrCMModel.bank_account_id_umc
                            , TrCMModel.bank_id_umc
                            , TrCMModel.bank_name_umc
                            , TrCMModel.account_no_umc
                            , TrCMModel.account_name_umc
                            , TrCMModel.CreatedBy
                            , TrCMModel.CreatedOn
                            , TrCMModel.LastUpdatedBy
                            , TrCMModel.LastUpdatedOn
                            )
                        )
                {
                };
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> ApproveCM(TrCMCar TrCMModel)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_approve_cm_carAsync(
                                                                TrCMModel.credit_id
                                                                , TrCMModel.reason_id
                                                                , TrCMModel.reason
                                                                , TrCMModel.StatusApproval
                                                                , TrCMModel.CreatedBy
                            )
                        )
                {
                };
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        #endregion Save

        #region GetData

        public async Task<APIResponse> Get_History_Approval(string credit_id)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_history_approvalAsync(credit_id));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }
        public async Task<APIResponse> Get_Approval_Reason(string UserId, string reason_id)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_approval_reasonAsync(UserId, reason_id));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_Tr_CM(string credit_id)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_tr_cm_carAsync(credit_id));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_application_type()
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_application_typeAsync());
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_product_finance()
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_product_financeAsync());
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_item_brand(string item_id)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_item_brandAsync(item_id));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_item_brand_type()
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_item_brand_typeAsync());
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_asset_kind_class(string item_id)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_asset_kind_classAsync(item_id));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_year(string item_id, string Item_Brand_Id, string asset_kind_class_id, string asset_type_id)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_cm_yearAsync(item_id, Item_Brand_Id, asset_kind_class_id, asset_type_id));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_product(string where)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_productAsync(where));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_product_marketing(string company_id, string asset_kind_id)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_product_marketingAsync(company_id, asset_kind_id));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_STNK_name(string where)
        {
            try
            {
                where = "-";

                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_STNK_nameAsync(where));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_provenance_pooling_order(string where)
        {
            try
            {
                where = "-";

                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_provenance_pooling_orderAsync(where));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_usage_type(string where)
        {
            try
            {
                where = "-";

                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_usage_typeAsync(where));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_account_receiveable(string where)
        {
            try
            {
                where = "-";

                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_account_receiveableAsync(where));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_insurance_cover_type(string where)
        {
            try
            {
                where = "-";

                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_insurance_cover_typeAsync(where));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_insurance_type(string where)
        {
            try
            {
                where = "-";

                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_insurance_typeAsync(where));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_interest_rate_type(string where)
        {
            try
            {
                where = "-";

                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_interest_rate_typeAsync(where));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_asset_kind(string asset_kind_id)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_asset_kindAsync(asset_kind_id));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_InsuranceFee(string asset_kind_id, string OTR, string CompanyId, string BranchId, string Tenor)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_InsuranceFeeAsync(asset_kind_id, OTR, CompanyId, BranchId, Tenor));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_general_parameter(string parameter)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_general_parameterAsync(parameter));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_financing_package(string Tenor, string OTR, string ARType)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_financing_packageAsync(Tenor, OTR, ARType));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_process_fee(string Tenor, string OTR, string InsCoverType, string BranchId)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_process_feeAsync(Tenor, OTR, InsCoverType, BranchId));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_installment(string asset_kind_id)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_installmentAsync(asset_kind_id));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_life_insurance_kredit(string OTR, string DP, string AdminFeeKredit, string ProvisiFeeKredit, string BiayaProsesKredit, string BranchIdAsuransi, string Tenor)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_life_insurance_kreditAsync(OTR, DP, AdminFeeKredit, ProvisiFeeKredit, BiayaProsesKredit, BranchIdAsuransi, Tenor));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_admin_provisi_interest_fee(string PackageID, string Tenor, string OTR, string ARType)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_admin_provisi_interest_feeAsync(PackageID, Tenor, OTR, ARType));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_process_provisi_ins(string BiayaProsesID, string Tenor, string OTR, string InsCoverType, string BranchId, string ItemYear, string credit_id, string modelid, string loss_fee, string loss_fee_kredit, string usage_type_id)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_process_provisi_insAsync(BiayaProsesID, Tenor, OTR, InsCoverType, BranchId, ItemYear, credit_id, modelid, loss_fee, loss_fee_kredit, usage_type_id));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_branch_exception(string BranchId)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_branch_exceptionAsync(BranchId));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        #endregion GetData

    }
}