using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.CA.Repositories.Interfaces;

namespace FINCORE.SERVICE.CA.Repositories.EF
{
    public class TrCAS_CreditAnalystEF : ITrCAS_CreditAnalyst
    {
        private readonly AcquisitionContext context;

        public TrCAS_CreditAnalystEF(AcquisitionContext _context)
        {
            this.context = _context;
        }

        private bool TrCAS_CreditAnalystExists(string id)
        {
            bool tes;
            var data = context.GetProcedures().sp_get_analisa_cmo_caAsync(id).Result;
            if (data.Count > 0)
            {
                tes = true;
            }
            else
            {
                tes = false;
            }
            return tes;
            //return (context.TrCreditAnalysts?.Any(e => e.CreditId == id)).GetValueOrDefault();
        }

        public async Task<APIResponse> GetFoto(string Id, string PhotoTypeID)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await context.GetProcedures().sp_get_foto_caAsync(Id, PhotoTypeID));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> SaveCAS_CreditAnalyst(TrCAS_CreditAnalyst trCAS_CreditAnalyst)
        {
            try
            {
                using (var dbTransactions = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<sp_get_analisa_cmo_caResult> cekanalisa = context.GetProcedures().sp_get_analisa_cmo_caAsync(trCAS_CreditAnalyst.CASId).Result.ToList();
                        if (cekanalisa.Count < 1)
                        {
                            await context.GetProcedures().sp_insert_analisa_cmo_caAsync(
                                    trCAS_CreditAnalyst.CASId,
                                    trCAS_CreditAnalyst.Capacity,
                                    trCAS_CreditAnalyst.Capital,
                                    trCAS_CreditAnalyst.Character,
                                    trCAS_CreditAnalyst.Condition,
                                    trCAS_CreditAnalyst.Collateral,
                                    trCAS_CreditAnalyst.Strenght,
                                    trCAS_CreditAnalyst.Weakness,
                                    trCAS_CreditAnalyst.created_by,
                                    trCAS_CreditAnalyst.created_on,
                                    trCAS_CreditAnalyst.last_updated_by,
                                    trCAS_CreditAnalyst.last_updated_on
                                );
                        }
                        else
                        {
                            await context.GetProcedures().sp_update_analisa_cmo_caAsync(
                                trCAS_CreditAnalyst.CASId,
                                trCAS_CreditAnalyst.Capacity,
                                trCAS_CreditAnalyst.Capital,
                                trCAS_CreditAnalyst.Character,
                                trCAS_CreditAnalyst.Condition,
                                trCAS_CreditAnalyst.Collateral,
                                trCAS_CreditAnalyst.Strenght,
                                trCAS_CreditAnalyst.Weakness,
                                trCAS_CreditAnalyst.last_updated_by,
                                trCAS_CreditAnalyst.last_updated_on
                        );
                        }

                        for (int i = 0; i < trCAS_CreditAnalyst.filename.Count; i++)
                        {
                            List<sp_get_fotocek_caResult> cekfoto = context.GetProcedures().sp_get_fotocek_caAsync(trCAS_CreditAnalyst.CASId, trCAS_CreditAnalyst.PhotoID[i], trCAS_CreditAnalyst.PhotoTypeID[i]).Result.ToList();
                            if (cekfoto.Count < 1)
                            {
                                trCAS_CreditAnalyst.created_by = "tes cobaan";
                                trCAS_CreditAnalyst.created_on = DateTime.Now;
                                await context.GetProcedures().sp_insert_foto_caAsync(
                                    trCAS_CreditAnalyst.CASId,
                                    trCAS_CreditAnalyst.filename[i],
                                    trCAS_CreditAnalyst.filePath[i],
                                    trCAS_CreditAnalyst.PhotoTypeID[i],
                                    trCAS_CreditAnalyst.PhotoID[i],
                                    trCAS_CreditAnalyst.created_by,
                                    trCAS_CreditAnalyst.created_on,
                                    trCAS_CreditAnalyst.last_updated_by,
                                    trCAS_CreditAnalyst.last_updated_on
                                );
                            }
                            else
                            {
                                trCAS_CreditAnalyst.created_by = "tes cobaan";
                                trCAS_CreditAnalyst.created_on = DateTime.Now;
                                trCAS_CreditAnalyst.last_updated_by = "tes update";
                                trCAS_CreditAnalyst.last_updated_on = DateTime.Now;
                                await context.GetProcedures().sp_update_foto_caAsync(
                                   trCAS_CreditAnalyst.CASId,
                                    trCAS_CreditAnalyst.filename[i],
                                    trCAS_CreditAnalyst.filePath[i],
                                    trCAS_CreditAnalyst.PhotoTypeID[i],
                                    trCAS_CreditAnalyst.PhotoID[i],
                                    trCAS_CreditAnalyst.created_by,
                                    trCAS_CreditAnalyst.created_on,
                                    trCAS_CreditAnalyst.last_updated_by,
                                    trCAS_CreditAnalyst.last_updated_on
                                );
                            }
                        }

                        await dbTransactions.CommitAsync();

                        return new APIResponse(Collection.Codes.CREATED,
                                            Collection.Status.SUCCESS,
                                            Collection.Messages.CREATED,
                                            trCAS_CreditAnalyst);
                    }
                    catch (Exception ex)
                    {
                        await dbTransactions.RollbackAsync();

                        if (TrCAS_CreditAnalystExists(trCAS_CreditAnalyst.CASId))
                        {
                            return new APIResponse(Collection.Codes.LOCKED,
                                            Collection.Status.FAILED,
                                            ex.Message,
                                            null);
                        }

                        return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                            Collection.Status.FAILED,
                                            ex.Message,
                                            null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                        Collection.Status.FAILED,
                                        ex.Message,
                                        null);
            }
        }
    }
}