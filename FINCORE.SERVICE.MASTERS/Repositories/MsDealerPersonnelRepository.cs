﻿using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FINCORE.SERVICE.MASTERS.Repositories
{
    public class MsDealerPersonnelRepository : IMsDealerPersonnel
    {
        private MastersContext masterContext;

        public MsDealerPersonnelRepository(MastersContext _masterContext)
        {
            this.masterContext = _masterContext;
        }

        public async Task<APIResponse> GetAllDataAsync()
        {
            try
            {
                var data = await masterContext.MsDealerPersonel.ToListAsync();

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

        public async Task<APIResponse> GetListByCustomCondition(int param)
        {
            try
            {
                var data = await masterContext.MsDealerPersonel.Where(x => x.JobTitleId == param).ToListAsync();

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
    }
}