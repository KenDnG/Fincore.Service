using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using MessagePack;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MSCompanyBranchRepository : IMSCompanyBranch
    {
        private MastersContext mastersContext;

        public MSCompanyBranchRepository(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
        }

        public async Task<APIResponse> GetCompanyBranch(string company_id, string NIK)
        {
            try
            {
                var data = await mastersContext.GetProcedures().sp_get_company_branch_listAsync(company_id, NIK);
                if (data.Count == 0)
                {
                    return new APIResponse(Collection.Codes.NOT_FOUND, Collection.Status.FAILED, "Data Tidak Ditemukan", null);
                }
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }

        public async Task<APIResponse> GetBranchDetail(string branch_id)
        {
            try
            {

                var data = mastersContext.MsCompanyBranch.Where(w => w.BranchId == branch_id).FirstOrDefault();
                return new APIResponse(Collection.Codes.SUCCESS,
                    Collection.Status.SUCCESS,
                    Collection.Messages.SUCCESS,
                    data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }
        
    }
}