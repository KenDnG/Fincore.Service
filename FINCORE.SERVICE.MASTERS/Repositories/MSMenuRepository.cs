using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MSMenuRepository : IMSMenu
    {
        private MastersContext mastersContext;

        public MSMenuRepository(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
        }

        public async Task<APIResponse> GetMenuTree(string NIK)
        {
            try
            {
                var data = await mastersContext.GetProcedures().sp_get_hirarki_menu_by_userAsync(NIK);
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
    }
}