using FINCORE.HELPER.LIBRARY.Helper;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.Model.Acquisition.CAS;
using FINCORE.LIBRARY.DTO.Model.Acquisition.CAS.ModelHelper;
using FINCORE.SERVICE.CREDITS.Repositories.Interfaces;
using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static FINCORE.HELPER.LIBRARY.Helper.Commons;
using static FINCORE.HELPER.LIBRARY.Request.GeneratedCode;

namespace FINCORE.SERVICE.CREDITS.Repositories.EF
{
    public class TrCasRepositoryEF : ITrCas
    {
        private AcquisitionContext acquisitionContext;

        public TrCasRepositoryEF(AcquisitionContext _acquisitionContext)
            => this.acquisitionContext = _acquisitionContext;

        public async Task<APIResponse> GenerateCreditId(string branchdId)
        {
            try
            {
                var credit_id = new OutputParameter<string?> { _value = string.Empty };

                var data = await acquisitionContext
                    .GetProcedures()
                    .sp_get_auto_numberAsync(branchdId, CodeType.TR_CAS, credit_id);
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }

        public async Task<APIResponse> InsertTrCasMobilAsync(TrCasModels trCasModels)
        {
            try
            {
                #region Mapping collections model item value from FE

                trCasModels.credit_id = trCasModels.credit_id;
                trCasModels.created_on = DateTime.Now;
                var trInstallments = new List<TrCasInstallment>();
                for (int i = 0; i < trCasModels.Installments.monthly_other_installment_id.Length; i++)
                {
                    trInstallments.Add(new TrCasInstallment
                    {
                        CreatedBy = trCasModels.created_by,
                        CreatedOn = trCasModels.created_on,
                        CreditId = trCasModels.credit_id,
                        LastUpdatedBy = trCasModels.last_updated_by,
                        LastUpdatedOn = trCasModels.last_updated_on,
                        MonthlyOtherInstallmentId = trCasModels.Installments.monthly_other_installment_id[i]
                    });
                }
                var trPaymentPoints = new List<TrCasPaymentPoint>();
                for (int i = 0; i < trCasModels.PaymentPoints.payment_point_id.Length; i++)
                {
                    trPaymentPoints.Add(new TrCasPaymentPoint
                    {
                        CreatedBy = trCasModels.created_by,
                        CreatedOn = trCasModels.created_on,
                        LastUpdatedBy = "",
                        LastUpdatedOn = null,
                        CreditId = trCasModels.credit_id,
                        PaymentPointId = trCasModels.PaymentPoints.payment_point_id[i],
                        PaymentTypeId = trCasModels.PaymentPoints.payment_type_id[i]
                    });
                }
                var trCorporateDoc = new TrCasCorporateDocument();
                if (trCasModels.customer_type == CustomerTypes.CORPORATE_TYPE_CODE)
                {
                    trCorporateDoc = new TrCasCorporateDocument
                    {
                        CreditId = trCasModels.credit_id,
                        CorporateCommisionerName = trCasModels.CorporateDocuments.corporate_commisioner_name,
                        CorporateDirectorName = trCasModels.CorporateDocuments.corporate_director_name,
                        CorporateDebiturType = trCasModels.CorporateDocuments.corporate_debitur_type,
                        CorporateEmail = trCasModels.CorporateDocuments.corporate_email,
                        CorporateFaxNumber = trCasModels.CorporateDocuments.corporate_fax_number,
                        CorporateIndustryId = trCasModels.CorporateDocuments.corporate_industry_id,
                        CommissionerIdentityNumber = trCasModels.CorporateDocuments.commissioner_identity_number,
                        CompletenessLetterDueDate = trCasModels.CorporateDocuments.completeness_letter_due_date,
                        CompletenessLetterIssueDate = trCasModels.CorporateDocuments.completeness_letter_issue_date,
                        CorporateMonthPeriod = trCasModels.CorporateDocuments.corporate_month_period,
                        CorporateNumberOfEmployee = trCasModels.CorporateDocuments.corporate_number_of_employee,
                        CorporateOtherIndustry = trCasModels.CorporateDocuments.corporate_other_industry,
                        CorporateSite = trCasModels.CorporateDocuments.corporate_site,
                        CorporateStatus = trCasModels.CorporateDocuments.corporate_status,
                        CorporateTaxIdNumber = trCasModels.CorporateDocuments.corporate_tax_idNumber,
                        CorporateTelephoneNumber = trCasModels.CorporateDocuments.corporate_telephone_number,
                        CorporateYearPeriod = trCasModels.CorporateDocuments.corporate_year_period,
                        IsCompletenessLetter = trCasModels.CorporateDocuments.is_completeness_letter,
                        DirectorIdentityNumber = trCasModels.CorporateDocuments.director_identity_number,
                        DirectorTaxIdNumber = trCasModels.CorporateDocuments.director_tax_id_number,
                        FoundersDeedDate = trCasModels.CorporateDocuments.founders_deed_date,
                        FoundersDeedNumber = trCasModels.CorporateDocuments.founders_deed_number,
                        FoundersNotaryName = trCasModels.CorporateDocuments.founders_notary_name,
                        ManagementDeedDate = trCasModels.CorporateDocuments.management_deed_date,
                        ManagementDeedNumber = trCasModels.CorporateDocuments.management_deed_number,
                        ManagementNotaryName = trCasModels.CorporateDocuments.management_notary_name,
                        SiupDueDate = trCasModels.CorporateDocuments.siup_due_date,
                        SiupId = trCasModels.CorporateDocuments.siup_id,
                        SiupIssueDate = trCasModels.CorporateDocuments.siup_issue_date,
                        TdpId = trCasModels.CorporateDocuments.tdp_id,
                        TdpDueDate = trCasModels.CorporateDocuments.tdp_due_date,
                        TdpIssueDate = trCasModels.CorporateDocuments.siup_issue_date,
                        CreatedOn = trCasModels.created_on,
                        CreatedBy = trCasModels.created_by,
                        LastUpdatedBy = "",
                        LastUpdatedOn = trCasModels.last_updated_on,
                    };
                }

                var dataReferences = MappingTrCasReferencesCollections(trCasModels, null);
                var dataApuppts = MappingTrCasApuppts(trCasModels, null);
                var dataRo = MappingTrCasRepeatOrder(trCasModels);

                #endregion Mapping collections model item value from FE

                #region Assign all model collection into TrCas

                var trCas = new TrCas
                {
                    CreatedBy = trCasModels.created_by,
                    CreatedOn = trCasModels.created_on,
                    CreditId = trCasModels.credit_id,
                    BranchId = trCasModels.branch_id,
                    OutletCode = trCasModels.outlet_code,
                    CreditSourceId = trCasModels.credit_source_id,
                    OrderId = trCasModels.order_id,
                    CustomerType = trCasModels.customer_type,
                    IsRepeatOrder = trCasModels.is_repeat_order,
                    IsInstantApproval = trCasModels.is_instant_approval,
                    RepeatOrderReason = trCasModels.repeat_order_reason,
                    CustomerName = trCasModels.customer_name, //dipake di C and P
                    BirthPlace = trCasModels.birth_place, //dipake di C and P
                    BirthDate = trCasModels.birth_date, //dipake di C and P
                    Gender = trCasModels.gender,
                    MotherName = trCasModels.mother_name,
                    Email = trCasModels.email,
                    IdentityTypeId = trCasModels.identity_type_id,
                    IdentityNumber = trCasModels.identity_number,
                    ValidThru = trCasModels.valid_thru,
                    CompanyId = trCasModels.company_id,
                    IssueDate = trCasModels.issue_date,
                    IdentityAddress = trCasModels.identity_address,
                    IdentityLocationId = trCasModels.identity_location_id,
                    IsBlacklist = trCasModels.is_blacklist,
                    CustomerAddress = trCasModels.customer_address,
                    CustomerLocationId = trCasModels.customer_location_id,
                    NpwpNo = trCasModels.npwp_no,
                    TelephoneNumber = trCasModels.telephone_number,
                    MobilePhone = trCasModels.mobile_phone,
                    ResidenceDistance = trCasModels.residence_distance,
                    CustomerSourceId = trCasModels.customer_source_id,
                    IsSurveyed = trCasModels.is_surveyed,
                    SourcesId = trCasModels.sources_id,
                    SourcesName = trCasModels.sources_name,
                    SourcesAddress = trCasModels.sources_address,
                    EvaluationId = trCasModels.evaluation_id,
                    ResidenceStatusId = trCasModels.residence_status_id.ToString(),
                    OwnershipProof = trCasModels.ownership_proof,
                    OwnershipProofName = trCasModels.ownership_proof_name,
                    ResidenceCondition = trCasModels.residence_condition,
                    MaritalStatus = Convert.ToInt32(trCasModels.marital_status),
                    MailToSourceId = trCasModels.mail_to_source_id,
                    MailToAddress = trCasModels.mail_to_address,
                    MailToLocationId = trCasModels.mail_to_location_id,
                    MailToTelephoneNumber = trCasModels.mail_to_telephone_number,
                    CreditSourceStatus = trCasModels.credit_source_status,
                    Analysis = trCasModels.analysis,
                    Conclusion = trCasModels.conclusion,
                    IsApuppt = trCasModels.is_apuppt == null ? 0 : trCasModels.is_apuppt,
                    TrCasReferences = dataReferences.Count == 0 ? null : dataReferences,
                    TrCasCorporateDocument = trCasModels.customer_type == CustomerTypes.CORPORATE_TYPE_CODE ? trCorporateDoc : null,
                    TrCasFinancial = new TrCasFinancial
                    {
                        CreatedBy = trCasModels.created_by,
                        CreditId = trCasModels.credit_id,
                        EducationExpenses = trCasModels.Financials.education_expenses,
                        HealthExpenses = trCasModels.Financials.health_expenses,
                        HouseholdExpenses = trCasModels.Financials.household_expenses,
                        IndustryTypeId = trCasModels.Financials.industry_type_id,
                        CommodityType = trCasModels.Financials.commodity_type,
                        NumberOfDependents = trCasModels.Financials.number_of_dependents,
                        ProfessionId = trCasModels.Financials.profession_id.ToString(),
                        PrimaryIncome = trCasModels.Financials.primary_income,
                        OtherIncome = trCasModels.Financials.other_income,
                        OtherIncomeDesc = trCasModels.Financials.other_income_desc,
                        Position = trCasModels.Financials.position,
                        OfficeLocationId = trCasModels.Financials.office_location_id,
                        OfficeName = trCasModels.Financials.office_name,
                        OfficeTelephoneNumber = trCasModels.Financials.office_telephone_number,
                        OfficeFax = trCasModels.Financials.office_fax,
                        OfficeAddress = trCasModels.Financials.office_address,
                        YearsOfWorkExperience = trCasModels.Financials.years_of_work_experience,
                        MonthlyOtherInstallment = trCasModels.Financials.monthly_other_installment,
                        CreatedOn = trCasModels.created_on,
                        LastUpdatedBy = "",
                        LastUpdatedOn = trCasModels.last_updated_on
                    },
                    TrCasRepeatOrder = trCasModels.is_repeat_order is true ? dataRo : null,
                    TrCasInstallment = trInstallments,
                    TrCasPaymentPoint = trPaymentPoints,
                    TrCasApuppt = dataApuppts
                };
                await acquisitionContext.TrCas.AddAsync(trCas); //insert

                #endregion Assign all model collection into TrCas

                //commit transaction
                await acquisitionContext.SaveChangesAsync();

                //insert history Generated CreditId
                await InsertGenerateCodeHistoryAsync(new TrGenerateCodeHistory
                {
                    BranchId = trCasModels.branch_id,
                    CodeType = CodeType.TR_CAS,
                    CodeOutput = trCasModels.credit_id,
                    EmployeeId = trCasModels.created_by,
                    StatusTransaction = Collection.Status.SUCCESS
                });

                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        $"{Collection.Messages.CREATED}. Credit Id: {trCasModels.credit_id}",
                        null);
            }
            catch (Exception ex)
            {
                //insert history Generated CreditId
                await InsertGenerateCodeHistoryAsync(new TrGenerateCodeHistory
                {
                    BranchId = trCasModels.branch_id,
                    CodeType = CodeType.TR_CAS,
                    CodeOutput = trCasModels.credit_id,
                    EmployeeId = trCasModels.created_by,
                    StatusTransaction = Collection.Status.FAILED
                });

                return new APIResponse(Collection.Codes.FORBIDDEN,
                         Collection.Status.FAILED,
                         $"{ex.Message}. {ex.InnerException}. {Collection.Messages.TRANSACTION_ROLLBACK}",
                         Collection.Messages.TRANSACTION_ROLLBACK);
            }
        }

        public async Task<APIResponse> UpdateTrCasMobilAsync(TrCasModels trCasModels)
        {
            try
            {
                using (var transaction = acquisitionContext.Database.BeginTransaction())
                {
                    var existingItems = GetDeserializeTrCasData(trCasModels.credit_id).Result; //Get existing data

                    #region Remove All Data from Table TrInstallment, PaymentPoint, References

                    acquisitionContext.TrCasInstallment.RemoveRange(existingItems.TrCasInstallment); //remove existing data trInstallments
                    acquisitionContext.TrCasPaymentPoint.RemoveRange(existingItems.TrCasPaymentPoint);
                    acquisitionContext.TrCasReferences.RemoveRange(existingItems.TrCasReferences);
                    acquisitionContext.SaveChanges();

                    #endregion Remove All Data from Table TrInstallment, PaymentPoint, References

                    var trInstallments = new List<TrCasInstallment>();
                    for (int i = 0; i < trCasModels.Installments.monthly_other_installment_id.Length; i++)
                    {
                        trInstallments.Add(new TrCasInstallment
                        {
                            CreatedBy = existingItems.CreatedBy,
                            CreatedOn = existingItems.CreatedOn,
                            CreditId = trCasModels.credit_id,
                            LastUpdatedBy = trCasModels.last_updated_by,
                            LastUpdatedOn = trCasModels.last_updated_on,
                            MonthlyOtherInstallmentId = trCasModels.Installments.monthly_other_installment_id[i]
                        });
                    }

                    var trPaymentPoints = new List<TrCasPaymentPoint>();
                    for (int i = 0; i < trCasModels.PaymentPoints.payment_point_id.Length; i++)
                    {
                        trPaymentPoints.Add(new TrCasPaymentPoint
                        {
                            CreatedBy = existingItems.CreatedBy,
                            CreatedOn = existingItems.CreatedOn,
                            LastUpdatedBy = trCasModels.last_updated_by,
                            LastUpdatedOn = trCasModels.last_updated_on,
                            CreditId = existingItems.CreditId,
                            PaymentPointId = trCasModels.PaymentPoints.payment_point_id[i],
                            PaymentTypeId = trCasModels.PaymentPoints.payment_type_id[i]
                        });
                    }

                    var trCorporateDoc = new TrCasCorporateDocument();
                    if (trCasModels.customer_type == CustomerTypes.CORPORATE_TYPE_CODE)
                    {
                        trCorporateDoc = new TrCasCorporateDocument
                        {
                            CreditId = trCasModels.credit_id,
                            CorporateCommisionerName = trCasModels.CorporateDocuments.corporate_commisioner_name,
                            CorporateDirectorName = trCasModels.CorporateDocuments.corporate_director_name,
                            CorporateDebiturType = trCasModels.CorporateDocuments.corporate_debitur_type,
                            CorporateEmail = trCasModels.CorporateDocuments.corporate_email,
                            CorporateFaxNumber = trCasModels.CorporateDocuments.corporate_fax_number,
                            CorporateIndustryId = trCasModels.CorporateDocuments.corporate_industry_id,
                            CommissionerIdentityNumber = trCasModels.CorporateDocuments.commissioner_identity_number,
                            CompletenessLetterDueDate = trCasModels.CorporateDocuments.completeness_letter_due_date,
                            CompletenessLetterIssueDate = trCasModels.CorporateDocuments.completeness_letter_issue_date,
                            CorporateMonthPeriod = trCasModels.CorporateDocuments.corporate_month_period,
                            CorporateNumberOfEmployee = trCasModels.CorporateDocuments.corporate_number_of_employee,
                            CorporateOtherIndustry = trCasModels.CorporateDocuments.corporate_other_industry,
                            CorporateSite = trCasModels.CorporateDocuments.corporate_site,
                            CorporateStatus = trCasModels.CorporateDocuments.corporate_status,
                            CorporateTaxIdNumber = trCasModels.CorporateDocuments.corporate_tax_idNumber,
                            CorporateTelephoneNumber = trCasModels.CorporateDocuments.corporate_telephone_number,
                            CorporateYearPeriod = trCasModels.CorporateDocuments.corporate_year_period,
                            IsCompletenessLetter = trCasModels.CorporateDocuments.is_completeness_letter,
                            DirectorIdentityNumber = trCasModels.CorporateDocuments.director_identity_number,
                            DirectorTaxIdNumber = trCasModels.CorporateDocuments.director_tax_id_number,
                            FoundersDeedDate = trCasModels.CorporateDocuments.founders_deed_date,
                            FoundersDeedNumber = trCasModels.CorporateDocuments.founders_deed_number,
                            FoundersNotaryName = trCasModels.CorporateDocuments.founders_notary_name,
                            ManagementDeedDate = trCasModels.CorporateDocuments.management_deed_date,
                            ManagementDeedNumber = trCasModels.CorporateDocuments.management_deed_number,
                            ManagementNotaryName = trCasModels.CorporateDocuments.management_notary_name,
                            SiupDueDate = trCasModels.CorporateDocuments.siup_due_date,
                            SiupId = trCasModels.CorporateDocuments.siup_id,
                            SiupIssueDate = trCasModels.CorporateDocuments.siup_issue_date,
                            TdpId = trCasModels.CorporateDocuments.tdp_id,
                            TdpDueDate = trCasModels.CorporateDocuments.tdp_due_date,
                            TdpIssueDate = trCasModels.CorporateDocuments.siup_issue_date,
                            CreatedOn = existingItems.CreatedOn,
                            CreatedBy = existingItems.CreatedBy,
                            LastUpdatedBy = trCasModels.last_updated_by,
                            LastUpdatedOn = trCasModels.last_updated_on,
                        };
                        existingItems.TrCasCorporateDocument = trCorporateDoc; //replace existing data with new data
                    }

                    var dataReferences = MappingTrCasReferencesCollections(trCasModels, existingItems);

                    var dataApuppts = MappingTrCasApuppts(trCasModels, existingItems);

                    #region Assign all model collection into TrCas

                    existingItems.CreatedBy = existingItems.CreatedBy;
                    existingItems.CreatedOn = existingItems.CreatedOn;
                    existingItems.LastUpdatedBy = trCasModels.last_updated_by;
                    existingItems.LastUpdatedOn = trCasModels.last_updated_on;
                    existingItems.CreditId = trCasModels.credit_id;
                    existingItems.CompanyId = trCasModels.company_id;
                    existingItems.BranchId = trCasModels.branch_id;
                    existingItems.OutletCode = trCasModels.outlet_code;
                    existingItems.CreditSourceId = trCasModels.credit_source_id;
                    existingItems.OrderId = trCasModels.order_id;
                    existingItems.CustomerType = trCasModels.customer_type;
                    existingItems.IsRepeatOrder = trCasModels.is_repeat_order;
                    existingItems.IsInstantApproval = trCasModels.is_instant_approval;
                    existingItems.RepeatOrderReason = trCasModels.repeat_order_reason;
                    existingItems.CustomerName = trCasModels.customer_name; //dipake di C and P
                    existingItems.BirthPlace = trCasModels.birth_place; //dipake di C and P
                    existingItems.BirthDate = trCasModels.birth_date; //dipake di C and P
                    existingItems.Gender = trCasModels.gender;
                    existingItems.MotherName = trCasModels.mother_name;
                    existingItems.Email = trCasModels.email;
                    existingItems.IdentityTypeId = trCasModels.identity_type_id;
                    existingItems.IdentityNumber = trCasModels.identity_number;
                    existingItems.ValidThru = trCasModels.valid_thru;
                    existingItems.IssueDate = trCasModels.issue_date;
                    existingItems.IdentityAddress = trCasModels.identity_address;
                    existingItems.IdentityLocationId = trCasModels.identity_location_id;
                    existingItems.IsBlacklist = trCasModels.is_blacklist;
                    existingItems.CustomerAddress = trCasModels.customer_address;
                    existingItems.CustomerLocationId = trCasModels.customer_location_id;
                    existingItems.NpwpNo = trCasModels.npwp_no;
                    existingItems.TelephoneNumber = trCasModels.telephone_number;
                    existingItems.MobilePhone = trCasModels.mobile_phone;
                    existingItems.ResidenceDistance = trCasModels.residence_distance;
                    existingItems.CustomerSourceId = trCasModels.customer_source_id;
                    existingItems.IsSurveyed = trCasModels.is_surveyed;
                    existingItems.SourcesId = trCasModels.sources_id;
                    existingItems.SourcesName = trCasModels.sources_name;
                    existingItems.SourcesAddress = trCasModels.sources_address;
                    existingItems.EvaluationId = trCasModels.evaluation_id;
                    existingItems.ResidenceStatusId = trCasModels.residence_status_id;
                    existingItems.OwnershipProof = trCasModels.ownership_proof;
                    existingItems.OwnershipProofName = trCasModels.ownership_proof_name;
                    existingItems.ResidenceCondition = trCasModels.residence_condition;
                    existingItems.MaritalStatus = trCasModels.marital_status;
                    existingItems.MailToSourceId = trCasModels.mail_to_source_id;
                    existingItems.MailToAddress = trCasModels.mail_to_address;
                    existingItems.MailToLocationId = trCasModels.mail_to_location_id;
                    existingItems.MailToTelephoneNumber = trCasModels.mail_to_telephone_number;
                    existingItems.CreditSourceStatus = trCasModels.credit_source_status;
                    existingItems.Analysis = trCasModels.analysis;
                    existingItems.Conclusion = trCasModels.conclusion;
                    existingItems.IsApuppt = trCasModels.is_apuppt == null ? 0 : trCasModels.is_apuppt;

                    existingItems.TrCasReferences = dataReferences;
                    existingItems.TrCasCorporateDocument = trCasModels.customer_type == CustomerTypes.CORPORATE_TYPE_CODE ? trCorporateDoc : null;

                    existingItems.TrCasFinancial.CreditId = existingItems.CreditId;
                    existingItems.TrCasFinancial.EducationExpenses = trCasModels.Financials.education_expenses;
                    existingItems.TrCasFinancial.HealthExpenses = trCasModels.Financials.health_expenses;
                    existingItems.TrCasFinancial.HouseholdExpenses = trCasModels.Financials.household_expenses;
                    existingItems.TrCasFinancial.IndustryTypeId = trCasModels.Financials.industry_type_id;
                    existingItems.TrCasFinancial.CommodityType = trCasModels.Financials.commodity_type;
                    existingItems.TrCasFinancial.NumberOfDependents = trCasModels.Financials.number_of_dependents;
                    existingItems.TrCasFinancial.ProfessionId = trCasModels.Financials.profession_id;
                    existingItems.TrCasFinancial.PrimaryIncome = trCasModels.Financials.primary_income;
                    existingItems.TrCasFinancial.OtherIncome = trCasModels.Financials.other_income;
                    existingItems.TrCasFinancial.OtherIncomeDesc = trCasModels.Financials.other_income_desc;
                    existingItems.TrCasFinancial.Position = trCasModels.Financials.position;
                    existingItems.TrCasFinancial.OfficeLocationId = trCasModels.Financials.office_location_id;
                    existingItems.TrCasFinancial.OfficeName = trCasModels.Financials.office_name;
                    existingItems.TrCasFinancial.OfficeTelephoneNumber = trCasModels.Financials.office_telephone_number;
                    existingItems.TrCasFinancial.OfficeFax = trCasModels.Financials.office_fax;
                    existingItems.TrCasFinancial.OfficeAddress = trCasModels.Financials.office_address;
                    existingItems.TrCasFinancial.YearsOfWorkExperience = trCasModels.Financials.years_of_work_experience;
                    existingItems.TrCasFinancial.MonthlyOtherInstallment = trCasModels.Financials.monthly_other_installment;
                    existingItems.TrCasFinancial.CreatedBy = existingItems.CreatedBy;
                    existingItems.TrCasFinancial.CreatedOn = existingItems.CreatedOn;
                    existingItems.TrCasFinancial.LastUpdatedBy = trCasModels.last_updated_by;
                    existingItems.TrCasFinancial.LastUpdatedOn = trCasModels.last_updated_on;

                    if (existingItems.TrCasRepeatOrder != null)
                    {
                        existingItems.TrCasRepeatOrder.CreditId = trCasModels.credit_id;
                        existingItems.TrCasRepeatOrder.BankId = trCasModels.RepeatOrders.bank_id;
                        existingItems.TrCasRepeatOrder.AccountName = trCasModels.RepeatOrders.account_name;
                        existingItems.TrCasRepeatOrder.AccountNumber = trCasModels.RepeatOrders.account_number;
                        existingItems.TrCasRepeatOrder.AgreementNumberOld = "";
                        existingItems.TrCasRepeatOrder.RepeatOrderApplicantRelationId = trCasModels.RepeatOrders.repeat_order_applicant_relation_id;
                        existingItems.TrCasRepeatOrder.RepeatOrderReferenceSourceId = trCasModels.RepeatOrders.repeat_order_reference_source_id;
                        existingItems.TrCasRepeatOrder.RepeatOrderCategoryId = trCasModels.RepeatOrders.repeat_order_category_id;
                        existingItems.TrCasRepeatOrder.RepeatOrderDecisionId = trCasModels.RepeatOrders.repeat_order_decision_id;
                        existingItems.TrCasRepeatOrder.RepeatOrderDescription = trCasModels.RepeatOrders.repeat_order_description;
                        existingItems.TrCasRepeatOrder.TelephoneNumber = trCasModels.RepeatOrders.telephone_number;
                        existingItems.TrCasRepeatOrder.CreatedBy = existingItems.CreatedBy;
                        existingItems.TrCasRepeatOrder.CreatedOn = existingItems.CreatedOn;
                        existingItems.TrCasRepeatOrder.LastUpdatedOn = trCasModels.last_updated_on;
                        existingItems.TrCasRepeatOrder.LastUpdatedBy = trCasModels.last_updated_by;
                        if (trCasModels.RepeatOrders.repeat_order_reference_source_id == "2" || trCasModels.RepeatOrders.repeat_order_reference_source_id == "6")
                        {
                            existingItems.TrCasRepeatOrder.ReferenceSourceDesc = trCasModels.RepeatOrders.reference_source_desc is null ? String.Empty : trCasModels.RepeatOrders.reference_source_desc;
                        }
                    }

                    existingItems.TrCasInstallment = trInstallments;
                    existingItems.TrCasPaymentPoint = trPaymentPoints;
                    existingItems.TrCasApuppt = dataApuppts;

                    #endregion Assign all model collection into TrCas

                    #region Recreate removed data TrInstallment, PaymentPoint, References

                    acquisitionContext.TrCasInstallment.AddRangeAsync(trInstallments);
                    acquisitionContext.TrCasPaymentPoint.AddRangeAsync(trPaymentPoints);
                    acquisitionContext.TrCasReferences.AddRangeAsync(dataReferences);

                    #endregion Recreate removed data TrInstallment, PaymentPoint, References

                    await acquisitionContext.SaveChangesAsync();

                    transaction.CommitAsync();
                    return new APIResponse(Collection.Codes.SUCCESS,
                            Collection.Status.SUCCESS,
                            $"{Collection.Messages.UPDATED} Credit Id: {trCasModels.credit_id}",
                            null);
                }
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.FORBIDDEN,
                         Collection.Status.FAILED,
                         $"{ex.Message}. {ex.InnerException}. {Collection.Messages.TRANSACTION_ROLLBACK}",
                         Collection.Messages.TRANSACTION_ROLLBACK);
            }
        }

        public async Task<APIResponse> InsertTrCasMotorAsync(TrCasModels trCasModels)
        {
            try
            {
                #region Mapping collections model item value from FE

                trCasModels.credit_id = trCasModels.credit_id;
                trCasModels.created_on = DateTime.Now;
                var trInstallments = new List<TrCasInstallment>();
                for (int i = 0; i < trCasModels.Installments.monthly_other_installment_id.Length; i++)
                {
                    trInstallments.Add(new TrCasInstallment
                    {
                        CreatedBy = trCasModels.created_by,
                        CreatedOn = trCasModels.created_on,
                        CreditId = trCasModels.credit_id,
                        LastUpdatedBy = trCasModels.last_updated_by,
                        LastUpdatedOn = trCasModels.last_updated_on,
                        MonthlyOtherInstallmentId = trCasModels.Installments.monthly_other_installment_id[i]
                    });
                }
                var trPaymentPoints = new List<TrCasPaymentPoint>();
                for (int i = 0; i < trCasModels.PaymentPoints.payment_point_id.Length; i++)
                {
                    trPaymentPoints.Add(new TrCasPaymentPoint
                    {
                        CreatedBy = trCasModels.created_by,
                        CreatedOn = trCasModels.created_on,
                        LastUpdatedBy = "",
                        LastUpdatedOn = null,
                        CreditId = trCasModels.credit_id,
                        PaymentPointId = trCasModels.PaymentPoints.payment_point_id[i],
                        PaymentTypeId = trCasModels.PaymentPoints.payment_type_id[i]
                    });
                }
                var trCorporateDoc = new TrCasCorporateDocument();
                if (trCasModels.customer_type == CustomerTypes.CORPORATE_TYPE_CODE)
                {
                    trCorporateDoc = new TrCasCorporateDocument
                    {
                        CreditId = trCasModels.credit_id,
                        CorporateCommisionerName = trCasModels.CorporateDocuments.corporate_commisioner_name,
                        CorporateDirectorName = trCasModels.CorporateDocuments.corporate_director_name,
                        CorporateDebiturType = trCasModels.CorporateDocuments.corporate_debitur_type,
                        CorporateEmail = trCasModels.CorporateDocuments.corporate_email,
                        CorporateFaxNumber = trCasModels.CorporateDocuments.corporate_fax_number,
                        CorporateIndustryId = trCasModels.CorporateDocuments.corporate_industry_id,
                        CommissionerIdentityNumber = trCasModels.CorporateDocuments.commissioner_identity_number,
                        CompletenessLetterDueDate = trCasModels.CorporateDocuments.completeness_letter_due_date,
                        CompletenessLetterIssueDate = trCasModels.CorporateDocuments.completeness_letter_issue_date,
                        CorporateMonthPeriod = trCasModels.CorporateDocuments.corporate_month_period,
                        CorporateNumberOfEmployee = trCasModels.CorporateDocuments.corporate_number_of_employee,
                        CorporateOtherIndustry = trCasModels.CorporateDocuments.corporate_other_industry,
                        CorporateSite = trCasModels.CorporateDocuments.corporate_site,
                        CorporateStatus = trCasModels.CorporateDocuments.corporate_status,
                        CorporateTaxIdNumber = trCasModels.CorporateDocuments.corporate_tax_idNumber,
                        CorporateTelephoneNumber = trCasModels.CorporateDocuments.corporate_telephone_number,
                        CorporateYearPeriod = trCasModels.CorporateDocuments.corporate_year_period,
                        IsCompletenessLetter = trCasModels.CorporateDocuments.is_completeness_letter,
                        DirectorIdentityNumber = trCasModels.CorporateDocuments.director_identity_number,
                        DirectorTaxIdNumber = trCasModels.CorporateDocuments.director_tax_id_number,
                        FoundersDeedDate = trCasModels.CorporateDocuments.founders_deed_date,
                        FoundersDeedNumber = trCasModels.CorporateDocuments.founders_deed_number,
                        FoundersNotaryName = trCasModels.CorporateDocuments.founders_notary_name,
                        ManagementDeedDate = trCasModels.CorporateDocuments.management_deed_date,
                        ManagementDeedNumber = trCasModels.CorporateDocuments.management_deed_number,
                        ManagementNotaryName = trCasModels.CorporateDocuments.management_notary_name,
                        SiupDueDate = trCasModels.CorporateDocuments.siup_due_date,
                        SiupId = trCasModels.CorporateDocuments.siup_id,
                        SiupIssueDate = trCasModels.CorporateDocuments.siup_issue_date,
                        TdpId = trCasModels.CorporateDocuments.tdp_id,
                        TdpDueDate = trCasModels.CorporateDocuments.tdp_due_date,
                        TdpIssueDate = trCasModels.CorporateDocuments.siup_issue_date,
                        CreatedOn = trCasModels.created_on,
                        CreatedBy = trCasModels.created_by,
                        LastUpdatedBy = "",
                        LastUpdatedOn = trCasModels.last_updated_on,
                    };
                }

                var dataReferences = MappingTrCasReferencesCollections(trCasModels, null);
                var dataApuppts = MappingTrCasApuppts(trCasModels, null);
                var dataRo = MappingTrCasRepeatOrder(trCasModels);

                #endregion Mapping collections model item value from FE

                #region Assign all model collection into TrCas

                var trCas = new TrCas
                {
                    CreatedBy = trCasModels.created_by,
                    CreatedOn = trCasModels.created_on,
                    CreditId = trCasModels.credit_id,
                    BranchId = trCasModels.branch_id,
                    OutletCode = trCasModels.outlet_code,
                    CreditSourceId = trCasModels.credit_source_id,
                    OrderId = trCasModels.order_id,
                    CompanyId = trCasModels.company_id,
                    CustomerType = trCasModels.customer_type,
                    IsRepeatOrder = trCasModels.is_repeat_order,
                    IsInstantApproval = trCasModels.is_instant_approval,
                    RepeatOrderReason = trCasModels.repeat_order_reason,
                    CustomerName = trCasModels.customer_name, //dipake di C and P
                    BirthPlace = trCasModels.birth_place, //dipake di C and P
                    BirthDate = trCasModels.birth_date, //dipake di C and P
                    Gender = trCasModels.gender,
                    MotherName = trCasModels.mother_name,
                    Email = trCasModels.email,
                    IdentityTypeId = trCasModels.identity_type_id,
                    IdentityNumber = trCasModels.identity_number,
                    ValidThru = trCasModels.valid_thru,
                    IssueDate = trCasModels.issue_date,
                    IdentityAddress = trCasModels.identity_address,
                    IdentityLocationId = trCasModels.identity_location_id,
                    IsBlacklist = trCasModels.is_blacklist,
                    CustomerAddress = trCasModels.customer_address,
                    CustomerLocationId = trCasModels.customer_location_id,
                    NpwpNo = trCasModels.npwp_no,
                    TelephoneNumber = trCasModels.telephone_number,
                    MobilePhone = trCasModels.mobile_phone,
                    ResidenceDistance = trCasModels.residence_distance,
                    CustomerSourceId = trCasModels.customer_source_id,
                    IsSurveyed = trCasModels.is_surveyed,
                    SourcesId = trCasModels.sources_id,
                    SourcesName = trCasModels.sources_name,
                    SourcesAddress = trCasModels.sources_address,
                    EvaluationId = trCasModels.evaluation_id,
                    ResidenceStatusId = trCasModels.residence_status_id.ToString(),
                    OwnershipProof = trCasModels.ownership_proof,
                    OwnershipProofName = trCasModels.ownership_proof_name,
                    ResidenceCondition = trCasModels.residence_condition,
                    MaritalStatus = Convert.ToInt32(trCasModels.marital_status),
                    MailToSourceId = trCasModels.mail_to_source_id,
                    MailToAddress = trCasModels.mail_to_address,
                    MailToLocationId = trCasModels.mail_to_location_id,
                    MailToTelephoneNumber = trCasModels.mail_to_telephone_number,
                    CreditSourceStatus = trCasModels.credit_source_status,
                    Analysis = trCasModels.analysis,
                    Conclusion = trCasModels.conclusion,
                    IsApuppt = trCasModels.is_apuppt == null ? 0 : trCasModels.is_apuppt,
                    TrCasReferences = dataReferences.Count == 0 ? null : dataReferences,
                    TrCasCorporateDocument = trCasModels.customer_type == CustomerTypes.CORPORATE_TYPE_CODE ? trCorporateDoc : null,
                    TrCasFinancial = new TrCasFinancial
                    {
                        CreatedBy = trCasModels.created_by,
                        CreditId = trCasModels.credit_id,
                        EducationExpenses = trCasModels.Financials.education_expenses,
                        HealthExpenses = trCasModels.Financials.health_expenses,
                        HouseholdExpenses = trCasModels.Financials.household_expenses,
                        IndustryTypeId = trCasModels.Financials.industry_type_id,
                        CommodityType = trCasModels.Financials.commodity_type,
                        NumberOfDependents = trCasModels.Financials.number_of_dependents,
                        ProfessionId = trCasModels.Financials.profession_id.ToString(),
                        PrimaryIncome = trCasModels.Financials.primary_income,
                        OtherIncome = trCasModels.Financials.other_income,
                        OtherIncomeDesc = trCasModels.Financials.other_income_desc,
                        Position = trCasModels.Financials.position,
                        OfficeLocationId = trCasModels.Financials.office_location_id,
                        OfficeName = trCasModels.Financials.office_name,
                        OfficeTelephoneNumber = trCasModels.Financials.office_telephone_number,
                        OfficeFax = trCasModels.Financials.office_fax,
                        OfficeAddress = trCasModels.Financials.office_address,
                        YearsOfWorkExperience = trCasModels.Financials.years_of_work_experience,
                        MonthlyOtherInstallment = trCasModels.Financials.monthly_other_installment,
                        CreatedOn = trCasModels.created_on,
                        LastUpdatedBy = "",
                        LastUpdatedOn = trCasModels.last_updated_on
                    },
                    TrCasRepeatOrder = trCasModels.is_repeat_order is true ? dataRo : null,
                    TrCasInstallment = trInstallments,
                    TrCasPaymentPoint = trPaymentPoints,
                    TrCasApuppt = dataApuppts
                };
                await acquisitionContext.TrCas.AddAsync(trCas);

                #endregion Assign all model collection into TrCas

                //commit transaction
                await acquisitionContext.SaveChangesAsync();

                //insert history Generated CreditId
                await InsertGenerateCodeHistoryAsync(new TrGenerateCodeHistory
                {
                    BranchId = trCasModels.branch_id,
                    CodeType = CodeType.TR_CAS,
                    CodeOutput = trCasModels.credit_id,
                    EmployeeId = trCasModels.created_by,
                    StatusTransaction = Collection.Status.SUCCESS
                });

                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        $"{Collection.Messages.CREATED}. Credit Id: {trCasModels.credit_id}",
                        null);
            }
            catch (Exception ex)
            {
                //insert history Generated CreditId
                await InsertGenerateCodeHistoryAsync(new TrGenerateCodeHistory
                {
                    BranchId = trCasModels.branch_id,
                    CodeType = CodeType.TR_CAS,
                    CodeOutput = trCasModels.credit_id,
                    EmployeeId = trCasModels.created_by,
                    StatusTransaction = Collection.Status.FAILED
                });

                return new APIResponse(Collection.Codes.FORBIDDEN,
                         Collection.Status.FAILED,
                         $"{ex.Message}. {ex.InnerException}. {Collection.Messages.TRANSACTION_ROLLBACK}",
                         Collection.Messages.TRANSACTION_ROLLBACK);
            }
        }

        public async Task<APIResponse> UpdateTrCasMotorAsync(TrCasModels trCasModels)
        {
            try
            {
                using (var transaction = acquisitionContext.Database.BeginTransaction())
                {
                    var existingItems = GetDeserializeTrCasData(trCasModels.credit_id).Result; //Get existing data

                    #region Remove All Data from Table

                    acquisitionContext.TrCasInstallment.RemoveRange(existingItems.TrCasInstallment); //remove existing data trInstallments
                    acquisitionContext.TrCasPaymentPoint.RemoveRange(existingItems.TrCasPaymentPoint);
                    acquisitionContext.TrCasReferences.RemoveRange(existingItems.TrCasReferences);
                    acquisitionContext.SaveChanges();

                    #endregion Remove All Data from Table

                    var trInstallments = new List<TrCasInstallment>();
                    for (int i = 0; i < trCasModels.Installments.monthly_other_installment_id.Length; i++)
                    {
                        trInstallments.Add(new TrCasInstallment
                        {
                            CreatedBy = existingItems.CreatedBy,
                            CreatedOn = existingItems.CreatedOn,
                            CreditId = trCasModels.credit_id,
                            LastUpdatedBy = trCasModels.last_updated_by,
                            LastUpdatedOn = trCasModels.last_updated_on,
                            MonthlyOtherInstallmentId = trCasModels.Installments.monthly_other_installment_id[i]
                        });
                    }

                    var trPaymentPoints = new List<TrCasPaymentPoint>();
                    for (int i = 0; i < trCasModels.PaymentPoints.payment_point_id.Length; i++)
                    {
                        trPaymentPoints.Add(new TrCasPaymentPoint
                        {
                            CreatedBy = existingItems.CreatedBy,
                            CreatedOn = existingItems.CreatedOn,
                            LastUpdatedBy = trCasModels.last_updated_by,
                            LastUpdatedOn = trCasModels.last_updated_on,
                            CreditId = existingItems.CreditId,
                            PaymentPointId = trCasModels.PaymentPoints.payment_point_id[i],
                            PaymentTypeId = trCasModels.PaymentPoints.payment_type_id[i]
                        });
                    }

                    var trCorporateDoc = new TrCasCorporateDocument();
                    if (trCasModels.customer_type == CustomerTypes.CORPORATE_TYPE_CODE)
                    {
                        trCorporateDoc = new TrCasCorporateDocument
                        {
                            CreditId = trCasModels.credit_id,
                            CorporateCommisionerName = trCasModels.CorporateDocuments.corporate_commisioner_name,
                            CorporateDirectorName = trCasModels.CorporateDocuments.corporate_director_name,
                            CorporateDebiturType = trCasModels.CorporateDocuments.corporate_debitur_type,
                            CorporateEmail = trCasModels.CorporateDocuments.corporate_email,
                            CorporateFaxNumber = trCasModels.CorporateDocuments.corporate_fax_number,
                            CorporateIndustryId = trCasModels.CorporateDocuments.corporate_industry_id,
                            CommissionerIdentityNumber = trCasModels.CorporateDocuments.commissioner_identity_number,
                            CompletenessLetterDueDate = trCasModels.CorporateDocuments.completeness_letter_due_date,
                            CompletenessLetterIssueDate = trCasModels.CorporateDocuments.completeness_letter_issue_date,
                            CorporateMonthPeriod = trCasModels.CorporateDocuments.corporate_month_period,
                            CorporateNumberOfEmployee = trCasModels.CorporateDocuments.corporate_number_of_employee,
                            CorporateOtherIndustry = trCasModels.CorporateDocuments.corporate_other_industry,
                            CorporateSite = trCasModels.CorporateDocuments.corporate_site,
                            CorporateStatus = trCasModels.CorporateDocuments.corporate_status,
                            CorporateTaxIdNumber = trCasModels.CorporateDocuments.corporate_tax_idNumber,
                            CorporateTelephoneNumber = trCasModels.CorporateDocuments.corporate_telephone_number,
                            CorporateYearPeriod = trCasModels.CorporateDocuments.corporate_year_period,
                            IsCompletenessLetter = trCasModels.CorporateDocuments.is_completeness_letter,
                            DirectorIdentityNumber = trCasModels.CorporateDocuments.director_identity_number,
                            DirectorTaxIdNumber = trCasModels.CorporateDocuments.director_tax_id_number,
                            FoundersDeedDate = trCasModels.CorporateDocuments.founders_deed_date,
                            FoundersDeedNumber = trCasModels.CorporateDocuments.founders_deed_number,
                            FoundersNotaryName = trCasModels.CorporateDocuments.founders_notary_name,
                            ManagementDeedDate = trCasModels.CorporateDocuments.management_deed_date,
                            ManagementDeedNumber = trCasModels.CorporateDocuments.management_deed_number,
                            ManagementNotaryName = trCasModels.CorporateDocuments.management_notary_name,
                            SiupDueDate = trCasModels.CorporateDocuments.siup_due_date,
                            SiupId = trCasModels.CorporateDocuments.siup_id,
                            SiupIssueDate = trCasModels.CorporateDocuments.siup_issue_date,
                            TdpId = trCasModels.CorporateDocuments.tdp_id,
                            TdpDueDate = trCasModels.CorporateDocuments.tdp_due_date,
                            TdpIssueDate = trCasModels.CorporateDocuments.siup_issue_date,
                            CreatedOn = existingItems.CreatedOn,
                            CreatedBy = existingItems.CreatedBy,
                            LastUpdatedBy = trCasModels.last_updated_by,
                            LastUpdatedOn = trCasModels.last_updated_on,
                        };
                        existingItems.TrCasCorporateDocument = trCorporateDoc; //replace existing data with new data
                    }

                    var dataReferences = MappingTrCasReferencesCollections(trCasModels, existingItems);

                    var dataApuppts = MappingTrCasApuppts(trCasModels, existingItems);

                    #region Assign all model collection into TrCas

                    existingItems.CreatedBy = existingItems.CreatedBy;
                    existingItems.CreatedOn = existingItems.CreatedOn;
                    existingItems.LastUpdatedBy = trCasModels.last_updated_by;
                    existingItems.LastUpdatedOn = trCasModels.last_updated_on;
                    existingItems.CreditId = trCasModels.credit_id;
                    existingItems.CompanyId = trCasModels.company_id;
                    existingItems.BranchId = trCasModels.branch_id;
                    existingItems.OutletCode = trCasModels.outlet_code;
                    existingItems.CreditSourceId = trCasModels.credit_source_id;
                    existingItems.OrderId = trCasModels.order_id;
                    existingItems.CustomerType = trCasModels.customer_type;
                    existingItems.IsRepeatOrder = trCasModels.is_repeat_order;
                    existingItems.IsInstantApproval = trCasModels.is_instant_approval;
                    existingItems.RepeatOrderReason = trCasModels.repeat_order_reason;
                    existingItems.CustomerName = trCasModels.customer_name; //dipake di C and P
                    existingItems.BirthPlace = trCasModels.birth_place; //dipake di C and P
                    existingItems.BirthDate = trCasModels.birth_date; //dipake di C and P
                    existingItems.Gender = trCasModels.gender;
                    existingItems.MotherName = trCasModels.mother_name;
                    existingItems.Email = trCasModels.email;
                    existingItems.IdentityTypeId = trCasModels.identity_type_id;
                    existingItems.IdentityNumber = trCasModels.identity_number;
                    existingItems.ValidThru = trCasModels.valid_thru;
                    existingItems.IssueDate = trCasModels.issue_date;
                    existingItems.IdentityAddress = trCasModels.identity_address;
                    existingItems.IdentityLocationId = trCasModels.identity_location_id;
                    existingItems.IsBlacklist = trCasModels.is_blacklist;
                    existingItems.CustomerAddress = trCasModels.customer_address;
                    existingItems.CustomerLocationId = trCasModels.customer_location_id;
                    existingItems.NpwpNo = trCasModels.npwp_no;
                    existingItems.TelephoneNumber = trCasModels.telephone_number;
                    existingItems.MobilePhone = trCasModels.mobile_phone;
                    existingItems.ResidenceDistance = trCasModels.residence_distance;
                    existingItems.CustomerSourceId = trCasModels.customer_source_id;
                    existingItems.IsSurveyed = trCasModels.is_surveyed;
                    existingItems.SourcesId = trCasModels.sources_id;
                    existingItems.SourcesName = trCasModels.sources_name;
                    existingItems.SourcesAddress = trCasModels.sources_address;
                    existingItems.EvaluationId = trCasModels.evaluation_id;
                    existingItems.ResidenceStatusId = trCasModels.residence_status_id;
                    existingItems.OwnershipProof = trCasModels.ownership_proof;
                    existingItems.OwnershipProofName = trCasModels.ownership_proof_name;
                    existingItems.ResidenceCondition = trCasModels.residence_condition;
                    existingItems.MaritalStatus = trCasModels.marital_status;
                    existingItems.MailToSourceId = trCasModels.mail_to_source_id;
                    existingItems.MailToAddress = trCasModels.mail_to_address;
                    existingItems.MailToLocationId = trCasModels.mail_to_location_id;
                    existingItems.MailToTelephoneNumber = trCasModels.mail_to_telephone_number;
                    existingItems.CreditSourceStatus = trCasModels.credit_source_status;
                    existingItems.Analysis = trCasModels.analysis;
                    existingItems.Conclusion = trCasModels.conclusion;
                    existingItems.IsApuppt = trCasModels.is_apuppt == null ? 0 : trCasModels.is_apuppt;

                    existingItems.TrCasReferences = dataReferences;
                    existingItems.TrCasCorporateDocument = trCasModels.customer_type == CustomerTypes.CORPORATE_TYPE_CODE ? trCorporateDoc : null;

                    existingItems.TrCasFinancial.CreditId = existingItems.CreditId;
                    existingItems.TrCasFinancial.EducationExpenses = trCasModels.Financials.education_expenses;
                    existingItems.TrCasFinancial.HealthExpenses = trCasModels.Financials.health_expenses;
                    existingItems.TrCasFinancial.HouseholdExpenses = trCasModels.Financials.household_expenses;
                    existingItems.TrCasFinancial.IndustryTypeId = trCasModels.Financials.industry_type_id;
                    existingItems.TrCasFinancial.CommodityType = trCasModels.Financials.commodity_type;
                    existingItems.TrCasFinancial.NumberOfDependents = trCasModels.Financials.number_of_dependents;
                    existingItems.TrCasFinancial.ProfessionId = trCasModels.Financials.profession_id;
                    existingItems.TrCasFinancial.PrimaryIncome = trCasModels.Financials.primary_income;
                    existingItems.TrCasFinancial.OtherIncome = trCasModels.Financials.other_income;
                    existingItems.TrCasFinancial.OtherIncomeDesc = trCasModels.Financials.other_income_desc;
                    existingItems.TrCasFinancial.Position = trCasModels.Financials.position;
                    existingItems.TrCasFinancial.OfficeLocationId = trCasModels.Financials.office_location_id;
                    existingItems.TrCasFinancial.OfficeName = trCasModels.Financials.office_name;
                    existingItems.TrCasFinancial.OfficeTelephoneNumber = trCasModels.Financials.office_telephone_number;
                    existingItems.TrCasFinancial.OfficeFax = trCasModels.Financials.office_fax;
                    existingItems.TrCasFinancial.OfficeAddress = trCasModels.Financials.office_address;
                    existingItems.TrCasFinancial.YearsOfWorkExperience = trCasModels.Financials.years_of_work_experience;
                    existingItems.TrCasFinancial.MonthlyOtherInstallment = trCasModels.Financials.monthly_other_installment;
                    existingItems.TrCasFinancial.CreatedBy = existingItems.CreatedBy;
                    existingItems.TrCasFinancial.CreatedOn = existingItems.CreatedOn;
                    existingItems.TrCasFinancial.LastUpdatedBy = trCasModels.last_updated_by;
                    existingItems.TrCasFinancial.LastUpdatedOn = trCasModels.last_updated_on;

                    if (existingItems.TrCasRepeatOrder != null)
                    {
                        existingItems.TrCasRepeatOrder.CreditId = trCasModels.credit_id;
                        existingItems.TrCasRepeatOrder.BankId = trCasModels.RepeatOrders.bank_id;
                        existingItems.TrCasRepeatOrder.AccountName = trCasModels.RepeatOrders.account_name;
                        existingItems.TrCasRepeatOrder.AccountNumber = trCasModels.RepeatOrders.account_number;
                        existingItems.TrCasRepeatOrder.AgreementNumberOld = "";
                        existingItems.TrCasRepeatOrder.RepeatOrderApplicantRelationId = trCasModels.RepeatOrders.repeat_order_applicant_relation_id;
                        existingItems.TrCasRepeatOrder.RepeatOrderReferenceSourceId = trCasModels.RepeatOrders.repeat_order_reference_source_id;
                        existingItems.TrCasRepeatOrder.RepeatOrderCategoryId = trCasModels.RepeatOrders.repeat_order_category_id;
                        existingItems.TrCasRepeatOrder.RepeatOrderDecisionId = trCasModels.RepeatOrders.repeat_order_decision_id;
                        existingItems.TrCasRepeatOrder.RepeatOrderDescription = trCasModels.RepeatOrders.repeat_order_description;
                        existingItems.TrCasRepeatOrder.TelephoneNumber = trCasModels.RepeatOrders.telephone_number;
                        existingItems.TrCasRepeatOrder.CreatedBy = existingItems.CreatedBy;
                        existingItems.TrCasRepeatOrder.CreatedOn = existingItems.CreatedOn;
                        existingItems.TrCasRepeatOrder.LastUpdatedOn = trCasModels.last_updated_on;
                        existingItems.TrCasRepeatOrder.LastUpdatedBy = trCasModels.last_updated_by;
                        if (trCasModels.RepeatOrders.repeat_order_reference_source_id == "2" || trCasModels.RepeatOrders.repeat_order_reference_source_id == "6")
                        {
                            existingItems.TrCasRepeatOrder.ReferenceSourceDesc = trCasModels.RepeatOrders.reference_source_desc is null ? String.Empty : trCasModels.RepeatOrders.reference_source_desc;
                        }
                    }

                    existingItems.TrCasInstallment = trInstallments;
                    existingItems.TrCasPaymentPoint = trPaymentPoints;
                    existingItems.TrCasApuppt = dataApuppts;

                    #endregion Assign all model collection into TrCas

                    #region Recreate removed data

                    acquisitionContext.TrCasInstallment.AddRangeAsync(trInstallments);
                    acquisitionContext.TrCasPaymentPoint.AddRangeAsync(trPaymentPoints);
                    acquisitionContext.TrCasReferences.AddRangeAsync(dataReferences);

                    #endregion Recreate removed data

                    await acquisitionContext.SaveChangesAsync();

                    transaction.CommitAsync();
                    return new APIResponse(Collection.Codes.SUCCESS,
                            Collection.Status.SUCCESS,
                            $"{Collection.Messages.UPDATED} Credit Id: {trCasModels.credit_id}",
                            null);
                }
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.FORBIDDEN,
                         Collection.Status.FAILED,
                         $"{ex.Message}. {ex.InnerException}. {Collection.Messages.TRANSACTION_ROLLBACK}",
                         Collection.Messages.TRANSACTION_ROLLBACK);
            }
        }

        public Task<APIResponse> RecreateTrInstallmentsAsync(TrCasModels creditsModels)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> InsertGenerateCodeHistoryAsync(TrGenerateCodeHistory codeHistory)
        {
            try
            {
                var data = await acquisitionContext
                    .GetProcedures().sp_insert_generate_code_historyAsync(codeHistory.CodeType
                                        , codeHistory.EmployeeId
                                        , codeHistory.BranchId
                                        , codeHistory.CodeOutput
                                        , codeHistory.StatusTransaction);
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message);
            }
        }

        public async Task<APIResponse> GetTrCasByCreditId(string creditId)
        {
            try
            {
                //get data TrCas by CreditId with his table relationship references
                var casDataCollections = await acquisitionContext.TrCas
                        .Include(x => x.TrCasRepeatOrder)
                        .Include(x => x.TrCasFinancial)
                        .Include(x => x.TrCasApuppt)
                        .Include(x => x.TrCasReferences)
                        .Include(x => x.TrCasCorporateDocument)
                        .Include(x => x.TrCasPaymentPoint)
                        .Include(x => x.TrCasInstallment)
                        .Where(m => m.CreditId.Equals(creditId))
                        .ToListAsync();

                var casModels = new List<TrCasModels>();
                if (casDataCollections.Count > 0)
                {
                    foreach (var dataCas in casDataCollections)
                    {
                        #region Mapping TrCasInstallments

                        var dataInstallments = new TrCasInstallmentModels();
                        if (dataCas.TrCasInstallment.Count > 0)
                        {
                            var arrMonthlyInstallmentId = new List<string>();
                            foreach (var installmentIds in dataCas.TrCasInstallment)
                            {
                                dataInstallments.credit_id = dataCas.CreditId;
                                dataInstallments.created_by = dataCas.CreatedBy;
                                dataInstallments.created_on = dataCas.CreatedOn;
                                dataInstallments.last_updated_by = installmentIds.LastUpdatedBy;
                                dataInstallments.last_updated_on = installmentIds.LastUpdatedOn == null ? Commons.GetDefaultDatetime() : installmentIds.LastUpdatedOn;
                                arrMonthlyInstallmentId.Add(installmentIds.MonthlyOtherInstallmentId);

                                dataInstallments.monthly_other_installment_id = arrMonthlyInstallmentId.ToArray();
                            }
                        }

                        #endregion Mapping TrCasInstallments

                        #region Mapping TrCasPaymentPoint

                        var paymentPoints = new TrCasPaymentPointModels();
                        var paymentLocationPlanList = new List<PaymentLocationPlansModels>();
                        var arrPaymentPointId = new List<int>();
                        var arrPaymentPointTypeId = new List<int>();
                        foreach (var itemPaymentPoin in dataCas.TrCasPaymentPoint)
                        {
                            paymentPoints.credit_id = itemPaymentPoin.CreditId;
                            paymentPoints.created_by = itemPaymentPoin.CreatedBy;
                            paymentPoints.created_on = itemPaymentPoin.CreatedOn;
                            paymentPoints.last_updated_by = itemPaymentPoin.LastUpdatedBy;
                            paymentPoints.last_updated_on = itemPaymentPoin.LastUpdatedOn == null ? Commons.GetDefaultDatetime() : itemPaymentPoin.LastUpdatedOn;

                            paymentLocationPlanList.Add(new PaymentLocationPlansModels
                            {
                                payment_point_id = itemPaymentPoin.PaymentPointId,
                                payment_type_id = itemPaymentPoin.PaymentTypeId
                            });

                            arrPaymentPointId.Add(itemPaymentPoin.PaymentPointId);
                            arrPaymentPointTypeId.Add(itemPaymentPoin.PaymentTypeId);

                            paymentPoints.payment_point_id = arrPaymentPointId.ToArray();
                            paymentPoints.payment_type_id = arrPaymentPointTypeId.ToArray();
                        }
                        paymentPoints.PaymentLocationPlans = paymentLocationPlanList;

                        #endregion Mapping TrCasPaymentPoint

                        #region Mapping TrCasReferences

                        //Data Pasangan
                        var referencePasangan = dataCas.TrCasReferences.Where(m => m.ReferenceId.Equals(1)).ToList();
                        var dtPasangan = new DataPasanganModels();
                        if (referencePasangan.Count > 0)
                        {
                            dtPasangan = new DataPasanganModels
                            {
                                pasangan_id = referencePasangan.First().ReferenceId,
                                nama_pasangan = referencePasangan.First().ReferencesName,
                                alamat_pasangan = referencePasangan.First().ReferencesAddress,
                                tempat_lahir = referencePasangan.First().ReferencesBirthPlace,
                                tanggal_lahir = referencePasangan.First().ReferencesBirthDate,
                                tipe_identitas = referencePasangan.First().ReferencesIdentityTypeId,
                                no_identitas = referencePasangan.First().ReferencesIdentityNumber,
                                lokasi_pasangan_id = referencePasangan.First().ReferencesLocationId,
                                pekerjaan_pasangan = referencePasangan.First().ReferencesOccupation,
                                no_telepon = referencePasangan.First().ReferencesTelephoneNumber,
                                income = referencePasangan.First().ReferencesIncome,
                                income_desc = referencePasangan.First().ReferencesOtherIncomeDesc,
                                other_income = referencePasangan.First().ReferencesOtherIncome
                            };
                        }

                        //Data Penjamin
                        var referencePenjamin = dataCas.TrCasReferences.Where(m => m.ReferenceId.Equals(2)).ToList();
                        var dtPenjamin = new DataPenjaminModels();
                        if (referencePenjamin.Count > 0)
                        {
                            dtPenjamin = new DataPenjaminModels
                            {
                                id_penjamin = referencePenjamin.First().ReferenceId,
                                nama_penjamin = referencePenjamin.First().ReferencesName,
                                alamat = referencePenjamin.First().ReferencesAddress,
                                tipe_identitas = referencePenjamin.First().ReferencesIdentityTypeId,
                                no_identitas = referencePenjamin.First().ReferencesIdentityNumber,
                                lokasi_penjamin_id = referencePenjamin.First().ReferencesLocationId,
                                tanggal_lahir = referencePenjamin.First().ReferencesBirthDate,
                                tempat_lahir = referencePenjamin.First().ReferencesBirthPlace
                            };
                        }
                        else
                        {
                            dtPenjamin.id_penjamin = 0;
                        }

                        //Data Referensi
                        var dtReferensi = MappingArrayDataReferensi(dataCas);

                        #endregion Mapping TrCasReferences

                        #region Mapping TrCasCorporate

                        var trCasCorporate = new TrCasCorporateDocumentModels();
                        if (dataCas.CustomerType == CustomerTypes.CORPORATE_TYPE_CODE)
                        {
                            trCasCorporate = MappingCasCorporateDocument(dataCas);
                        }
                        var dataRo = dataCas.IsRepeatOrder is false ? null : MappingGetTrCasRepeatOrder(dataCas);

                        #endregion Mapping TrCasCorporate

                        #region Mapping TrCasApuppt

                        var arrQuestionId = new List<int>();
                        var arrAnswer = new List<string>();
                        var casApuppts = new TrCasApupptModels();
                        foreach (var item in dataCas.TrCasApuppt)
                        {
                            arrQuestionId.Add(item.QuestionId);
                            arrAnswer.Add(item.Answer);
                            casApuppts = new TrCasApupptModels
                            {
                                credit_id = item.CreditId,
                                created_by = item.CreatedBy,
                                created_on = item.CreatedOn,
                                question_flag = item.QuestionFlag,
                                question_id = arrQuestionId.ToArray(),
                                answer = arrAnswer.ToArray()
                            };
                        }

                        #endregion Mapping TrCasApuppt

                        //Mapping all collection item models into TrCasModels
                        casModels.Add(new TrCasModels
                        {
                            company_name = dataCas.CustomerType == CustomerTypes.CORPORATE_TYPE_CODE ? dataCas.CustomerName : String.Empty,
                            company_birth_place = dataCas.CustomerType == CustomerTypes.CORPORATE_TYPE_CODE ? dataCas.BirthPlace : String.Empty,
                            created_by = dataCas.CreatedBy,
                            created_on = (DateTime)dataCas.CreatedOn,
                            last_updated_by = dataCas.LastUpdatedBy,
                            last_updated_on = dataCas.LastUpdatedOn == null ? Commons.GetDefaultDatetime() : dataCas.LastUpdatedOn,
                            credit_id = dataCas.CreditId,
                            branch_id = dataCas.BranchId,
                            credit_source_id = dataCas.CreditSourceId,
                            order_id = dataCas.OrderId,
                            customer_type = dataCas.CustomerType,
                            is_repeat_order = dataCas.IsRepeatOrder,
                            is_instant_approval = dataCas.IsInstantApproval,
                            repeat_order_reason = dataCas.RepeatOrderReason == null ? "" : dataCas.RepeatOrderReason,
                            customer_name = dataCas.CustomerName, //dipake di C and P
                            birth_place = dataCas.BirthPlace, //dipake di C and P
                            birth_date = (DateTime)dataCas.BirthDate, //dipake di C and P
                            gender = dataCas.Gender,
                            mother_name = dataCas.MotherName,
                            email = dataCas.Email,
                            identity_type_id = dataCas.IdentityTypeId,
                            identity_number = dataCas.IdentityNumber,
                            valid_thru = dataCas.ValidThru,
                            issue_date = dataCas.IssueDate,
                            identity_address = dataCas.IdentityAddress,
                            identity_location_id = (int)dataCas.IdentityLocationId,
                            is_blacklist = (bool)dataCas.IsBlacklist,
                            customer_address = dataCas.CustomerAddress,
                            customer_location_id = (int)dataCas.CustomerLocationId,
                            npwp_no = dataCas.NpwpNo,
                            telephone_number = dataCas.TelephoneNumber,
                            mobile_phone = dataCas.MobilePhone,
                            residence_distance = (int)dataCas.ResidenceDistance,
                            customer_source_id = dataCas.CustomerSourceId,
                            is_surveyed = (bool)dataCas.IsSurveyed,
                            sources_id = (int)dataCas.SourcesId,
                            sources_name = dataCas.SourcesName,
                            sources_address = dataCas.SourcesAddress,
                            evaluation_id = (int)dataCas.EvaluationId,
                            residence_status_id = dataCas.ResidenceStatusId,
                            ownership_proof = (int)dataCas.OwnershipProof,
                            ownership_proof_name = dataCas.OwnershipProofName,
                            residence_condition = dataCas.ResidenceCondition,
                            marital_status = (int)dataCas.MaritalStatus,
                            mail_to_source_id = (int)dataCas.MailToSourceId,
                            mail_to_address = dataCas.MailToAddress,
                            mail_to_location_id = (int)dataCas.MailToLocationId,
                            mail_to_telephone_number = dataCas.MailToTelephoneNumber,
                            credit_source_status = dataCas.CreditSourceStatus,
                            analysis = dataCas.Analysis,
                            conclusion = dataCas.Conclusion,
                            is_apuppt = dataCas.IsApuppt == null ? 0 : (int)dataCas.IsApuppt,
                            RepeatOrders = dataRo,
                            Financials = new TrCasFinancialModels
                            {
                                credit_id = dataCas.CreditId,
                                commodity_type = dataCas.TrCasFinancial.CommodityType,
                                education_expenses = dataCas.TrCasFinancial.EducationExpenses,
                                health_expenses = dataCas.TrCasFinancial.HealthExpenses,
                                household_expenses = dataCas.TrCasFinancial.HouseholdExpenses,
                                industry_type_id = dataCas.TrCasFinancial.IndustryTypeId is null ? 0 : dataCas.TrCasFinancial.IndustryTypeId,
                                monthly_other_installment = dataCas.TrCasFinancial.MonthlyOtherInstallment == null ? 0 : dataCas.TrCasFinancial.MonthlyOtherInstallment,
                                number_of_dependents = dataCas.TrCasFinancial.NumberOfDependents,
                                office_address = dataCas.TrCasFinancial.OfficeAddress,
                                office_fax = dataCas.TrCasFinancial.OfficeFax,
                                office_location_id = dataCas.TrCasFinancial.OfficeLocationId,
                                office_name = dataCas.TrCasFinancial.OfficeName,
                                years_of_work_experience = dataCas.TrCasFinancial.YearsOfWorkExperience,
                                office_telephone_number = dataCas.TrCasFinancial.OfficeTelephoneNumber,
                                other_income = dataCas.TrCasFinancial.OtherIncome,
                                other_income_desc = dataCas.TrCasFinancial.OtherIncomeDesc,
                                profession_id = dataCas.TrCasFinancial.ProfessionId,
                                position = dataCas.TrCasFinancial.Position,
                                primary_income = dataCas.TrCasFinancial.PrimaryIncome,
                                created_by = dataCas.TrCasFinancial.CreatedBy,
                                created_on = dataCas.TrCasFinancial.CreatedOn,
                                last_updated_by = dataCas.TrCasFinancial.LastUpdatedBy,
                                last_updated_on = dataCas.TrCasFinancial.LastUpdatedOn == null ? Commons.GetDefaultDatetime() : dataCas.TrCasFinancial.LastUpdatedOn,
                            },
                            Installments = dataInstallments.monthly_other_installment_id != null ? dataInstallments : null,
                            PaymentPoints = paymentPoints.payment_point_id != null ? paymentPoints : null,
                            DtPasangans = referencePasangan.Count > 0 ? dtPasangan : null,
                            DtPenjamins = referencePenjamin.Count > 0 ? dtPenjamin : null,
                            DtReferensi = dtReferensi.referensi_id.Length > 0 ? dtReferensi : null,
                            CorporateDocuments = dataCas.CustomerType == CustomerTypes.CORPORATE_TYPE_CODE ? trCasCorporate : null,
                            Apuppt = casApuppts.credit_id == null ? new TrCasApupptModels() : casApuppts
                        });
                    }
                }
                else
                {
                    return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.NOT_FOUND,
                        null);
                }

                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        casModels);
            }
            catch (Exception ex)
            {
                return new APIResponse($"{ex.Message}. {ex.InnerException}");
            }
        }

        public Task<APIResponse> GetTrReferencesByreditId(string creditId)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> GetBankMasterAsync()
        {
            try
            {
                var data = await acquisitionContext
                            .GetProcedures().sp_get_gf_bankAsync();
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }

        public async Task<APIResponse> CheckBlacklistAsync(string ktpNo)
        {
            try
            {
                var data = await acquisitionContext
                            .GetProcedures().sp_check_blacklistAsync(ktpNo);
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message);
            }
        }

        public async Task<APIResponse> CheckApupptsAsync(ApupptParamModels param)
        {
            try
            {
                var data = await acquisitionContext
                            .GetProcedures().sp_check_APUPPTAsync(param.ktpNo, param.ktpNo1
                                                                , param.ktpNo2, param.name
                                                                , Convert.ToDateTime(param.birthDate), param.birthPlace
                                                                , param.alamatDomisili, param.accupation);
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message);
            }
        }

        public async Task<APIResponse> FindCreditIdByOrderIdAsync(string orderId)
        {
            try
            {
                var data = acquisitionContext.TrCas.Where(m => m.OrderId.Equals(orderId));

                if (data.FirstOrDefault() == null)
                {
                    return new APIResponse(Collection.Codes.NOT_FOUND,
                        Collection.Status.SUCCESS,
                        Collection.Messages.NOT_FOUND,
                        "");
                }
                else
                {
                    return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        data.FirstOrDefault().CreditId);
                }
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message);
            }
        }

        public async Task<APIResponse> GetNPPLamaROAsync(string ktpNo)
        {
            try
            {
                var data = await acquisitionContext
                            .GetProcedures().sp_get_agreement_number_oldAsync(ktpNo);
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message);
            }
        }

        public async Task<APIResponse> GetDataPoolingOrderAsync(string orderId)
        {
            try
            {
                var data = await acquisitionContext.GetProcedures().sp_get_pooling_orderAsync(orderId);

                return new APIResponse(Collection.Codes.SUCCESS,
                                    Collection.Status.SUCCESS,
                                    Collection.Messages.SUCCESS,
                                    data);
            }
            catch (Exception ex)
            {
                return new APIResponse($"{ex.Message}. {ex.InnerException}");
            }
        }

        public async Task<APIResponse> CheckDataReferensiByNik(string nik)
        {
            try
            {
                var data = await acquisitionContext.GetProcedures().sp_check_data_referensi_slikAsync(nik);
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        data.First());
            }
            catch (Exception ex)
            {
                return new APIResponse($"{ex.Message}. {ex.InnerException}");
            }
        }

        public async Task<APIResponse> GetDealerById(string dealerCode)
        {
            try
            {
                var data = await acquisitionContext.GetProcedures().sp_get_dealer_by_codeAsync(dealerCode);
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        data);
            }
            catch (Exception ex)
            {
                return new APIResponse($"{ex.Message}. {ex.InnerException}");
            }
        }

        public async Task<APIResponse> GetNikKonsumen(string employeeName, string branchId, bool isKonsol, bool includePos)
        {
            try
            {
                var data = await acquisitionContext.GetProcedures().sp_get_nik_konsumenAsync(employeeName, branchId, isKonsol, includePos);
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        data);
            }
            catch (Exception ex)
            {
                return new APIResponse($"{ex.Message}. {ex.InnerException}");
            }
        }

        #region Custom Functions Helper

        public TrCasRepeatOrder MappingTrCasRepeatOrder(TrCasModels trCasModels)
        {
            var mReferencesSourceDesc = trCasModels.RepeatOrders.reference_source_desc is null ? string.Empty : trCasModels.RepeatOrders.reference_source_desc;
            var dataRo = new TrCasRepeatOrder
            {
                CreditId = trCasModels.credit_id,
                BankId = trCasModels.RepeatOrders.bank_id,
                AccountName = trCasModels.RepeatOrders.account_name,
                AccountNumber = trCasModels.RepeatOrders.account_number,
                AgreementNumberOld = "",
                CreatedBy = trCasModels.created_by,
                CreatedOn = trCasModels.created_on,
                RepeatOrderApplicantRelationId = trCasModels.RepeatOrders.repeat_order_applicant_relation_id,
                RepeatOrderReferenceSourceId = trCasModels.RepeatOrders.repeat_order_reference_source_id,
                RepeatOrderCategoryId = trCasModels.RepeatOrders.repeat_order_category_id,
                RepeatOrderDecisionId = trCasModels.RepeatOrders.repeat_order_decision_id,
                RepeatOrderDescription = trCasModels.RepeatOrders.repeat_order_description,
                ReferenceSourceDesc = mReferencesSourceDesc,
                TelephoneNumber = trCasModels.RepeatOrders.telephone_number,
                LastUpdatedOn = trCasModels.last_updated_on,
                LastUpdatedBy = ""
            };
            return dataRo;
        }

        public List<TrCasReferences> MappingTrCasReferencesCollections(TrCasModels trCasModels, TrCas? existingItems)
        {
            var trCasReferences = new List<TrCasReferences>();
            if (trCasModels.DtPasangans.is_merried)
            {
                trCasModels.DtPasangans.pasangan_id = 1; //id pasangan in ms_reference_type (need to improve)
                trCasReferences.Add(new TrCasReferences
                {
                    CreditId = existingItems == null ? trCasModels.credit_id : existingItems.CreditId,
                    ReferenceId = (int)trCasModels.DtPasangans.pasangan_id,
                    ReferencesName = trCasModels.DtPasangans.nama_pasangan,
                    ReferencesAddress = trCasModels.DtPasangans.alamat_pasangan,
                    ReferencesBirthDate = trCasModels.DtPasangans.tanggal_lahir,
                    ReferencesBirthPlace = trCasModels.DtPasangans.tempat_lahir,
                    ReferencesIncome = trCasModels.DtPasangans.income,
                    ReferencesTelephoneNumber = trCasModels.DtPasangans.no_telepon,
                    ReferencesOtherIncome = trCasModels.DtPasangans.other_income,
                    ReferencesOccupation = trCasModels.DtPasangans.pekerjaan_pasangan,
                    ReferencesOtherIncomeDesc = trCasModels.DtPasangans.income_desc,
                    ReferencesIdentityTypeId = trCasModels.DtPasangans.tipe_identitas,
                    ReferencesIdentityNumber = trCasModels.DtPasangans.no_identitas,
                    ReferencesLocationId = trCasModels.DtPasangans.lokasi_pasangan_id,
                    CreatedBy = existingItems == null ? trCasModels.created_by : existingItems.CreatedBy,
                    CreatedOn = existingItems == null ? trCasModels.created_on : existingItems.CreatedOn,
                    LastUpdatedBy = existingItems == null ? "" : trCasModels.last_updated_by,
                    LastUpdatedOn = existingItems == null ? null : trCasModels.last_updated_on
                });
            }
            if (trCasModels.DtPenjamins.id_penjamin != 0)
            {
                if (trCasReferences.Count == 0)
                {
                    //Ada Penjamin is checked true with PenjaminId
                    trCasReferences.Add(new TrCasReferences
                    {
                        CreditId = existingItems == null ? trCasModels.credit_id : existingItems.CreditId,
                        ReferenceId = (int)trCasModels.DtPenjamins.id_penjamin,
                        ReferencesName = trCasModels.DtPenjamins.nama_penjamin,
                        ReferencesAddress = trCasModels.DtPenjamins.alamat,
                        ReferencesBirthPlace = trCasModels.DtPenjamins.tempat_lahir,
                        ReferencesBirthDate = trCasModels.DtPenjamins.tanggal_lahir,
                        ReferencesIdentityTypeId = trCasModels.DtPenjamins.tipe_identitas,
                        ReferencesIdentityNumber = trCasModels.DtPenjamins.no_identitas,
                        ReferencesLocationId = trCasModels.DtPenjamins.lokasi_penjamin_id,
                        CreatedBy = existingItems == null ? trCasModels.created_by : existingItems.CreatedBy,
                        CreatedOn = existingItems == null ? trCasModels.created_on : existingItems.CreatedOn,
                        LastUpdatedBy = existingItems == null ? "" : trCasModels.last_updated_by,
                        LastUpdatedOn = existingItems == null ? null : trCasModels.last_updated_on
                    });
                }
                else
                {
                    //continue bind List if List Data Pasangan already had data
                    var trCasReferencesNewRows = new List<TrCasReferences>();
                    trCasReferencesNewRows.Add(new TrCasReferences
                    {
                        CreditId = existingItems == null ? trCasModels.credit_id : existingItems.CreditId,
                        ReferenceId = (int)trCasModels.DtPenjamins.id_penjamin,
                        ReferencesName = trCasModels.DtPenjamins.nama_penjamin,
                        ReferencesAddress = trCasModels.DtPenjamins.alamat,
                        ReferencesBirthPlace = trCasModels.DtPenjamins.tempat_lahir,
                        ReferencesBirthDate = trCasModels.DtPenjamins.tanggal_lahir,
                        ReferencesIdentityTypeId = trCasModels.DtPenjamins.tipe_identitas,
                        ReferencesIdentityNumber = trCasModels.DtPenjamins.no_identitas,
                        ReferencesLocationId = trCasModels.DtPenjamins.lokasi_penjamin_id,
                        CreatedBy = existingItems == null ? trCasModels.created_by : existingItems.CreatedBy,
                        CreatedOn = existingItems == null ? trCasModels.created_on : existingItems.CreatedOn,
                        LastUpdatedBy = existingItems == null ? "" : trCasModels.last_updated_by,
                        LastUpdatedOn = existingItems == null ? null : trCasModels.last_updated_on
                    });
                    trCasReferences.AddRange(trCasReferencesNewRows);
                }
            }
            if (trCasModels.is_references)
            {
                //Ada referensi is checked true
                if (trCasReferences.Count == 0)
                {
                    //bind as new List if Data Penjamin has no data
                    for (int i = 0; i < trCasModels.DtReferensi.referensi_id.Length; i++)
                    {
                        if (trCasModels.DtReferensi.nama_referensi[i] != null)
                        {
                            trCasReferences.Add(new TrCasReferences
                            {
                                CreditId = existingItems == null ? trCasModels.credit_id : existingItems.CreditId,
                                ReferenceId = trCasModels.DtReferensi.referensi_id[i],
                                ReferencesName = trCasModels.DtReferensi.nama_referensi[i],
                                ReferencesAddress = trCasModels.DtReferensi.alamat_referensi[i],

                                ReferencesLocationId = trCasModels.DtReferensi.lokasi_id_referensi[i],
                                ReferencesRelationship = trCasModels.DtReferensi.hubungan_pemohon[i],

                                ReferencesMobileNumber = trCasModels.DtReferensi.mobile_phone[i],
                                ReferencesTelephoneNumber = trCasModels.DtReferensi.no_telepon[i],
                                ReferencesOfficePhoneNumber = trCasModels.DtReferensi.no_telp_kantor[i],
                                CreatedBy = existingItems == null ? trCasModels.created_by : existingItems.CreatedBy,
                                CreatedOn = existingItems == null ? trCasModels.created_on : existingItems.CreatedOn,
                                LastUpdatedBy = existingItems == null ? "" : trCasModels.last_updated_by,
                                LastUpdatedOn = existingItems == null ? null : trCasModels.last_updated_on
                            });
                        }
                    }
                }
                else
                {
                    //continue bind List if List already had data from Data Penjamin
                    var dataReferencesNewRows = new List<TrCasReferences>();
                    for (int i = 0; i < trCasModels.DtReferensi.referensi_id.Length; i++)
                    {
                        dataReferencesNewRows.Add(new TrCasReferences
                        {
                            CreditId = existingItems == null ? trCasModels.credit_id : existingItems.CreditId,
                            ReferenceId = trCasModels.DtReferensi.referensi_id[i],
                            ReferencesName = trCasModels.DtReferensi.nama_referensi[i],
                            ReferencesAddress = trCasModels.DtReferensi.alamat_referensi[i],
                            ReferencesLocationId = trCasModels.DtReferensi.lokasi_id_referensi[i],
                            ReferencesRelationship = trCasModels.DtReferensi.hubungan_pemohon[i],
                            ReferencesMobileNumber = trCasModels.DtReferensi.mobile_phone[i],
                            ReferencesTelephoneNumber = trCasModels.DtReferensi.no_telepon[i],
                            ReferencesOfficePhoneNumber = trCasModels.DtReferensi.no_telp_kantor[i],
                            CreatedBy = existingItems == null ? trCasModels.created_by : existingItems.CreatedBy,
                            CreatedOn = existingItems == null ? trCasModels.created_on : existingItems.CreatedOn,
                            LastUpdatedBy = existingItems == null ? "" : trCasModels.last_updated_by,
                            LastUpdatedOn = existingItems == null ? null : trCasModels.last_updated_on
                        });
                    }
                    trCasReferences.AddRange(dataReferencesNewRows);
                }
            }
            return trCasReferences.ToList();
        }

        /// <summary>
        /// Mapping TrCasApuppts (Add and Edit condition)
        /// </summary>
        /// <param name="trCasModels">request input data</param>
        /// <param name="existingItems">Existing data (for Edit condition)</param>
        /// <returns></returns>
        public List<TrCasApuppt> MappingTrCasApuppts(TrCasModels trCasModels, TrCas? existingItems)
        {
            var dataApuppts = new List<TrCasApuppt>();
            if (trCasModels.customer_type == CustomerTypes.INDIVIDUAL_TYPE_CODE || trCasModels.is_apuppt_filled)
            {
                if (trCasModels.Apuppt.question_id.Length > 0)
                {
                    for (int i = 0; i < trCasModels.Apuppt.question_id.Length; i++)
                    {
                        dataApuppts.Add(new TrCasApuppt
                        {
                            CreditId = trCasModels.credit_id,
                            QuestionId = trCasModels.Apuppt.question_id[i],
                            Answer = trCasModels.Apuppt.answer[i],
                            QuestionFlag = trCasModels.Apuppt.question_flag,
                            CreatedBy = existingItems == null ? trCasModels.created_by : existingItems.CreatedBy,
                            CreatedOn = existingItems == null ? trCasModels.created_on : existingItems.CreatedOn,
                        });
                    }
                }
            }
            else
            {
                dataApuppts = null;
            }
            return dataApuppts;
        }

        /// <summary>
        /// Generate auto-number for Credit Id
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public async Task<string> GetCreditIdAsync(string branchId)
        {
            var code = await GenerateCreditId(branchId);
            var result = (List<sp_get_auto_numberResult>)code.data;
            return result.FirstOrDefault().Result;
        }

        public DataReferensiModels MappingArrayDataReferensi(TrCas dataCas)
        {
            var referencesId = new int[] { 3, 4, 5 };

            var arrRefId = new List<int>();
            var arrRefName = new List<string>();
            var arrRefRelation = new List<int>();
            var arrRefAddress = new List<string>();
            var arrRefTelp = new List<string>();
            var arrRefTelpKantor = new List<string>();
            var arrRefMobilePhone = new List<string>();
            var arrRefLocationId = new List<int>();

            var referenceCollections = dataCas.TrCasReferences.Where(m => referencesId.Contains(m.ReferenceId)).ToList();
            var dt = new DataReferensiModels();
            foreach (var item in referenceCollections)
            {
                arrRefId.Add(item.ReferenceId);
                arrRefName.Add(item.ReferencesName);
                arrRefRelation.Add((int)item.ReferencesRelationship);
                arrRefAddress.Add(item.ReferencesAddress);
                arrRefTelp.Add(item.ReferencesTelephoneNumber);
                arrRefTelpKantor.Add(item.ReferencesOfficePhoneNumber);
                arrRefMobilePhone.Add(item.ReferencesMobileNumber);
                arrRefLocationId.Add((int)item.ReferencesLocationId);
            }
            dt = new DataReferensiModels
            {
                referensi_id = arrRefId.ToArray(),
                nama_referensi = arrRefName.ToArray(),
                alamat_referensi = arrRefAddress.ToArray(),
                hubungan_pemohon = arrRefRelation.ToArray(),
                lokasi_id_referensi = arrRefLocationId.ToArray(),
                mobile_phone = arrRefMobilePhone.ToArray(),
                no_telepon = arrRefTelp.ToArray(),
                no_telp_kantor = arrRefTelpKantor.ToArray()
            };
            return dt;
        }

        public TrCasCorporateDocumentModels MappingCasCorporateDocument(TrCas trCas)
        {
            return new TrCasCorporateDocumentModels
            {
                credit_id = trCas.TrCasCorporateDocument.CreditId,
                corporate_tax_idNumber = trCas.TrCasCorporateDocument.CorporateTaxIdNumber,
                commissioner_identity_number = trCas.TrCasCorporateDocument.CommissionerIdentityNumber,
                completeness_letter_due_date = trCas.TrCasCorporateDocument.CompletenessLetterDueDate,
                corporate_commisioner_name = trCas.TrCasCorporateDocument.CorporateCommisionerName,
                corporate_debitur_type = trCas.TrCasCorporateDocument.CorporateDebiturType,
                completeness_letter_issue_date = trCas.TrCasCorporateDocument.CompletenessLetterIssueDate,
                corporate_director_name = trCas.TrCasCorporateDocument.CorporateDirectorName,
                corporate_email = trCas.TrCasCorporateDocument.CorporateEmail,
                corporate_fax_number = trCas.TrCasCorporateDocument.CorporateFaxNumber,
                corporate_industry_id = trCas.TrCasCorporateDocument.CorporateIndustryId,
                corporate_month_period = trCas.TrCasCorporateDocument.CorporateMonthPeriod,
                corporate_number_of_employee = trCas.TrCasCorporateDocument.CorporateNumberOfEmployee,
                corporate_other_industry = trCas.TrCasCorporateDocument.CorporateOtherIndustry,
                corporate_site = trCas.TrCasCorporateDocument.CorporateSite,
                corporate_status = trCas.TrCasCorporateDocument.CorporateStatus,
                corporate_telephone_number = trCas.TrCasCorporateDocument.CorporateTelephoneNumber,
                corporate_year_period = trCas.TrCasCorporateDocument.CorporateYearPeriod,
                director_identity_number = trCas.TrCasCorporateDocument.DirectorIdentityNumber,
                director_tax_id_number = trCas.TrCasCorporateDocument.DirectorTaxIdNumber,
                founders_deed_date = (DateTime)trCas.TrCasCorporateDocument.FoundersDeedDate,
                founders_deed_number = trCas.TrCasCorporateDocument.FoundersDeedNumber,
                founders_notary_name = trCas.TrCasCorporateDocument.FoundersNotaryName,
                is_completeness_letter = trCas.TrCasCorporateDocument.IsCompletenessLetter,
                management_deed_date = trCas.TrCasCorporateDocument.ManagementDeedDate,
                management_deed_number = trCas.TrCasCorporateDocument.ManagementDeedNumber,
                management_notary_name = trCas.TrCasCorporateDocument.ManagementNotaryName,
                siup_due_date = trCas.TrCasCorporateDocument.SiupDueDate,
                siup_id = trCas.TrCasCorporateDocument.SiupId,
                siup_issue_date = trCas.TrCasCorporateDocument.SiupIssueDate,
                tdp_due_date = trCas.TrCasCorporateDocument.TdpDueDate,
                tdp_id = trCas.TrCasCorporateDocument.TdpId,
                tdp_issue_date = trCas.TrCasCorporateDocument.TdpIssueDate,
                created_by = trCas.TrCasCorporateDocument.CreatedBy,
                created_on = trCas.TrCasCorporateDocument.CreatedOn,
                last_updated_by = trCas.TrCasCorporateDocument.LastUpdatedBy,
                last_updated_on = trCas.TrCasCorporateDocument.LastUpdatedOn == null ? Commons.GetDefaultDatetime() : trCas.TrCasCorporateDocument.LastUpdatedOn
            };
        }

        public TrCasRepeatOrderModels MappingGetTrCasRepeatOrder(TrCas dataCas)
        {
            var dataro = new TrCasRepeatOrderModels
            {
                credit_id = dataCas.CreditId,
                repeat_order_description = dataCas.TrCasRepeatOrder.RepeatOrderDescription,
                account_name = dataCas.TrCasRepeatOrder.AccountName,
                account_number = dataCas.TrCasRepeatOrder.AccountNumber,
                bank_id = dataCas.TrCasRepeatOrder.BankId,
                agreement_number_old = dataCas.TrCasRepeatOrder.AgreementNumberOld,
                repeat_order_applicant_relation_id = dataCas.TrCasRepeatOrder.RepeatOrderApplicantRelationId,
                repeat_order_category_id = dataCas.TrCasRepeatOrder.RepeatOrderCategoryId,
                repeat_order_decision_id = dataCas.TrCasRepeatOrder.RepeatOrderDecisionId,
                repeat_order_reference_source_id = dataCas.TrCasRepeatOrder.RepeatOrderReferenceSourceId,
                telephone_number = dataCas.TrCasRepeatOrder.TelephoneNumber,
                reference_source_desc = dataCas.TrCasRepeatOrder.ReferenceSourceDesc is null ? string.Empty :  dataCas.TrCasRepeatOrder.ReferenceSourceDesc,
                created_by = dataCas.TrCasRepeatOrder.CreatedBy,
                created_on = dataCas.TrCasRepeatOrder.CreatedOn,
                last_updated_by = dataCas.TrCasRepeatOrder.LastUpdatedBy,
                last_updated_on = dataCas.TrCasRepeatOrder.LastUpdatedOn == null ? Commons.GetDefaultDatetime() : dataCas.TrCasRepeatOrder.LastUpdatedOn
            };
            return dataro;
        }

        public async Task<TrCas> GetDeserializeTrCasData(string creditId)
        {
            var trCasModels = new List<TrCas>();
            try
            {
                trCasModels = await acquisitionContext.TrCas
                            .Include(x => x.TrCasRepeatOrder)
                            .Include(x => x.TrCasFinancial)
                            .Include(x => x.TrCasApuppt)
                            .Include(x => x.TrCasReferences)
                            .Include(x => x.TrCasCorporateDocument)
                            .Include(x => x.TrCasPaymentPoint)
                            .Include(x => x.TrCasInstallment)
                            .Where(m => m.CreditId.Equals(creditId))
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
            return trCasModels.ToList().FirstOrDefault();
        }

        private List<TrCasInstallmentModels> FindChangesDataTrInstallment(TrCasModels requestedData, TrCas existingData)
        {
            var dtInstallments = new List<TrCasInstallmentModels>();
            var ids = new List<int>();

            return dtInstallments;
        }

        #endregion Custom Functions Helper
    }
}
