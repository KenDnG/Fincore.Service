using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.SERVICE.BPKB.Models;
using FINCORE.SERVICE.BPKB.Repositories.Interfaces;
using FINCORE.HELPER.LIBRARY.Encryption;
using FINCORE.LIBRARY.DTO.Model.Acquisition;
using System.Drawing.Printing;
using FINCORE.HELPER.LIBRARY.Request;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json.Linq;
using FINCORE.HELPER.LIBRARY.Helper;
using System.Net;
using System.Configuration;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;

namespace FINCORE.SERVICE.BPKB.Repositories.EF
{
    public class BPKBRepositoryEF : SendRequest,IBPKB
    {
        private AcquisitionContext acquisitionContext;
        public BPKBRepositoryEF(AcquisitionContext _acquisitionContext)
        {
            this.acquisitionContext = _acquisitionContext;
        }

        public async Task<APIResponse> DeleteBPKB(TrBpkb Model)
        {
            try
            {
                acquisitionContext.TrBpkb.Remove(Model);
                acquisitionContext.SaveChanges();
                return new APIResponse(Collection.Codes.SUCCESS,
                       Collection.Status.SUCCESS,
                       Collection.Messages.SUCCESS,
                       null);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                        Collection.Status.FAILED,
                                        ex.Message + ex.InnerException.Message,
                                        null);
            }
            throw new NotImplementedException();
        }

        public async Task<APIResponse> GetBPKB(TrBpkb Model)
        {
            
            try
            {
                BPKBCustomModel data = new BPKBCustomModel();
                var bpkb = acquisitionContext.TrBpkb.Where(w => w.CreditId == Model.CreditId && w.BranchId == Model.BranchId).FirstOrDefault();
                var bpkbpinjam = acquisitionContext.TrBpkbLoan.Where(w => w.CreditId == Model.CreditId && w.BranchId == Model.BranchId).OrderByDescending(x=>x.SequenceNo).FirstOrDefault();
                var _PageIndex = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?> { _value = 1 };
                var _PageSize = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<double?> { _value = 1 };
                var TotalPages = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?>();
                var RecordCount = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<double?> { _value = 1 };
                List<LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKB_LookupResult> nppList = await acquisitionContext.GetProcedures().sp_get_pagination_BPKB_LookupAsync(Model.CreditId, Model.BranchId, _PageIndex, _PageSize, TotalPages, RecordCount);
                LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKB_LookupResult npp = nppList.FirstOrDefault();
                if(npp == null)
                {
                    npp = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKB_LookupResult();
                }
                data.CustomerName = npp.CustomerName;
                data.QQName = npp.QQName;
                data.ItemMerk = npp.ItemMerk;
                data.ChasisNo = npp.ChasisNo;
                data.MachineNo = npp.MachineNo;
                data.ItemMerk = npp.ItemMerk;
                data.ItemColor = npp.ItemColor;
                data.ItemTypeName = npp.ItemTypeName;
                data.sBPKB = npp.sBPKB;
                data.DealerCode = npp.DealerCode;
                data.STATUSBPKB = npp.STATUSBPKB;
                data.StatusLunasNPP = npp.StatusLunasNPP;
                data.StatusNPP = npp.StatusNPP;
                data.Bpkb = bpkb;
                data.BpkbPinjam = bpkbpinjam;
                return new APIResponse(Collection.Codes.SUCCESS,
                    Collection.Status.SUCCESS,
                    Collection.Messages.SUCCESS,
                    data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message + ex.InnerException.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetCM(TrBpkb Model)
        {
            try
            {
                var bpkb = acquisitionContext.TrCm.Where(w => w.CreditId == Model.CreditId).FirstOrDefault();
                
                return new APIResponse(Collection.Codes.SUCCESS,
                    Collection.Status.SUCCESS,
                    Collection.Messages.SUCCESS,
                    bpkb);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message + ex.InnerException.Message,
                        null);
            }
        }

        

        public async Task<APIResponse> InsertBPKB(BPKBCustomModel Model)
        {
            try
            {
                using (var dbTransactions = acquisitionContext.Database.BeginTransaction())
                {
                    try
                    {
                        var cekbpkbno = acquisitionContext.TrBpkb.Where(w => w.BpkbNo == Model.Bpkb.BpkbNo).FirstOrDefault();
                        if (cekbpkbno != null)
                        {
                            return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR, Collection.Status.FAILED, "BPKBNo Already Exist", null);
                        }


                        //var cekcreditid = acquisitionContext.TrBpkb.Where(w => w.CreditId == Model.CreditId).FirstOrDefault();
                        //if (cekcreditid != null)
                        //{
                        //    return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR, Collection.Status.FAILED, "CreditID Already Exist", null);
                        //}
                        acquisitionContext.TrBpkb.Add(Model.Bpkb);

                        acquisitionContext.SaveChanges();
                        #region rapindo update asset detail disabled
                        //var token_code = Model.CompanyId == "2" ? EndpointAPI.Token.TokenCodeRapindoMCFLive : EndpointAPI.Token.TokenCodeRapindoMAFLive;
                        //object input = new
                        //{
                        //    chassisNo = Model.ChasisNo,
                        //    engineNo = Model.MachineNo,
                        //    licensePlate = Model.Bpkb.CarNo,
                        //    type = "RODA_EMPAT",
                        //    vehicleType = Model.ItemTypeName,
                        //    manufactureYear = Model.ItemYear,
                        //    brand = Model.ItemMerk,
                        //    bpkb = Model.Bpkb.BpkbNo,
                        //    reason = "BPKB IN"
                        //};
                        //RapindoResponse rapindo = await this.GetAPIResponse($"{EndpointAPI.Endpoint.RAPINDOLIVEURL}RAPINDO/UpdateAssetDetail", Method.Post, input, token_code, Model.UserName, Model.BranchName, Model.BranchId);
                        //if(!rapindo.status)
                        //{
                        //    await dbTransactions.RollbackAsync();
                        //    return new APIResponse
                        //        (
                        //            Collection.Codes.FORBIDDEN,
                        //            Collection.Status.FAILED,
                        //            $"{rapindo.message}. {Collection.Messages.TRANSACTION_ROLLBACK}",
                        //            Collection.Messages.TRANSACTION_ROLLBACK
                        //        );
                        //}
                        #endregion

                        await dbTransactions.CommitAsync();

                        return new APIResponse(Collection.Codes.SUCCESS,
                               Collection.Status.SUCCESS,
                               Collection.Messages.SUCCESS,
                               null);
                    }
                    catch (Exception ex)
                    {
                        await dbTransactions.RollbackAsync();
                        return new APIResponse
                            (
                                Collection.Codes.FORBIDDEN,
                                Collection.Status.FAILED,
                                $"{ex.Message}. {Collection.Messages.TRANSACTION_ROLLBACK}",
                                Collection.Messages.TRANSACTION_ROLLBACK
                            );
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                       Collection.Status.FAILED,
                                       ex.Message + ex.InnerException.Message,
                                       null);
            }
        }

        public async Task<APIResponse> OutBPKB(BPKBCustomModel Model)
        {
            try
            {
                var existbpkb = acquisitionContext.TrBpkb.Where(w => w.CreditId == Model.Bpkb.CreditId).FirstOrDefault();
                existbpkb.OutCode = Model.Bpkb.OutCode;
                existbpkb.BpkbStatus = "O";
                existbpkb.IsClose = true;
                existbpkb.BpkbOut = Model.Bpkb.BpkbOut;
                existbpkb.ReceiverCode = Model.Bpkb.ReceiverCode;
                acquisitionContext.SaveChanges();

                #region rapindo expired asset
                var token_code = Model.CompanyId == "2" ? EndpointAPI.Token.TokenCodeRapindoMCFLive : EndpointAPI.Token.TokenCodeRapindoMAFLive;
                object input = new
                {
                    chassisNo = Model.ChasisNo
                };
                RapindoResponse rapindo = await this.GetAPIResponse($"{EndpointAPI.Endpoint.RAPINDOLIVEURL}RAPINDO/ExpireAsset", Method.Post, input, token_code, Model.UserName, Model.BranchName, Model.BranchId);
                if (!rapindo.status)
                {
                    return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                       Collection.Status.FAILED,
                                       rapindo.message,
                                       null);
                }
                #endregion

                return new APIResponse(Collection.Codes.SUCCESS,
                       Collection.Status.SUCCESS,
                       Collection.Messages.SUCCESS,
                       null);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                                       Collection.Status.FAILED,
                                                       ex.Message + ex.InnerException.Message,
                                                       null);
            }
        }

        public async Task<APIResponse> ReEntryBPKB(BPKBCustomModel Model)
        {
            try
            {
                var existbpkb = acquisitionContext.TrBpkb.Where(w => w.CreditId == Model.Bpkb.CreditId && w.BranchId == Model.Bpkb.BranchId).FirstOrDefault();
                var existloan = acquisitionContext.TrBpkbLoan.Where(w=>w.CreditId == Model.Bpkb.CreditId && w.BranchId == Model.Bpkb.BranchId).FirstOrDefault();
                existbpkb.BpkbStatus = "I";
                existbpkb.SecquenceNo =(Convert.ToInt32(existbpkb.SecquenceNo) + 1).ToString();
                existbpkb.LocationCode = Model.Bpkb.LocationCode;
                existloan.BpkbReturn = Model.BpkbPinjam.BpkbReturn;
                acquisitionContext.SaveChanges();
                
                return new APIResponse(Collection.Codes.SUCCESS,
                    Collection.Status.SUCCESS,
                    Collection.Messages.SUCCESS,
                    null);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                       Collection.Status.FAILED,
                                       ex.Message + ex.InnerException.Message,
                                       null);
            }
        }

        public async Task<APIResponse> SaveBPKBPinjam(TrBpkbLoan Model)
        {
            try
            {
                //update trbpkb status menjadi pinjam
                var existbpkb = acquisitionContext.TrBpkb.Where(w => w.CreditId == Model.CreditId && w.BranchId == Model.BranchId).FirstOrDefault();
                existbpkb.BpkbStatus = "P";
                //check jika bpkb dengan credit id dan branch id tsb sudah pernah disimpan jika sudah sequenceno++ jika belum sequenceno = 1
                var existloan = acquisitionContext.TrBpkbLoan.Where(w => w.CreditId == Model.CreditId && w.BranchId == Model.BranchId).OrderByDescending(w=>w.SequenceNo).FirstOrDefault();
                Model.PreviousLocationCode = existbpkb.LocationCode;
                if(existloan == null)//insert loan
                {
                    Model.SequenceNo = 1;
                    Model.TotalOfLoan = 1;
                    acquisitionContext.TrBpkbLoan.Add(Model);
                }
                else//add loan with new new 
                {
                    Model.PreviousSequenceNo = existloan.SequenceNo.ToString();
                    Model.SequenceNo = existloan.SequenceNo + 1;
                    Model.TotalOfLoan = existloan.TotalOfLoan + 1;
                    acquisitionContext.TrBpkbLoan.Add(Model);
                }
                acquisitionContext.SaveChanges();
                
                return new APIResponse(Collection.Codes.SUCCESS,
                      Collection.Status.SUCCESS,
                      Collection.Messages.SUCCESS,
                      null);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                       Collection.Status.FAILED,
                                       ex.Message + ex.InnerException.Message,
                                       null);
            }
        }

        public async Task<APIResponse> UpdateBPKB(TrBpkb BPKBModel)
        {
            try
            {
                var item = acquisitionContext.TrBpkb.Where(w => w.CreditId == BPKBModel.CreditId && w.BranchId == BPKBModel.BranchId).First();
                var cekbpkbno = acquisitionContext.TrBpkb.Where(w => w.BpkbNo == BPKBModel.BpkbNo).FirstOrDefault();
                if(cekbpkbno!= null)
                {
                    if(cekbpkbno.CreditId != BPKBModel.CreditId)
                    {
                        return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR, Collection.Status.FAILED, "BPKBNo Already Exist", null);
                    }
                }
                

                item.BpkbNo = BPKBModel.BpkbNo;
                item.BpkbIn = BPKBModel.BpkbIn;
                item.BpkbDate = BPKBModel.BpkbDate;
                item.InvoiceNo = BPKBModel.InvoiceNo;
                item.InvoiceDate = BPKBModel.InvoiceDate;
                item.CarNo = BPKBModel.CarNo;
                item.LocationCode = BPKBModel.LocationCode;
                item.SecquenceNo = BPKBModel.SecquenceNo;
                item.DeadlineDate = BPKBModel.DeadlineDate;
                item.BpkbDifferenceDesc = BPKBModel.BpkbDifferenceDesc;

                acquisitionContext.SaveChanges();
                
                return new APIResponse(Collection.Codes.SUCCESS,
                       Collection.Status.SUCCESS,
                       Collection.Messages.SUCCESS,
                       null);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                       Collection.Status.FAILED,
                                       ex.Message + ex.InnerException.Message,
                                       null);
            }
        }
        
        

       

        public async Task<APIResponse> UpdatePrintBPKB(TrBpkb Model)
        {
            try
            {
                var existingitem = acquisitionContext.TrBpkb.Where(w => w.CreditId == Model.CreditId).FirstOrDefault();
                if(Model.BastBy!= null || Model.BastBy =="")//update bast
                {
                    existingitem.BastBy = Model.BastBy;
                    existingitem.BastDate = Model.BastDate;
                    existingitem.BpkbStatus = "A";
                }
                else if (Model.IsPrintSk!=null)
                {
                    existingitem.IsPrintSk = true;
                    if(existingitem.SumPrintSk==null)
                    {
                        existingitem.PrintedFirstBy = Model.PrintedFirstBy;
                        existingitem.PrintedFirstDate = Model.PrintedFirstDate;
                        existingitem.SumPrintSk = 1;
                    }
                    else
                    {
                        existingitem.PrintedLastBy = Model.PrintedLastBy;
                        existingitem.PrintedLastDate = Model.PrintedLastDate;
                        existingitem.SumPrintSk++;
                    }
                }
                else if (Model.IsPrintThirdParty!=null)//print pihak ketiga   
                {
                    existingitem.IsPrintThirdParty = true;
                    if(existingitem.SumPrintThirdParty== null)
                    {
                        existingitem.SumPrintThirdParty = 1;
                        existingitem.PrintFirstByThirdParty = Model.PrintFirstByThirdParty;
                        existingitem.PrintFirstDateThirdParty = Model.PrintFirstDateThirdParty;
                    }
                    else
                    {
                        existingitem.SumPrintThirdParty++;
                        existingitem.PrintLastByThirdParty = Model.PrintLastByThirdParty;
                        existingitem.PrintLastDateThirdParty = Model.PrintLastDateThirdParty;
                    }
                    
                }
                acquisitionContext.SaveChanges();
                return new APIResponse(Collection.Codes.SUCCESS, Collection.Messages.SUCCESS, Collection.Status.SUCCESS, null);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR, Collection.Status.FAILED, ex.Message + ex.InnerException.Message, null);
            }
        }

        public async Task<APIResponse> GetBASTData(TrBpkb Model)
        {
            try
            {
                List<sp_get_BPKBBASTDtlResult> data = await acquisitionContext.GetProcedures().sp_get_BPKBBASTDtlAsync(Model.CreditId);
                if (data.ToList().Count != 0)
                {
                    return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, data.FirstOrDefault());
                }
                else
                {
                    return new APIResponse(Collection.Codes.NOT_FOUND, Collection.Status.FAILED, "data not found", data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR, Collection.Status.FAILED, ex.Message + ex.InnerException.Message, null);
            }
        }

        public async Task<APIResponse> GetSKData(TrBpkb Model)
        {
            try
            {
                List<sp_get_BPKBSKDtlResult> data = await acquisitionContext.GetProcedures().sp_get_BPKBSKDtlAsync(Model.CreditId);
                if (data.ToList().Count != 0)
                {
                    return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, data.FirstOrDefault());
                }
                else
                {
                    return new APIResponse(Collection.Codes.NOT_FOUND, Collection.Status.FAILED, "data not found", data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR, Collection.Status.FAILED, ex.Message + ex.InnerException.Message, null);
            }
        }

        public async Task<APIResponse> GetPinjamData(TrBpkb Model)
        {
            try
            {
                List<sp_get_BPKBPinjamDtlResult> data = await acquisitionContext.GetProcedures().sp_get_BPKBPinjamDtlAsync(Model.CreditId);
                if (data.ToList().Count != 0)
                {
                    return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, data.FirstOrDefault());
                }
                else
                {
                    return new APIResponse(Collection.Codes.NOT_FOUND, Collection.Status.FAILED, "data not found", data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR, Collection.Status.FAILED, ex.Message + ex.InnerException.Message, null);
            }
        }

        public async Task<APIResponse> GetBASTINData(TrBpkb Model)
        {
            try
            {
                List<sp_get_BPKB_BAST_IN_DtlResult> data = await acquisitionContext.GetProcedures().sp_get_BPKB_BAST_IN_DtlAsync(Model.CreditId);
                if (data.ToList().Count != 0)
                {
                    return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, data.FirstOrDefault());
                }
                else
                {
                    return new APIResponse(Collection.Codes.NOT_FOUND, Collection.Status.FAILED, "data not found", data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR, Collection.Status.FAILED, ex.Message + ex.InnerException.Message, null);
            }
        }

        public async Task<APIResponse> Get3PData(TrBpkb Model)
        {
            try
            {
                List<sp_get_BPKB_ThirdParty_DtlResult> data = await acquisitionContext.GetProcedures().sp_get_BPKB_ThirdParty_DtlAsync(Model.CreditId,Model.CompanyId);
                if (data.ToList().Count != 0)
                {
                    return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, data.FirstOrDefault());
                }
                else
                {
                    return new APIResponse(Collection.Codes.NOT_FOUND, Collection.Status.FAILED, "data not found", data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR, Collection.Status.FAILED, ex.Message + ex.InnerException.Message, null);
            }
        }

       
    }
}
