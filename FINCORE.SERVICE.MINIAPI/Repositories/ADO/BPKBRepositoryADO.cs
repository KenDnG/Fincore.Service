using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.SERVICE.BPKB.Models;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces;

namespace FINCORE.SERVICE.MINIAPI.Repositories.ADO
{
    public class BPKBRepositoryADO : BaseRepository<BPKPModel>, IBPKB
    {
        private DbContext dbContext;

        public BPKBRepositoryADO(DbContext _context) : base(_context)
        {
            dbContext = _context;
        }

        public Task<APIResponse> GetBPKBLookupNPP(string? SearchTerm,string BranchID, int PageIndex, int PageSize, int? RecordCount)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetBPKBPaging(string? SearchTerm, string BranchID, int PageIndex, int PageSize, int? RecordCount)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetBPKBPagingAsuransi(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetBPKBPagingBiroJasa(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetBPKBPagingDealer(string? SearchTerm, string BranchID, int PageIndex, int PageSize, int? RecordCount)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetBPKBPagingTypeOfBureau(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetBPKBReceiverLookup(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount)
        {
            throw new NotImplementedException();
        }
    }
}
