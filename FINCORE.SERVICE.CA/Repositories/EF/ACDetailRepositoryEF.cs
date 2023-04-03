using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.LIBRARY.DTO.Model.Response;
using FINCORE.SERVICE.CA.Repositories.Interfaces;

namespace FINCORE.SERVICE.CA.Repositories.EF
{
    public class ACDetailRepositoryEF : IACDetail
    {
        private AcquisitionContext acquisitionContext;

        public ACDetailRepositoryEF(AcquisitionContext _acquisitionContext)
        {
            this.acquisitionContext = _acquisitionContext;
        }

        public async Task<APIResponse> GetFoto(string Id, string PhotoTypeID)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_foto_caAsync(Id, PhotoTypeID));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetFotoCek(string Id, string PhotoID, string PhotoTypeID)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_fotocek_caAsync(Id, PhotoID, PhotoTypeID));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> InsertFoto(Year ACDetailModel)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_insert_foto_caAsync(
                           ACDetailModel.CASId,
                           ACDetailModel.filename,
                           ACDetailModel.filePath,
                           ACDetailModel.PhotoTypeID,
                           ACDetailModel.PhotoID,
                           ACDetailModel.created_by,
                           ACDetailModel.created_on,
                           ACDetailModel.last_updated_by,
                           ACDetailModel.last_updated_on
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

        public async Task<APIResponse> UpdateFoto(Year ACDetailModel)
        {
            ErrorModel errorModel = new ErrorModel();
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_update_foto_caAsync(
                           ACDetailModel.CASId,
                           ACDetailModel.filename,
                           ACDetailModel.filePath,
                           ACDetailModel.PhotoTypeID,
                           ACDetailModel.PhotoID,
                           ACDetailModel.created_by,
                           ACDetailModel.created_on,
                           ACDetailModel.last_updated_by,
                           ACDetailModel.last_updated_on
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