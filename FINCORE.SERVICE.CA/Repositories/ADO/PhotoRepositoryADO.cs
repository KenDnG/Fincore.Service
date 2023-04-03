using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository.Interfaces;
using FINCORE.HELPER.LIBRARY.Helper;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.CA.Repositories.Interfaces;
using FINCORE.SERVICE.CAS.DbContexts;
using System.Data;

namespace FINCORE.SERVICE.CA.Repositories.ADO
{
    public class PhotoRepositoryADO : BaseRepository<GetFoto>, IACDetail
    {
        private DbContext dbContext;
        private ConnectionConfigServices connectionConfigServices;
        private StoreProcedure storeProcedure;

        public PhotoRepositoryADO(DbContext _context,
           ConnectionConfigServices _connectionConfigServices) : base(_context)
        {
            dbContext = _context;
            connectionConfigServices = _connectionConfigServices;
        }

        public PhotoRepositoryADO(DbContext _context) : base(_context)
        {
            dbContext = _context;
        }

        public async Task<APIResponse> GetFoto(string Id, string PhotoTypeID)
        {
            var data = new List<GetFoto>();
            try
            {
                using (var command = dbContext.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.sp_get_foto_ca";
                    command.Parameters.Add(command.CreateParameter("@CASId", Id));
                    command.Parameters.Add(command.CreateParameter("@PhotoTypeID", PhotoTypeID));
                    data = ReadTransaction(command).ToList();
                }
                return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, data);
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

        public Task<APIResponse> InsertFoto(Year ACDetailModel)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> UpdateFoto(Year ACDetailModel)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetFotoCek(string Id, string PhotoID, string PhotoTypeID)
        {
            throw new NotImplementedException();
        }
    }
}