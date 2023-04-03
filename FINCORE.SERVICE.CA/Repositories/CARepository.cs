using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository.Interfaces;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.SERVICE.CA.Interfaces;
using FINCORE.SERVICE.CA.Models;
using System.Data;

namespace FINCORE.SERVICE.CA.Repositories
{
    public class CARepository : BaseRepository<CAModel>, ICA
    {
        private DbContext dbContext;

        public CARepository(DbContext _context) : base(_context)
        {
            this.dbContext = _context;
        }

        public async Task<APIResponse> GetCAList()
        {
            var data = new List<CAModel>();
            try
            {
                using (var command = dbContext.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.spListPageCA";
                    data = this.ReadTransaction(command).ToList();
                }
                return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, data);
            }
            catch (Exception ex)
            {
                dbContext.Dispose();
                return new APIResponse(Collection.Codes.NOT_FOUND, Collection.Status.FAILED, ex.Message, null);
            }

            //throw new NotImplementedException();
        }

        public async Task<APIResponse> GetCAListPagination(string? SearchTerm, int PageIndex
                                        , int PageSize, int? RecordCount)
        {
            //var data = new Pagination<XCASModel>();
            var data = new List<CAModel>();
            var pagination = new Pagination<CAModel>();
            try
            {
                using (var command = dbContext.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.spListPageCA";
                    command.Parameters.Add(command.CreateParameter("@SearchTerm", SearchTerm));
                    command.Parameters.Add(command.CreateParameter("@PageIndex", PageIndex));
                    command.Parameters.Add(command.CreateParameter("@PageSize", PageSize));

                    IDbDataParameter x = command.CreateParameterOutput(DbType.Int32, "@TotalPages");
                    IDbDataParameter y = command.CreateParameterOutput(DbType.Int32, "@RecordCount");
                    command.Parameters.Add(x);
                    command.Parameters.Add(y);

                    data = this.ReadTransaction(command).ToList();
                    pagination.SearchTerm = SearchTerm;
                    pagination.PageIndex = PageIndex;
                    pagination.PageSize = PageSize;
                    pagination.TotalPages = x.Value != null ? (int)x.Value : 0;
                    pagination.RecordCount = y.Value != null ? (int)y.Value : 0;
                    pagination.Model = data;
                }
                return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, pagination);
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