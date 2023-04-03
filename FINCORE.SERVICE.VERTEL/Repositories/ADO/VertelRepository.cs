using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository.Interfaces;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.Model.Acquisition.Vertel;
using FINCORE.SERVICE.VERTEL.Models;
using FINCORE.SERVICE.VERTEL.Repositories.Interfaces;
using System.Data;
using TrVerificationConsumenModels = FINCORE.LIBRARY.DTO.Model.Acquisition.Vertel.TrVerificationConsumenModels;

namespace FINCORE.SERVICE.VERTEL.Repositories.ADO
{
    public class VertelRepository : BaseRepository<VertelModels>, IVertel
    {
        private DbContext dbContext;
        public VertelRepository(DbContext _context) : base(_context)
        {
            dbContext = _context;
        }

        public Task<APIResponse> DeleteVertel(CfverifikasiKonsumen CfverifikasiKonsumen)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetDataVertelSelect(CfverifikasiKonsumen CfverifikasiKonsumen)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> GetDocField(string CMNo)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> GetVertelList()
        {
            //throw new NotImplementedException();
            var data = new List<VertelModels>();
            try
            {
                using (var command = dbContext.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.spGetListNewVerteltest";
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

        public async Task<APIResponse> GetVertelListPagination(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount)
        {
            //var data = new Pagination<XCASModel>();
            var data = new List<VertelModels>();
            var pagination = new Pagination<VertelModels>();
            try
            {
                using (var command = dbContext.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.spGetListNewVerteltestPaging";
                    command.Parameters.Add(command.CreateParameter("@SearchTerm", SearchTerm));
                    command.Parameters.Add(command.CreateParameter("@PageIndex", PageIndex));
                    command.Parameters.Add(command.CreateParameter("@PageSize", PageSize));

                    IDbDataParameter x = command.CreateParameterOutput(DbType.Int32, "@TotalPages");
                    IDbDataParameter y = command.CreateParameterOutput(DbType.Int32, "@RecordCount");
                    command.Parameters.Add(x);
                    command.Parameters.Add(y);

                    data = ReadTransaction(command).ToList();
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

        public async Task<APIResponse> GetDataVerifikasiKonsumen(string VerifikasiNo)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetVertelLookupNPP(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> InsertVertel(TrVerificationConsumenModels trVerificationConsumen)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> UpdateVertel(TrVerificationConsumenModels trVerificationConsumen)
        {
            throw new NotImplementedException();
        }

        #region Approval Process
        public async Task<APIResponse> GetApproverReason(string typeApproval)
        {
            throw new NotImplementedException();
        }
        public async Task<APIResponse> ApprovalProcess(VertelApprovalModels data)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetPriceAwal(string creditId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
