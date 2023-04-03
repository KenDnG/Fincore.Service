using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository.Interfaces;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.SERVICE.MINIAPI.DbContexts;
using FINCORE.SERVICE.MINIAPI.Models;
using System.Data;

namespace FINCORE.SERVICE.MINIAPI.Repositories
{
    public class XCASRepository : BaseRepository<XCASModel>
    {
        private DbContext dbContext;
        private ConnectionConfigServices connectionConfigServices;

        public XCASRepository(DbContext _context,
            ConnectionConfigServices _connectionConfigServices) : base(_context)
        {
            this.dbContext = _context;
            this.connectionConfigServices = _connectionConfigServices;
        }

        public XCASRepository(DbContext _context) : base(_context)
        {
            this.dbContext = _context;
        }

        public async Task<APIResponse> GetCASListPagination(string? SearchTerm, int PageIndex
                                                  , int PageSize, int? RecordCount)
        {
            //var data = new Pagination<XCASModel>();
            var data = new List<XCASModel>();
            var pagination = new Pagination<XCASModel>();
            try
            {
                using (var command = dbContext.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.spPaginationNewPO";
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