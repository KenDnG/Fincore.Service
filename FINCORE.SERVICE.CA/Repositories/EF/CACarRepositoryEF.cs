using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.CA.Repositories.Interfaces;

namespace FINCORE.SERVICE.CA.Repositories.EF
{
    public class CACarRepositoryEF : ICACar
    {
        private AcquisitionContext acquisitionContext;

        public CACarRepositoryEF(AcquisitionContext _acquisitionContext)
        {
            this.acquisitionContext = _acquisitionContext;
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

        public async Task<APIResponse> Insertcmo_analisa(Tr_CAS_AC_header Tr_CAS_AC_headerModel)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_insert_cmo_analisa_ca_carAsync(Tr_CAS_AC_headerModel.credit_id
                                                                                            , Tr_CAS_AC_headerModel.Capacity
                                                                                            , Tr_CAS_AC_headerModel.Capital
                                                                                            , Tr_CAS_AC_headerModel.Character
                                                                                            , Tr_CAS_AC_headerModel.Condition
                                                                                            , Tr_CAS_AC_headerModel.Collateral
                                                                                            , Tr_CAS_AC_headerModel.advantage_notes
                                                                                            , Tr_CAS_AC_headerModel.deficiency_notes
                                                                                            , Tr_CAS_AC_headerModel.StatusApproval
                                                                                            , Tr_CAS_AC_headerModel.CreatedBy
                                                                                            , Tr_CAS_AC_headerModel.LastUpdatedBy)
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

        public async Task<APIResponse> Get_ca_car_detail(string credit_id, string CreatedBy)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_ca_car_detailAsync(credit_id, CreatedBy));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }
    }
}