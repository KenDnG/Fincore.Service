using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FINCORE.SERVICE.MASTERS.Repositories
{
    public class MsDealerBankReferenceRepository : IMasters
    {
        private MastersContext mastersContext;

        public MsDealerBankReferenceRepository(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
        }

        public async Task<APIResponse> GetAllAsync()
        {
            try
            {
                var data = await mastersContext.MsDealerBankReference.ToListAsync();

                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                            Collection.Status.FAILED,
                                            $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                                            null);
            }
        }

        public async Task<APIResponse> GetByIdAsync(string Id)
        {
            try
            {
                var data = await mastersContext.MsDealerBankReference
                                    .Where(x => x.DealerCode == Id).ToListAsync();

                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                            Collection.Status.FAILED,
                                            $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                                            null);
            }
        }

        public async Task<APIResponse> GetByIdAsync(int Id)
        {
            try
            {
                var data = await mastersContext.MsDealerBankReference
                                    .SingleAsync(x => x.BankReferenceId == Id);

                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                            Collection.Status.FAILED,
                                            $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                                            null);
            }
        }

        public async Task<APIResponse> GetByIdAndDealerCodeAsync(int Id
                                                                , string dealerCode
                                                                , string bankAccountType)
        {
            try
            {
                var data = await mastersContext.MsDealerBankReference
                                    .SingleAsync(x => x.BankReferenceId == Id
                                                    && x.DealerCode == dealerCode
                                                    && x.BankAccountType == bankAccountType);

                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                            Collection.Status.FAILED,
                                            $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                                            null);
            }
        }

        public Task<APIResponse> InsertAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> UpdateAsync(string Id, object obj)
        {
            throw new NotImplementedException();
        }
    }
}