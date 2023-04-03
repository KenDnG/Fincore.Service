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
    public class ACHeaderRepositoryADO : BaseRepository<ACHeaderModel>, IACHeader
    {
        private DbContext dbContext;
        private ConnectionConfigServices connectionConfigServices;
        private StoreProcedure storeProcedure;

        public ACHeaderRepositoryADO(DbContext _context,
           ConnectionConfigServices _connectionConfigServices) : base(_context)
        {
            dbContext = _context;
            connectionConfigServices = _connectionConfigServices;
        }

        public ACHeaderRepositoryADO(DbContext _context) : base(_context)
        {
            dbContext = _context;
        }

        /// <summary>
        /// Command with Store Procedure.
        /// </summary>
        /// <param name="command"></param>

        public async Task<APIResponse> GetAnalisa(string Id)
        {
            var data = new ACHeaderModel();
            try
            {
                using (var command = dbContext.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.sp_get_analisa_cmo_ca";
                    command.Parameters.Add(command.CreateParameter("@CASId", Id));
                    data = ReadTransaction(command).First();
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

        public async Task<APIResponse> InsertAnalisa(ACHeaderModel ACHeaderModel)
        {
            string errorMessage = default;
            storeProcedure = new StoreProcedure(dbContext);
            try
            {
                using (var command = dbContext.CreateCommand())
                {
                    errorMessage = storeProcedure.Insert<ACHeaderModel>("dbo.sp_insert_analisa_cmo_ca", ACHeaderModel);
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

        public async Task<APIResponse> UpdateAnalisa(ACHeaderModel ACHeaderModel)
        {
            string errorMessage = default;
            storeProcedure = new StoreProcedure(dbContext);
            try
            {
                using (var command = dbContext.CreateCommand())
                {
                    errorMessage = storeProcedure.Update<ACHeaderModel>("dbo.sp_update_analisa_cmo_ca", ACHeaderModel);

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
    }
}