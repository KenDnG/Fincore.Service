using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsBPKBReceiver
    {
        Task<APIResponse> GetBPKBReceiverLookup(string? SearchTerm, int PageIndex
                                , int PageSize, int? RecordCount);
    }
}
