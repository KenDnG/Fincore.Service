using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.CM.Repositories.Interfaces;

namespace FINCORE.SERVICE.CM.Repositories.EF
{
    public class CMRepositoryEF : ICM
    {
        private AcquisitionContext acquisitionContext;

        public CMRepositoryEF(AcquisitionContext _acquisitionContext)
        {
            this.acquisitionContext = _acquisitionContext;
        }

        #region Save

        public async Task<APIResponse> InsertCM(TrCM TrCMModel)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_insert_cmAsync(
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
                            TrCMModel.insurance_type_id,
                            TrCMModel.installment_id,
                            TrCMModel.interest_rate_type_id
                            , TrCMModel.tenor
                            , TrCMModel.asset_cost
                            , TrCMModel.gross_down_payment
                            , TrCMModel.admin_fee
                            , TrCMModel.biaya_provisi
                            , TrCMModel.insurance_fee
                            , TrCMModel.uang_muka_murni_kons
                            , TrCMModel.jml_pembiayaan
                            , TrCMModel.amount_installment
                            , Convert.ToDouble(TrCMModel.effective_rate)
                            , Convert.ToDouble(TrCMModel.flat_rate)
                            , TrCMModel.disc_deposit
                            , TrCMModel.overdue_rate
                            , TrCMModel.CGSCabangNo
                            , TrCMModel.STNK_name_id
                            , TrCMModel.STNK_name_description
                            , TrCMModel.disc_type
                            , TrCMModel.TAC_max
                            , TrCMModel.komper_max
                            , TrCMModel.branch_id
                            , TrCMModel.company_id
                            , TrCMModel.deposit_installment
                            , TrCMModel.is_topup_ms
                            , TrCMModel.old_npp
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
                        );
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> ApproveCM(TrCM TrCMModel)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_approve_cmAsync(
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

        public async Task<APIResponse> RFACM(TrCM TrCMModel)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_rfa_cmAsync(
                                                                TrCMModel.credit_id
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

        public async Task<APIResponse> InsertCM_Photo_Detail(Tr_CM_photo_detail Tr_CM_photo_detailModel)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_insert_cm_photo_detailAsync(Tr_CM_photo_detailModel.credit_id
                                                                                                , Tr_CM_photo_detailModel.photo_type_id
                                                                                                , Tr_CM_photo_detailModel.photo_id
                                                                                                , Tr_CM_photo_detailModel.filename
                                                                                                , Tr_CM_photo_detailModel.filePath
                                                                                                , Tr_CM_photo_detailModel.StatusApproval
                                                                                                , Tr_CM_photo_detailModel.CreatedBy
                                                                                                , Tr_CM_photo_detailModel.CreatedOn
                                                                                                , Tr_CM_photo_detailModel.LastUpdatedBy
                                                                                                , Tr_CM_photo_detailModel.LastUpdatedOn)
                        );
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

        public async Task<APIResponse> Get_tipe_perantara()
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_tipe_perantaraAsync());
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_account_owner()
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_account_ownerAsync());
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_Tr_CM(string credit_id, string CreatedBy)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_tr_cmAsync(credit_id, CreatedBy));
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

        public async Task<APIResponse> Get_MarketPrice(string asset_kind_id, string CompanyId, string BranchId, string asset_type_id, string Year, string credit_id, string tipe_kerja_sama)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_MarketPriceAsync(asset_kind_id, CompanyId, BranchId, asset_type_id, Year, credit_id, tipe_kerja_sama));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_Tr_CM_photo_detail(string credit_id, string photo_type_id, string photo_id)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_tr_cm_photo_detailAsync(credit_id, photo_type_id, photo_id));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> Get_ms_photo_type()
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ms_photo_typeAsync());
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

        #endregion GetData

    }
}