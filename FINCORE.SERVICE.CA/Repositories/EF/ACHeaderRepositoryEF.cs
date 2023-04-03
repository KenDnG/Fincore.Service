using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.LIBRARY.DTO.Model.Response;
using FINCORE.SERVICE.CA.Repositories.Interfaces;

namespace FINCORE.SERVICE.CA.Repositories.EF
{
    public class ACHeaderRepositoryEF : IACHeader
    {
        private AcquisitionContext acquisitionContext;

        public ACHeaderRepositoryEF(AcquisitionContext _acquisitionContext)
        {
            this.acquisitionContext = _acquisitionContext;
        }

        public async Task<APIResponse> GetAnalisa(string Id)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_analisa_cmo_caAsync(Id));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> InsertAnalisa(ACHeaderModel ACHeaderModel)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_insert_analisa_cmo_caAsync(
                            ACHeaderModel.CASId,
                            ACHeaderModel.Capacity,
                            ACHeaderModel.Capital,
                            ACHeaderModel.Character,
                            ACHeaderModel.Condition,
                            ACHeaderModel.Collateral,
                            ACHeaderModel.Strenght,
                            ACHeaderModel.Weakness,
                            ACHeaderModel.created_by,
                            ACHeaderModel.created_on,
                            ACHeaderModel.last_updated_by,
                            ACHeaderModel.last_updated_on
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

        public async Task<APIResponse> UpdateAnalisa(ACHeaderModel ACHeaderModel)
        {
            ErrorModel errorModel = new ErrorModel();
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_update_analisa_cmo_caAsync(
                            ACHeaderModel.CASId,
                            ACHeaderModel.Capacity,
                            ACHeaderModel.Capital,
                            ACHeaderModel.Character,
                            ACHeaderModel.Condition,
                            ACHeaderModel.Collateral,
                            ACHeaderModel.Strenght,
                            ACHeaderModel.Weakness,
                            ACHeaderModel.last_updated_by,
                            ACHeaderModel.last_updated_on
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
    }
}