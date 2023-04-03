using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository;
using FINCORE.HELPER.LIBRARY.Helper;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.CA.Repositories.Interfaces;
using FINCORE.SERVICE.CAS.DbContexts;

namespace FINCORE.SERVICE.CA.Repositories.ADO
{
    public class ACDetailRepositoryADO : BaseRepository<Year>, IACDetail
    {
        private DbContext dbContext;
        private ConnectionConfigServices connectionConfigServices;
        private StoreProcedure storeProcedure;

        public ACDetailRepositoryADO(DbContext _context,
           ConnectionConfigServices _connectionConfigServices) : base(_context)
        {
            dbContext = _context;
            connectionConfigServices = _connectionConfigServices;
        }

        public ACDetailRepositoryADO(DbContext _context) : base(_context)
        {
            dbContext = _context;
        }

        public async Task<APIResponse> InsertFoto(Year ACDetailModel)
        {
            string errorMessage = default;
            storeProcedure = new StoreProcedure(dbContext);
            try
            {
                using (var command = dbContext.CreateCommand())
                {
                    errorMessage = storeProcedure.Insert<Year>("dbo.sp_insert_foto_ca", ACDetailModel);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return new APIResponse(Collection.Codes.NO_CONTENT, Collection.Status.FAILED, errorMessage, null);
                    }
                    return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, null);
                }
            }
            catch (Exception ex)
            {
                dbContext.Dispose();
                return new APIResponse(Collection.Codes.NOT_FOUND, Collection.Status.FAILED, ex.Message, null);
            }
            finally
            {
                //TODO: Connection pool logic here
                //dbContext.Dispose();
            }
            //return data;
        }

        public async Task<APIResponse> UpdateFoto(Year ACDetailModel)
        {
            string errorMessage = default;
            storeProcedure = new StoreProcedure(dbContext);
            try
            {
                using (var command = dbContext.CreateCommand())
                {
                    errorMessage = storeProcedure.Update<Year>("dbo.sp_update_foto_ca", ACDetailModel);

                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return new APIResponse(Collection.Codes.NO_CONTENT, Collection.Status.FAILED, errorMessage, null);
                    }
                    return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, null);
                }
            }
            catch (Exception ex)
            {
                dbContext.Dispose();
                return new APIResponse(Collection.Codes.NOT_FOUND, Collection.Status.FAILED, ex.Message, null);
            }
            finally
            {
                //TODO: Connection pool logic here
                //dbContext.Dispose();
            }
            //return data;
        }

        public Task<APIResponse> GetFoto(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetFoto(string Id, string PhotoTypeID)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetFotoCek(string Id, string PhotoID, string PhotoTypeID)
        {
            throw new NotImplementedException();
        }
    }
}