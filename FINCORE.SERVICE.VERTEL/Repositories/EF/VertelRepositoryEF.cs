
using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.LIBRARY.DTO.Model.Acquisition.Vertel;
using FINCORE.SERVICE.VERTEL.Repositories.Interfaces;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Xml.Linq;

namespace FINCORE.SERVICE.VERTEL.Repositories.EF
{
    public class VertelRepositoryEF : IVertel
    {
        private AcquisitionContext acquisitionContext;
        public VertelRepositoryEF(AcquisitionContext _acquisitionContext)
        {
            this.acquisitionContext = _acquisitionContext;
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
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_DocumentFieldAsync(CMNo));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetPriceAwal(string creditId)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_price_awalAsync(creditId));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public Task<APIResponse> GetVertelList()
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetVertelListPagination(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> GetVertelLookupNPP(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount)
        {
            var data = new List<spGetListNewVertelLookUpPagingResult>();
            var pagination = new Pagination<spGetListNewVertelLookUpPagingResult>();
            var TotalPages = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?>();
            var Recordcount = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?>();
            try
            {
                List<spGetListNewVertelLookUpPagingResult> results = await acquisitionContext.GetProcedures().spGetListNewVertelLookUpPagingAsync(SearchTerm == null ? "" : SearchTerm, PageIndex, PageSize, TotalPages, Recordcount);
                pagination.TotalPages = Convert.ToInt32(TotalPages.Value);
                pagination.RecordCount = Convert.ToInt32(Recordcount.Value);
                pagination.Model = results;
                pagination.SearchTerm = SearchTerm;
                pagination.PageIndex = PageIndex;
                pagination.PageSize = PageSize;
                return new APIResponse(Collection.Codes.SUCCESS,
                    Collection.Status.SUCCESS,
                    Collection.Messages.SUCCESS,
                    pagination);


            }
            catch (Exception ex)
            {

                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                       Collection.Status.FAILED,
                       ex.Message,
                       null);
            }
        }

        public async Task<APIResponse> InsertVertel(TrVerificationConsumenModels trverificationconsumen)
        {
            try
            {
                #region Save to TrVerificationCustomer
                if (trverificationconsumen.BiayaAdmin == null){trverificationconsumen.BiayaAdminLainnya = false;}
                else { trverificationconsumen.BiayaAdminLainnya = true; }
                if (trverificationconsumen.OptTglTerimaMotorSebenarnya == null)
                    trverificationconsumen.OptTglTerimaMotor = true;
                if (trverificationconsumen.OptTipeMotorSebenarnya == null)
                    trverificationconsumen.OptTipeMotor = false;
                if (trverificationconsumen.OptAngsuranSebenarnya == null)
                    trverificationconsumen.OptAngsuran = false;
                if (trverificationconsumen.OptTenorSebenarnya == null)
                    trverificationconsumen.OptTenor = false;
                if (trverificationconsumen.OptDpsetorSebenarnya == null)
                    trverificationconsumen.OptDpsetor = false;
                TrVerificationCustomer trvkonsumen = new()
                {
                    CreditId = trverificationconsumen.Cmno,
                    VerificationStatus = trverificationconsumen.SaveType,
                    ContactedOption = trverificationconsumen.OptBisaDiHubungi,
                    BillingDate = trverificationconsumen.TglTerimaTagihan,
                    ConfirmationDate = trverificationconsumen.TglKonfirmasi,
                    ConfirmationTime = trverificationconsumen.JamKonfirmasi,
                    ApprovedDateNpp = trverificationconsumen.TglApproveNpp,
                    OptionItemReceivedDate = trverificationconsumen.OptTglTerimaMotor,
                    OptionItemReceivedDateReal = trverificationconsumen.OptTglTerimaMotorSebenarnya,
                    OptionItemType = trverificationconsumen.OptTipeMotor,
                    OptionItemTypeReal = trverificationconsumen.OptTipeMotorSebenarnya,
                    OptionInstallment = trverificationconsumen.OptAngsuran,
                    OptionInstallmentReal = trverificationconsumen.OptAngsuranSebenarnya,
                    OptionTenor = trverificationconsumen.OptTenor,
                    OptionTenorReal = trverificationconsumen.OptTenorSebenarnya,
                    ItemReceiverName = trverificationconsumen.NamaPenerimaMotor,
                    ItemReceiverRelation = trverificationconsumen.HubunganPenerimaMotor,
                    RequestOfDueDate = trverificationconsumen.PermintaanJt,
                    OtherNotes = trverificationconsumen.CatatanLain,
                    CreatedBy = trverificationconsumen.CreatedBy,
                    CreatedOn = DateTime.Now,
                    LastUpdatedBy = trverificationconsumen.UpdatedBy,
                    LastUpdatedOn = trverificationconsumen.UpdatedOn,
                    OptionDisbursementUmc = trverificationconsumen.OptPencairanMb,
                    OptionDisbursementUmcReal = trverificationconsumen.OptPencairanMbsebenarnya,
                    OptionConsumenPayment = trverificationconsumen.OptDpsetor,
                    OptionConsumenPaymentReal = trverificationconsumen.OptDpsetorSebenarnya,
                    AdminFeeOther = trverificationconsumen.BiayaAdminLainnya,
                    AdminFeeOtherAmount = trverificationconsumen.BiayaAdmin,                
                };

                acquisitionContext.TrVerificationCustomer.Add(trvkonsumen);
                #endregion

                #region Save to TrVerificationCustomerApplicationIn
                List<TrVerificationCustomerApplicationIn> trverificationconsumenapplicationin = new List<TrVerificationCustomerApplicationIn>();
                for (int i = 0; i < trverificationconsumen.docFieldModels.Count; i++)
                {
                    TrVerificationCustomerApplicationIn trdocin = new TrVerificationCustomerApplicationIn();
                    trdocin.ApplicationFilePath = trverificationconsumen.docFieldModels[i].Path;
                    trdocin.ApplicationFileName = trverificationconsumen.docFieldModels[i].FileName;
                    trdocin.FieldId = trverificationconsumen.docFieldModels[i].IDBind;
                    trdocin.IsTrue = trverificationconsumen.docFieldModels[i].isAvailable;
                    trdocin.CreditId = trverificationconsumen.Cmno;
                    trdocin.CreatedBy = trverificationconsumen.CreatedBy;
                    trdocin.CreatedOn = DateTime.Now;

                    trverificationconsumenapplicationin.Add(trdocin);
                }
                if (trverificationconsumenapplicationin.Count > 0)
                {
                    acquisitionContext.TrVerificationCustomerApplicationIn.AddRange(trverificationconsumenapplicationin);
                }
                #endregion

                #region save to TrHierarchyTransaction
                if (trverificationconsumen.SaveType == "R" || trverificationconsumen.SaveType == "0")
                {
                    var dataHierarchy = await acquisitionContext.GetProcedures().sp_get_hierarchy_transactionAsync(trverificationconsumen.CreatedBy);


                    TrHierarchyTransaction trHierarchyTrans = new()
                    {
                        CreatedBy = trverificationconsumen.CreatedBy,
                        CreatedOn = DateTime.Now,
                        TransId = trverificationconsumen.Cmno,
                        TransTypeId = dataHierarchy.First().trans_type_id,
                        TransDate = DateTime.Now,
                        EmployeeId = dataHierarchy.First().employee_id,
                        NextEmployeeId = dataHierarchy.First().spv_employee_id,
                        Status = "0",
                        HierarchyTransId = dataHierarchy.First().level
                    };

                    TrHierarchyTransaction trHierarchyTransSecond = new()
                    {
                        CreatedBy = trverificationconsumen.CreatedBy,
                        CreatedOn = DateTime.Now,
                        TransId = trverificationconsumen.Cmno,
                        TransTypeId = dataHierarchy.First().trans_type_id,
                        EmployeeId = trHierarchyTrans.NextEmployeeId,
                        HierarchyTransId = dataHierarchy.First().level + 1
                    };

                    acquisitionContext.TrHierarchyTransaction.Add(trHierarchyTrans);
                    acquisitionContext.TrHierarchyTransaction.Add(trHierarchyTransSecond);
                }

                #endregion

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

        public async Task<APIResponse> UpdateVertel(TrVerificationConsumenModels trverificationconsumen)
        {
            try
            {
                if (trverificationconsumen.SaveType == "R")
                {
                    trverificationconsumen.StatusVerifikasi = "0";
                }
                else
                {
                    trverificationconsumen.StatusVerifikasi = "D";
                }

                #region update TrVerificationCustomer
                var item = acquisitionContext.TrVerificationCustomer.Where(w => w.CreditId == trverificationconsumen.Cmno).First();

                item.CreditId = trverificationconsumen.Cmno;
                item.VerificationStatus = trverificationconsumen.StatusVerifikasi;
                item.BillingDate = trverificationconsumen.TglTerimaTagihan;
                item.OptionItemReceivedDate = trverificationconsumen.OptTglTerimaMotor;
                item.OptionItemReceivedDateReal = trverificationconsumen.OptTglTerimaMotorSebenarnya;
                item.OptionItemType = trverificationconsumen.OptTipeMotor;
                item.OptionItemTypeReal = trverificationconsumen.OptTipeMotorSebenarnya;
                item.OptionInstallment = trverificationconsumen.OptAngsuran;
                item.OptionInstallmentReal = trverificationconsumen.OptAngsuranSebenarnya;
                item.OptionTenor = trverificationconsumen.OptTenor;
                item.OptionTenorReal = trverificationconsumen.OptTenorSebenarnya;
                item.OptionConsumenPayment = trverificationconsumen.OptDpsetor;
                item.OptionConsumenPaymentReal = trverificationconsumen.OptDpsetorSebenarnya;
                item.RequestOfDueDate = trverificationconsumen.PermintaanJt;
                item.ItemReceiverName = trverificationconsumen.NamaPenerimaMotor;
                item.ItemReceiverRelation = trverificationconsumen.HubunganPenerimaMotor;
                item.OtherNotes = trverificationconsumen.CatatanLain;
                item.LastUpdatedBy = trverificationconsumen.CreatedBy;
                item.LastUpdatedOn = DateTime.Now;
                item.AdminFeeOther = trverificationconsumen.BiayaAdminLainnya;
                item.AdminFeeOtherAmount = trverificationconsumen.BiayaAdmin;

                #region option
                if (trverificationconsumen.BiayaAdmin == null)
                {
                    item.AdminFeeOther = false;
                }
                else
                {
                    item.AdminFeeOther = true;
                }

                if (trverificationconsumen.OptTglTerimaMotorSebenarnya == null)
                {
                    item.OptionItemReceivedDate = true;
                }
                else
                {
                    item.OptionItemReceivedDate = false;
                }

                if (trverificationconsumen.OptTipeMotorSebenarnya == null)
                {
                    item.OptionItemType = true;
                }
                else
                {
                    item.OptionItemType = false;
                }
                    
                if (trverificationconsumen.OptAngsuranSebenarnya == null)
                {
                    item.OptionInstallment = true;
                }
                else
                {
                    item.OptionInstallment = false;
                }

                if (trverificationconsumen.OptTenorSebenarnya == null)
                {
                    item.OptionTenor = true;
                }
                else
                {
                    item.OptionTenor = false;
                }

                if (trverificationconsumen.OptDpsetorSebenarnya == null)
                {
                    item.OptionConsumenPayment = true;
                }
                else
                {
                    item.OptionConsumenPayment = false;
                }
                #endregion
                #endregion

                #region update TrVerificationCustomerIn
                List<TrVerificationCustomerApplicationIn> trverificationconsumenapplicationin = new List<TrVerificationCustomerApplicationIn>();

                for (int i = 0; i < trverificationconsumen.docFieldModels.Count; i++)
                {
                    var dataExists = acquisitionContext.TrVerificationCustomerApplicationIn
                                 .Where(x => x.CreditId == trverificationconsumen.Cmno && x.FieldId == trverificationconsumen.docFieldModels[i].IDBind)
                                 .FirstOrDefault();

                    if (dataExists != null)
                    {
                        dataExists.LastUpdatedBy = trverificationconsumen.CreatedBy;
                        dataExists.LastUpdatedOn = DateTime.Now;
                        dataExists.ApplicationFilePath = trverificationconsumen.docFieldModels[i].Path;
                        dataExists.ApplicationFileName = trverificationconsumen.docFieldModels[i].FileName;
                    }
                    else
                    {
                        TrVerificationCustomerApplicationIn trdocin = new()
                        {
                            ApplicationFilePath = trverificationconsumen.docFieldModels[i].Path,
                            ApplicationFileName = trverificationconsumen.docFieldModels[i].FileName,
                            FieldId = trverificationconsumen.docFieldModels[i].IDBind,
                            IsTrue = trverificationconsumen.docFieldModels[i].isAvailable,
                            CreditId = trverificationconsumen.Cmno,
                            CreatedBy = trverificationconsumen.CreatedBy,
                            CreatedOn = DateTime.Now
                        };

                        trverificationconsumenapplicationin.Add(trdocin);
                    }
                }
                if (trverificationconsumenapplicationin.Count > 0)
                {
                    acquisitionContext.TrVerificationCustomerApplicationIn.AddRange(trverificationconsumenapplicationin);
                }
                #endregion

                #region save to TrHierarchyTransaction
                if (trverificationconsumen.SaveType == "R")
                {
                    var existsRFA = acquisitionContext.TrHierarchyTransaction
                                   .Where(x => x.Status == "0" && x.TransId == trverificationconsumen.Cmno.ToString() && x.TransTypeId == "02VK0001")
                                   .FirstOrDefault();
                    var dataHierarchy = await acquisitionContext.GetProcedures().sp_get_hierarchy_transactionAsync(trverificationconsumen.CreatedBy);


                    if (existsRFA != null)
                    {
                        await acquisitionContext.GetProcedures().sp_update_status_approval_vertelAsync(trverificationconsumen.CreatedBy, trverificationconsumen.Cmno);

                    }
                    else
                    {
                        TrHierarchyTransaction trHierarchyTrans = new()
                        {
                            CreatedBy = trverificationconsumen.CreatedBy,
                            CreatedOn = DateTime.Now,
                            TransId = trverificationconsumen.Cmno,
                            TransTypeId = dataHierarchy.First().trans_type_id,
                            TransDate = DateTime.Now,
                            EmployeeId = dataHierarchy.First().employee_id,
                            NextEmployeeId = dataHierarchy.First().spv_employee_id,
                            Status = "0",
                            HierarchyTransId = dataHierarchy.First().level
                        };

                        TrHierarchyTransaction trHierarchyTransSecond = new()
                        {
                            CreatedBy = trverificationconsumen.CreatedBy,
                            CreatedOn = DateTime.Now,
                            TransId = trverificationconsumen.Cmno,
                            TransTypeId = dataHierarchy.First().trans_type_id,
                            EmployeeId = trHierarchyTrans.NextEmployeeId,
                            HierarchyTransId = dataHierarchy.First().level + 1
                        };

                        acquisitionContext.TrHierarchyTransaction.Add(trHierarchyTrans);
                        acquisitionContext.TrHierarchyTransaction.Add(trHierarchyTransSecond);

                    }


                }

                #endregion

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

        public async Task<APIResponse> GetDataVerifikasiKonsumen(string VerifikasiNo)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_data_VerifikasiKonsumenAsync(VerifikasiNo));

            }
            catch (Exception ex)
            {

                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                       Collection.Status.FAILED,
                       ex.Message,
                       null);
            }
        }

        #region Approval Process
        public async Task<APIResponse> GetApproverReason(string typeApproval)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                Collection.Status.SUCCESS,
                Collection.Messages.SUCCESS,
                await acquisitionContext.GetProcedures().sp_get_approver_reasonAsync(typeApproval));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
               Collection.Status.FAILED,
               ex.Message,
               null);
            }
        }

        public async Task<APIResponse> ApprovalProcess(VertelApprovalModels data)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                Collection.Status.SUCCESS,
                Collection.Messages.SUCCESS,
                await acquisitionContext.GetProcedures().sp_approve_vertelAsync(data.ReasonId, data.Type, data.EmployeeId, data.TransId, data.ReasonDescription));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
               Collection.Status.FAILED,
               ex.Message,
               null);
            }
        }
        #endregion

    }

}
