using FINCORE.HELPER.LIBRARY.Helper;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.HELPER.LIBRARY.Request;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels;
using FINCORE.LIBRARY.DTO.Model.Acquisition.NPP;
using FINCORE.SERVICE.NPP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using RestSharp;

namespace FINCORE.SERVICE.NPP.Repositories
{
    public class TrNPPRepository : SendRequest,ITrNPP
    {
        private readonly AcquisitionContext acquisitionContext;
        private readonly MastersContext mastersContext;
        private readonly TrCMRepository trCMRepository;

        public TrNPPRepository(AcquisitionContext _acquisitionContext, MastersContext _mastersContext)
        {
            this.acquisitionContext = _acquisitionContext;
            this.mastersContext = _mastersContext;
            this.trCMRepository = new TrCMRepository(this.acquisitionContext);
        }

        public async Task<TrNpp> GetNppRelationalById(string creditId)
        {
            TrNpp nppData = new TrNpp();
            try
            {
                nppData = await acquisitionContext.TrNpp
                    .Include(x => x.TrItems)
                    .Include(x => x.TrDealerOrderSourceTac)
                    .Include(x => x.TrDealerOrderSourceThirdParty)
                    .SingleAsync(d => d.CreditId.Equals(creditId));

                return nppData;
            }
            catch (Exception ex)
            {
                return nppData;
            }
        }

        public async Task<APIResponse> GetNppViewById(string creditId, string userId)
        {
            try
            {
                var npp = await acquisitionContext.GetProcedures().sp_get_npp_viewAsync(creditId, userId);

                if (npp.FirstOrDefault() != null)
                {
                    return new APIResponse(npp.FirstOrDefault());
                }

                return new APIResponse
                    (
                        Collection.Codes.NO_CONTENT,
                        Collection.Status.SUCCESS,
                        Collection.Messages.NO_CONTENT,
                        null
                    );
            }
            catch (Exception ex)
            {
                return new APIResponse
                    (
                        Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                        null
                    );
            }
        }

        public async Task<APIResponse> GetNppEditById(string creditId)
        {
            try
            {
                var npp = await acquisitionContext.GetProcedures().sp_get_npp_editAsync(creditId);

                if (npp.FirstOrDefault() != null)
                {
                    return new APIResponse(npp.FirstOrDefault());
                }

                return new APIResponse
                    (
                        Collection.Codes.NO_CONTENT,
                        Collection.Status.SUCCESS,
                        Collection.Messages.NO_CONTENT,
                        null
                    );
            }
            catch (Exception ex)
            {
                return new APIResponse
                    (
                        Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                        null
                    );
            }
        }

        public async Task<APIResponse> GetNppDataById(string creditId)
        {
            TrNpp nppData = new TrNpp();
            try
            {
                nppData = await acquisitionContext.TrNpp
                    .Include(x => x.TrItems)
                    .Include(x => x.TrDealerOrderSourceTac)
                    .Include(x => x.TrDealerOrderSourceThirdParty)
                    .SingleAsync(d => d.CreditId.Equals(creditId));

                return new APIResponse(nppData);
            }
            catch (Exception ex)
            {
                return new APIResponse
                    (
                        Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                        null
                    );
            }
        }

        public async Task<APIResponse> InsertCarTrNPPAsync(TrNppRequest NPPRequest)
        {
            try
            {
                using (var dbTransactions = acquisitionContext.Database.BeginTransaction())
                {
                    try
                    {
                        var agreementVal = await acquisitionContext.TrNpp.Select(x => AcquisitionContext.fn_get_agreement_value(NPPRequest.CreditId)).FirstAsync();
                        var CMData = await trCMRepository.GetCMByCreditId(NPPRequest.CreditId);

                        string insuranceId = "";
                        var _InsID = new LIBRARY.DTO.EntityFramework
                                    .Acquisition.AcquisitionContext
                                    .OutputParameter<string?>
                        { _value = insuranceId };

                        await acquisitionContext.GetProcedures().sp_get_insurance_random_R4Async(NPPRequest.CreditId, _InsID);

                        insuranceId = (string)_InsID._value;

                        decimal estimatedInsCost = 0;
                        var _estimatedInsCost = new LIBRARY.DTO.EntityFramework
                                    .Acquisition.AcquisitionContext
                                    .OutputParameter<decimal?>
                        { _value = estimatedInsCost };

                        await acquisitionContext.GetProcedures().sp_generate_estimated_insurance_cost_R4Async(
                            CMData.BranchId,
                            CMData.Tenor,
                            CMData.AssetCost,
                            DateTime.Now,
                            Int32.Parse(CMData.YearItem),
                            CMData.ModelId,
                            Int32.Parse(CMData.TipeGuna),
                            1,
                            "",
                            "",
                            "",
                            "",
                            "",
                            _estimatedInsCost);

                        estimatedInsCost = (decimal)_estimatedInsCost._value;

                        decimal? incentiveNominal = 0;
                        //Kondisi untuk data UMC
                        if (NPPRequest.ApplicationTypeId == "03")
                        {
                            //incentiveNominal = await acquisitionContext.TrNpp.Select(x => AcquisitionContext.fnEPGetInsentifMokasDealerAmtV3("", NPPRequest.CreditId)).FirstAsync();
                        }



                        var item = new TrItems
                        {
                            CreatedBy = NPPRequest.CreatedBy,
                            CreatedOn = DateTime.Now,
                            CreditId = NPPRequest.CreditId,
                            ChasisNo = NPPRequest.TrItems.ChasisNo,
                            MachineNo = NPPRequest.TrItems.MachineNo,
                            ItemColor = NPPRequest.TrItems.ItemColor,
                            KeyNo = NPPRequest.TrItems.KeyNo,
                            CarNoUmc = NPPRequest.TrItems.CarNoUmc
                        };

                        var osTAC = new List<TrDealerOrderSourceTac>();
                        foreach (var tac in NPPRequest.TrDealerOrderSourceTac)
                        {
                            var _tac = new TrDealerOrderSourceTac
                            {
                                CreatedBy = NPPRequest.CreatedBy,
                                CreatedOn = DateTime.Now,
                                CreditId = tac.CreditId,
                                JobTitleId = (int)tac.JobTitleId,
                                PersonelId = (int)tac.PersonelId,
                                PersonelName = tac.PersonelName,
                                RateTacRefund = (decimal)tac.RateTacRefund,
                                AmountTacRefund = (decimal)tac.AmountTacRefund,
                                AmountTacRefundAfterTax = (decimal)tac.AmountTacRefundAfterTax,
                                BankAccountNumber = tac.BankAccountNumber,
                                BankAccountName = tac.BankAccountName
                            };
                            osTAC.Add(_tac);
                        }

                        var osTP = new List<TrDealerOrderSourceThirdParty>();
                        foreach (var tp in NPPRequest.TrDealerOrderSourceThirdParty)
                        {
                            var _tp = new TrDealerOrderSourceThirdParty
                            {
                                CreatedBy = NPPRequest.CreatedBy,
                                CreatedOn = DateTime.Now,
                                CreditId = tp.CreditId,
                                JobTitleId = (int)tp.JobTitleId,
                                PersonelId = (int)tp.PersonelId,
                                PersonelName = tp.PersonelName,
                                RateProvisiRefund = (decimal)tp.RateProvisiRefund,
                                AmountProvisiRefund = (decimal)tp.AmountProvisiRefund,
                                AmountProvisiRefundAfterTax = (decimal)tp.AmountProvisiRefundAfterTax,
                                BankAccountNumber = tp.BankAccountNumber,
                                BankAccountName = tp.BankAccountName
                            };
                            osTP.Add(_tp);
                        }

                        var npp = new TrNpp
                        {
                            CreatedBy = NPPRequest.CreatedBy,
                            CreatedOn = DateTime.Now,
                            CreditId = NPPRequest.CreditId,
                            AgreementDate = DateTime.Now,
                            CompanyId = CMData.CompanyId == "MCF" ? "3" : "2",
                            BranchId = CMData.BranchId,
                            BillReceivedDate = NPPRequest.BillReceivedDate,
                            BillReceiptDate = NPPRequest.BillReceiptDate,
                            DownPaymentReceiptNo = NPPRequest.DownPaymentReceiptNo,
                            DownPaymentReceiptDate = NPPRequest.DownPaymentReceiptDate,
                            ReceiptNo = NPPRequest.ReceiptNo,
                            ReceiptDate = NPPRequest.ReceiptDate,
                            BpkbLetterNo = NPPRequest.BpkbLetterNo,
                            BpkbLetterDate = NPPRequest.BpkbLetterDate,
                            BastNo = NPPRequest.BastNo,
                            BastDate = NPPRequest.BastDate,
                            InstallmentDate = NPPRequest.InstallmentDate,
                            BankReferenceId = NPPRequest.BankReferenceId,
                            AgreementStatus = "R",
                            ConsumenInstallmentDate = NPPRequest.ConsumenInstallmentDate,
                            NfaPercent = NPPRequest.NfaPercent,
                            IsPlafon = NPPRequest.IsPlafon,
                            AgreementValue = agreementVal,
                            EstimatedInsuranceCost = estimatedInsCost,
                            InsuranceCoveragePeriod = NPPRequest.InsuranceCoveragePeriod,
                            OtherApValue = NPPRequest.OtherApValue,
                            InsuranceBillingPeriodical = NPPRequest.InsuranceBillingPeriodical,
                            BankReferenceSubId = NPPRequest.BankReferenceSubId,
                            DisbursalTypeUmc = NPPRequest.DisbursalTypeUmc,
                            DisbursalTypeUmcIncentive = "K",
                            IncentiveNominal = incentiveNominal,
                            InsuranceId = insuranceId.ToString(),
                            TrItems = item,
                            TrDealerOrderSourceTac = osTAC,
                            TrDealerOrderSourceThirdParty = osTP
                        };


                        // Insert into Table tr_hierarchy_transaction from master
                        string transTypeId = NPPRequest.ApplicationTypeId + "NP0001";
                        List<MsHierarchyTransaction> msHierarchyTrans = await mastersContext.MsHierarchyTransaction
                            .Where(x => x.IsActive && x.TransTypeId == transTypeId)
                            .OrderBy(x => x.Level)
                            .ToListAsync();

                        var trHierarchyTrans = new List<TrHierarchyTransaction>();
                        int i = 1;
                        foreach (var ht in msHierarchyTrans)
                        {
                            var _ht = new TrHierarchyTransaction
                            {
                                CreatedBy = NPPRequest.CreatedBy,
                                CreatedOn = DateTime.Now,
                                TransId = NPPRequest.CreditId,
                                TransTypeId = transTypeId,
                                TransDate = ht.EmployeeId == NPPRequest.CreatedBy ? DateTime.Now : null,
                                EmployeeId = ht.EmployeeId,
                                NextEmployeeId = ht.SpvEmployeeId,
                                HierarchyTransId = i,
                                Status = i == 1 ? "0" : null
                            };

                            trHierarchyTrans.Add(_ht);
                            i++;
                        }

                        await acquisitionContext.TrNpp.AddAsync(npp);
                        await acquisitionContext.AddRangeAsync(trHierarchyTrans);

                        await acquisitionContext.SaveChangesAsync();
                        await dbTransactions.CommitAsync();

                        return new APIResponse
                            (
                                Collection.Codes.CREATED,
                                Collection.Status.SUCCESS,
                                Collection.Messages.CREATED,
                                NPPRequest
                            );
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
                return new APIResponse
                    (
                        Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                        null
                    );
            }
        }

        public async Task<APIResponse> InsertMotorcyleTrNPPAsync(TrNppRequest NPPRequest)
        {
            try
            {
                using (var dbTransactions = acquisitionContext.Database.BeginTransaction())
                {
                    try
                    {
                        var agreementVal = await acquisitionContext.TrNpp.Select(x => AcquisitionContext.fn_get_agreement_value(NPPRequest.CreditId)).FirstAsync();
                        var CMData = await trCMRepository.GetCMByCreditId(NPPRequest.CreditId);
                        var nfaPercent = (CMData.JmlPembiayaan / CMData.AssetCost) * 100;

                        string insuranceId = "";
                        var _InsID = new LIBRARY.DTO.EntityFramework
                                    .Acquisition.AcquisitionContext
                                    .OutputParameter<string?>
                        { _value = insuranceId };

                        await acquisitionContext.GetProcedures().sp_get_insurance_random_R2Async(NPPRequest.CreditId, _InsID);

                        insuranceId = (string)_InsID._value;

                        //insId == null ? null : insId.Substring(insId.Length - 3, 3)

                        //var insId = insuranceId == -1 ? null : "000" + insuranceId.ToString();

                        decimal estimatedInsCost = 0;
                        var _estimatedInsCost = new LIBRARY.DTO.EntityFramework
                                    .Acquisition.AcquisitionContext
                                    .OutputParameter<decimal?>
                        { _value = estimatedInsCost };

                        await acquisitionContext.GetProcedures().sp_generate_estimated_insurance_cost_R2Async(
                            CMData.AssetCost,
                            CMData.CompanyId == "MCF" ? "3" : "2",
                            CMData.BranchId,
                            CMData.Tenor,
                            0,
                            "FC_MSTAPP_MCF.dbo.ms_insurance_cost_rate_R2_OJK",
                            insuranceId,
                            _estimatedInsCost);

                        estimatedInsCost = (decimal)_estimatedInsCost._value;

                        //Kondisi untuk data UMC
                        decimal? incentiveNominal = 0;
                        if (NPPRequest.ApplicationTypeId == "03")
                        {
                            //incentiveNominal = await acquisitionContext.TrNpp.Select(x => AcquisitionContext.fnEPGetInsentifMokasDealerAmtV3("", NPPRequest.CreditId)).FirstAsync();
                        }

                        var item = new TrItems
                        {
                            CreatedBy = NPPRequest.CreatedBy,
                            CreatedOn = DateTime.Now,
                            CreditId = NPPRequest.CreditId,
                            ChasisNo = NPPRequest.TrItems.ChasisNo,
                            MachineNo = NPPRequest.TrItems.MachineNo,
                            ItemColor = NPPRequest.TrItems.ItemColor,
                            KeyNo = NPPRequest.TrItems.KeyNo,
                            CarNoUmc = NPPRequest.TrItems.CarNoUmc
                        };

                        var npp = new TrNpp
                        {
                            CreatedBy = NPPRequest.CreatedBy,
                            CreatedOn = DateTime.Now,
                            CreditId = NPPRequest.CreditId,
                            AgreementDate = DateTime.Now,
                            CompanyId = CMData.CompanyId == "MCF" ? "3" : "2",
                            BranchId = CMData.BranchId,
                            BillReceivedDate = NPPRequest.BillReceivedDate,
                            BillReceiptDate = NPPRequest.BillReceiptDate,
                            DownPaymentReceiptNo = NPPRequest.DownPaymentReceiptNo,
                            DownPaymentReceiptDate = NPPRequest.DownPaymentReceiptDate,
                            ReceiptNo = NPPRequest.ReceiptNo,
                            ReceiptDate = NPPRequest.ReceiptDate,
                            BpkbLetterNo = NPPRequest.BpkbLetterNo,
                            BpkbLetterDate = NPPRequest.BpkbLetterDate,
                            BastNo = NPPRequest.BastNo,
                            BastDate = NPPRequest.BastDate,
                            InstallmentDate = NPPRequest.InstallmentDate,
                            BankReferenceId = NPPRequest.BankReferenceId,
                            AgreementStatus = "0",
                            ConsumenInstallmentDate = NPPRequest.ConsumenInstallmentDate,
                            NfaPercent = NPPRequest.NfaPercent,
                            IsPlafon = NPPRequest.IsPlafon,
                            AgreementValue = agreementVal,
                            EstimatedInsuranceCost = estimatedInsCost,
                            InsuranceCoveragePeriod = NPPRequest.InsuranceCoveragePeriod,
                            OtherApValue = NPPRequest.OtherApValue,
                            InsuranceBillingPeriodical = NPPRequest.InsuranceBillingPeriodical,
                            BankReferenceSubId = NPPRequest.BankReferenceSubId,
                            DisbursalTypeUmc = NPPRequest.DisbursalTypeUmc,
                            DisbursalTypeUmcIncentive = "K",
                            IncentiveNominal = incentiveNominal,
                            InsuranceId = insuranceId,
                            TrItems = item
                        };

                        // Insert into Table tr_hierarchy_transaction from master
                        string transTypeId = NPPRequest.ApplicationTypeId + "NP0001";
                        List<MsHierarchyTransaction> msHierarchyTrans = await mastersContext.MsHierarchyTransaction
                            .Where(x => x.IsActive && x.TransTypeId == transTypeId)
                            .OrderBy(x => x.Level)
                            .ToListAsync();

                        var trHierarchyTrans = new List<TrHierarchyTransaction>();
                        int i = 1;
                        foreach (var ht in msHierarchyTrans)
                        {
                            var _ht = new TrHierarchyTransaction
                            {
                                CreatedBy = NPPRequest.CreatedBy,
                                CreatedOn = DateTime.Now,
                                TransId = NPPRequest.CreditId,
                                TransTypeId = transTypeId,
                                TransDate = ht.EmployeeId == NPPRequest.CreatedBy ? DateTime.Now : null,
                                EmployeeId = ht.EmployeeId,
                                NextEmployeeId = ht.SpvEmployeeId,
                                HierarchyTransId = i,
                                Status = i == 1 ? "0" : null
                            };

                            trHierarchyTrans.Add(_ht);
                            i++;
                        }


                        await acquisitionContext.TrNpp.AddAsync(npp);
                        await acquisitionContext.AddRangeAsync(trHierarchyTrans);

                        await acquisitionContext.SaveChangesAsync();


                        await dbTransactions.CommitAsync();
                        return new APIResponse
                            (
                                Collection.Codes.CREATED,
                                Collection.Status.SUCCESS,
                                Collection.Messages.CREATED,
                                npp
                            );
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
                return new APIResponse
                    (
                        Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                        null
                    );
            }
        }

        public async Task<APIResponse> UpdateCarTrNPPAsync(TrNppRequest NPPRequest)
        {
            try
            {
                using (var dbTransactions = acquisitionContext.Database.BeginTransaction())
                {
                    try
                    {
                        var existingData = GetNppRelationalById(NPPRequest.CreditId).Result;

                        acquisitionContext.TrDealerOrderSourceTac
                            .RemoveRange(existingData.TrDealerOrderSourceTac);

                        acquisitionContext.TrDealerOrderSourceThirdParty
                            .RemoveRange(existingData.TrDealerOrderSourceThirdParty);

                        await acquisitionContext.SaveChangesAsync();

                        var agreementVal = await acquisitionContext.TrNpp.Select(x => AcquisitionContext.fn_get_agreement_value(NPPRequest.CreditId)).FirstAsync();

                        var osTAC = new List<TrDealerOrderSourceTac>();
                        foreach (var tac in NPPRequest.TrDealerOrderSourceTac)
                        {
                            var _tac = new TrDealerOrderSourceTac
                            {
                                CreatedBy = existingData.CreatedBy,
                                CreatedOn = existingData.CreatedOn,
                                LastUpdatedBy = NPPRequest.LastUpdatedBy,
                                LastUpdatedOn = DateTime.Now,
                                CreditId = existingData.CreditId,
                                JobTitleId = (int)tac.JobTitleId,
                                PersonelId = (int)tac.PersonelId,
                                PersonelName = tac.PersonelName,
                                RateTacRefund = (decimal)tac.RateTacRefund,
                                AmountTacRefund = (decimal)tac.AmountTacRefund,
                                AmountTacRefundAfterTax = (decimal)tac.AmountTacRefundAfterTax,
                                BankAccountNumber = tac.BankAccountNumber,
                                BankAccountName = tac.BankAccountName
                            };
                            osTAC.Add(_tac);
                        }

                        var osTP = new List<TrDealerOrderSourceThirdParty>();
                        foreach (var tp in NPPRequest.TrDealerOrderSourceThirdParty)
                        {
                            var _tp = new TrDealerOrderSourceThirdParty
                            {
                                CreatedBy = existingData.CreatedBy,
                                CreatedOn = existingData.CreatedOn,
                                LastUpdatedBy = NPPRequest.LastUpdatedBy,
                                LastUpdatedOn = DateTime.Now,
                                CreditId = existingData.CreditId,
                                JobTitleId = (int)tp.JobTitleId,
                                PersonelId = (int)tp.PersonelId,
                                PersonelName = tp.PersonelName,
                                RateProvisiRefund = (decimal)tp.RateProvisiRefund,
                                AmountProvisiRefund = (decimal)tp.AmountProvisiRefund,
                                AmountProvisiRefundAfterTax = (decimal)tp.AmountProvisiRefundAfterTax,
                                BankAccountNumber = tp.BankAccountNumber,
                                BankAccountName = tp.BankAccountName
                            };
                            osTP.Add(_tp);
                        }

                        //Manipulate Data TrNpp
                        existingData.CreatedBy = existingData.CreatedBy;
                        existingData.CreatedOn = existingData.CreatedOn;
                        existingData.LastUpdatedBy = NPPRequest.LastUpdatedBy;
                        existingData.LastUpdatedOn = DateTime.Now;
                        existingData.CreditId = existingData.CreditId;
                        existingData.AgreementDate = DateTime.Now;
                        existingData.CompanyId = NPPRequest.CompanyId;
                        existingData.BranchId = NPPRequest.BranchId;
                        existingData.BillReceivedDate = NPPRequest.BillReceivedDate;
                        existingData.BillReceiptDate = NPPRequest.BillReceiptDate;
                        existingData.DownPaymentReceiptNo = NPPRequest.DownPaymentReceiptNo;
                        existingData.DownPaymentReceiptDate = NPPRequest.DownPaymentReceiptDate;
                        existingData.ReceiptNo = NPPRequest.ReceiptNo;
                        existingData.ReceiptDate = NPPRequest.ReceiptDate;
                        existingData.BpkbLetterNo = NPPRequest.BpkbLetterNo;
                        existingData.BpkbLetterDate = NPPRequest.BpkbLetterDate;
                        existingData.BastNo = NPPRequest.BastNo;
                        existingData.BastDate = NPPRequest.BastDate;
                        existingData.InstallmentDate = NPPRequest.InstallmentDate;
                        existingData.BankReferenceId = NPPRequest.BankReferenceId;
                        existingData.AgreementStatus = "R";
                        existingData.ConsumenInstallmentDate = NPPRequest.ConsumenInstallmentDate;
                        existingData.NfaPercent = NPPRequest.NfaPercent;
                        existingData.IsPlafon = NPPRequest.IsPlafon;
                        existingData.AgreementValue = agreementVal;
                        existingData.EstimatedInsuranceCost = NPPRequest.EstimatedInsuranceCost;
                        existingData.InsuranceCoveragePeriod = NPPRequest.InsuranceCoveragePeriod;
                        existingData.OtherApValue = NPPRequest.OtherApValue;
                        existingData.InsuranceBillingPeriodical = NPPRequest.InsuranceBillingPeriodical;
                        existingData.BankReferenceSubId = NPPRequest.BankReferenceSubId;
                        existingData.DisbursalTypeUmc = NPPRequest.DisbursalTypeUmc;
                        existingData.DisbursalTypeUmcIncentive = "K";
                        existingData.IncentiveNominal = NPPRequest.IncentiveNominal;
                        existingData.InsuranceId = NPPRequest.InsuranceId;

                        //Manipulate Data TrItems
                        existingData.TrItems.CreatedBy = existingData.CreatedBy;
                        existingData.TrItems.CreatedOn = existingData.CreatedOn;
                        existingData.TrItems.LastUpdatedBy = NPPRequest.LastUpdatedBy;
                        existingData.TrItems.LastUpdatedOn = DateTime.Now;
                        existingData.TrItems.CreditId = existingData.CreditId;
                        existingData.TrItems.ChasisNo = NPPRequest.TrItems.ChasisNo;
                        existingData.TrItems.MachineNo = NPPRequest.TrItems.MachineNo;
                        existingData.TrItems.ItemColor = NPPRequest.TrItems.ItemColor;
                        existingData.TrItems.KeyNo = NPPRequest.TrItems.KeyNo;
                        existingData.TrItems.CarNoUmc = NPPRequest.TrItems.CarNoUmc;

                        //Add Dynamic Data TrOrderSourceTAC and TrOrderSourceThirdParty
                        acquisitionContext.AddRangeAsync(osTAC);
                        acquisitionContext.AddRangeAsync(osTP);


                        // Insert into Table tr_hierarchy_transaction from master
                        string transTypeId = NPPRequest.ApplicationTypeId + "NP0001";
                        List<MsHierarchyTransaction> msHierarchyTrans = await mastersContext.MsHierarchyTransaction
                            .Where(x => x.IsActive && x.TransTypeId == transTypeId)
                            .OrderBy(x => x.Level)
                            .ToListAsync();

                        var trHierarchyTrans = new List<TrHierarchyTransaction>();
                        int i = 1;
                        foreach (var ht in msHierarchyTrans)
                        {
                            var _ht = new TrHierarchyTransaction
                            {
                                CreatedBy = NPPRequest.CreatedBy,
                                CreatedOn = DateTime.Now,
                                TransId = NPPRequest.CreditId,
                                TransTypeId = transTypeId,
                                TransDate = ht.EmployeeId == NPPRequest.CreatedBy ? DateTime.Now : null,
                                EmployeeId = ht.EmployeeId,
                                NextEmployeeId = ht.SpvEmployeeId,
                                HierarchyTransId = i,
                                Status = i == 1 ? "0" : null
                            };

                            trHierarchyTrans.Add(_ht);
                            i++;
                        }

                        await acquisitionContext.AddRangeAsync(trHierarchyTrans);

                        await acquisitionContext.SaveChangesAsync();
                        await dbTransactions.CommitAsync();

                        return new APIResponse
                            (
                                Collection.Codes.CREATED,
                                Collection.Status.SUCCESS,
                                Collection.Messages.CREATED,
                                NPPRequest
                            );
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
                return new APIResponse
                    (
                        Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                        null
                    );
            }
        }

        public async Task<APIResponse> UpdateMotorcycleTrNPPAsync(TrNppRequest NPPRequest)
        {
            try
            {
                using (var dbTransactions = acquisitionContext.Database.BeginTransaction())
                {
                    try
                    {
                        var existingData = GetNppRelationalById(NPPRequest.CreditId).Result;

                        var agreementVal = await acquisitionContext.TrNpp.Select(x => AcquisitionContext.fn_get_agreement_value(NPPRequest.CreditId)).FirstAsync();

                        //Manipulate Data TrNpp
                        existingData.CreatedBy = existingData.CreatedBy;
                        existingData.CreatedOn = existingData.CreatedOn;
                        existingData.LastUpdatedBy = NPPRequest.LastUpdatedBy;
                        existingData.LastUpdatedOn = DateTime.Now;
                        existingData.CreditId = existingData.CreditId;
                        existingData.AgreementDate = DateTime.Now;
                        existingData.CompanyId = NPPRequest.CompanyId;
                        existingData.BranchId = NPPRequest.BranchId;
                        existingData.BillReceivedDate = NPPRequest.BillReceivedDate;
                        existingData.BillReceiptDate = NPPRequest.BillReceiptDate;
                        existingData.DownPaymentReceiptNo = NPPRequest.DownPaymentReceiptNo;
                        existingData.DownPaymentReceiptDate = NPPRequest.DownPaymentReceiptDate;
                        existingData.ReceiptNo = NPPRequest.ReceiptNo;
                        existingData.ReceiptDate = NPPRequest.ReceiptDate;
                        existingData.BpkbLetterNo = NPPRequest.BpkbLetterNo;
                        existingData.BpkbLetterDate = NPPRequest.BpkbLetterDate;
                        existingData.BastNo = NPPRequest.BastNo;
                        existingData.BastDate = NPPRequest.BastDate;
                        existingData.InstallmentDate = NPPRequest.InstallmentDate;
                        existingData.BankReferenceId = NPPRequest.BankReferenceId;
                        existingData.AgreementStatus = "R";
                        existingData.ConsumenInstallmentDate = NPPRequest.ConsumenInstallmentDate;
                        existingData.NfaPercent = NPPRequest.NfaPercent;
                        existingData.IsPlafon = NPPRequest.IsPlafon;
                        existingData.AgreementValue = agreementVal;
                        existingData.EstimatedInsuranceCost = NPPRequest.EstimatedInsuranceCost;
                        existingData.InsuranceCoveragePeriod = NPPRequest.InsuranceCoveragePeriod;
                        existingData.OtherApValue = NPPRequest.OtherApValue;
                        existingData.InsuranceBillingPeriodical = NPPRequest.InsuranceBillingPeriodical;
                        existingData.BankReferenceSubId = NPPRequest.BankReferenceSubId;
                        existingData.DisbursalTypeUmc = NPPRequest.DisbursalTypeUmc;
                        existingData.DisbursalTypeUmcIncentive = "K";
                        existingData.IncentiveNominal = NPPRequest.IncentiveNominal;
                        existingData.InsuranceId = NPPRequest.InsuranceId;

                        //Manipulate Data TrItems
                        existingData.TrItems.CreatedBy = existingData.CreatedBy;
                        existingData.TrItems.CreatedOn = existingData.CreatedOn;
                        existingData.TrItems.LastUpdatedBy = NPPRequest.LastUpdatedBy;
                        existingData.TrItems.LastUpdatedOn = DateTime.Now;
                        existingData.TrItems.CreditId = existingData.CreditId;
                        existingData.TrItems.ChasisNo = NPPRequest.TrItems.ChasisNo;
                        existingData.TrItems.MachineNo = NPPRequest.TrItems.MachineNo;
                        existingData.TrItems.ItemColor = NPPRequest.TrItems.ItemColor;
                        existingData.TrItems.KeyNo = NPPRequest.TrItems.KeyNo;
                        existingData.TrItems.CarNoUmc = NPPRequest.TrItems.CarNoUmc;

                        //existingData = npp;

                        //context.Entry(existingData).State = EntityState.Modified;


                        // Insert into Table tr_hierarchy_transaction from master
                        string transTypeId = NPPRequest.ApplicationTypeId + "NP0001";
                        List<MsHierarchyTransaction> msHierarchyTrans = await mastersContext.MsHierarchyTransaction
                            .Where(x => x.IsActive && x.TransTypeId == transTypeId)
                            .OrderBy(x => x.Level)
                            .ToListAsync();

                        var trHierarchyTrans = new List<TrHierarchyTransaction>();
                        int i = 1;
                        foreach (var ht in msHierarchyTrans)
                        {
                            var _ht = new TrHierarchyTransaction
                            {
                                CreatedBy = NPPRequest.CreatedBy,
                                CreatedOn = DateTime.Now,
                                TransId = NPPRequest.CreditId,
                                TransTypeId = transTypeId,
                                TransDate = ht.EmployeeId == NPPRequest.CreatedBy ? DateTime.Now : null,
                                EmployeeId = ht.EmployeeId,
                                NextEmployeeId = ht.SpvEmployeeId,
                                HierarchyTransId = i,
                                Status = i == 1 ? "0" : null
                            };

                            trHierarchyTrans.Add(_ht);
                            i++;
                        }

                        await acquisitionContext.AddRangeAsync(trHierarchyTrans);

                        await acquisitionContext.SaveChangesAsync();

                        await dbTransactions.CommitAsync();

                        return new APIResponse
                            (
                                Collection.Codes.SUCCESS,
                                Collection.Status.SUCCESS,
                                Collection.Messages.SUCCESS,
                                NPPRequest
                            );
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
                return new APIResponse
                    (
                        Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                        null
                    );
            }
        }

        public async Task<APIResponse> ApprovalNPPAsync(TrNppRequest NPPRequest)
        {
            try
            {
                using(var dbTransactions = acquisitionContext.Database.BeginTransaction())
                {
                    try
                    {

                        var data = await acquisitionContext.GetProcedures().sp_approve_nppAsync(
                                                                        NPPRequest.CreditId
                                                                        , NPPRequest.ReasonId
                                                                        , NPPRequest.ReasonDesc
                                                                        , NPPRequest.StatusApproval
                                                                        , NPPRequest.CreatedBy);

                        sp_approve_nppResult dataProcess = data.FirstOrDefault();

                        #region Rapindo Claim Asset
                        //var token_code = dataProcess.CompanyId == "2" ? EndpointAPI.Token.TokenCodeRapindoMCFLive : EndpointAPI.Token.TokenCodeRapindoMAFLive;
                        //object input = new
                        //{
                        //    chassisNo = dataProcess.ChasisNo,
                        //    engineNo = dataProcess.MachineNo,
                        //    licensePlate = "",
                        //    type = dataProcess.ItemId == "002" ? "RODA_EMPAT" : "RODA_DUA",
                        //    vehicleType = dataProcess.ItemTypeName,
                        //    manufactureYear = dataProcess.YearItem,
                        //    brand = dataProcess.ItemMerk,
                        //    contractNo = dataProcess.CreditId,
                        //    contractDate = dataProcess.AgreementDate
                        //};
                        //RapindoResponse rapindo = await this.GetAPIResponse($"{EndpointAPI.Endpoint.RAPINDOLIVEURL}RAPINDO/ClaimAsset"
                        //                                                    , Method.Post
                        //                                                    , input
                        //                                                    , token_code
                        //                                                    , null, null, null);

                        //if (!rapindo.status)
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
                                data
                                );
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
                        ex.Message,
                        null);
            }
        }

       public async Task<APIResponse> CheckRapindo(string ChassisNo, string BranchName, string BranchId, string UserName,string CompanyId)
        {
            try
            {
                var token_code = CompanyId == "2" ? EndpointAPI.Token.TokenCodeRapindoMCFLive : EndpointAPI.Token.TokenCodeRapindoMAFLive;
                object input = new
                {
                    chassisNo = ChassisNo
                };
                RapindoResponse rapindoResponse =  await this.GetAPIResponse($"{EndpointAPI.Endpoint.RAPINDOLIVEURL}RAPINDO/SearchAsset"
                                                                                , Method.Post
                                                                                , input
                                                                                , token_code
                                                                                , UserName
                                                                                , BranchName
                                                                                , BranchId);
                if (!rapindoResponse.status)
                {
                    return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                       Collection.Status.FAILED,
                                       rapindoResponse.message,
                                       null);
                }

                return new APIResponse(Collection.Codes.SUCCESS,
                                      Collection.Status.SUCCESS,
                                      rapindoResponse.message,
                                      null);
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