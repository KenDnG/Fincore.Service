using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst
{
    public class CreditAnalyst_Tr_CAModels
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string? CaNo { get; set; }
        public string? CompanyId { get; set; }
        public string? BranchId { get; set; }
        public string? CreditId { get; set; }
        public string? CorporateLegalEntity { get; set; }
        public string? HouseCondition { get; set; }
        public string? EnvironmentCondition { get; set; }
        public string? LengthOfStay { get; set; }
        public string? CompanyOwnership { get; set; }
        public string? BusinessActivity { get; set; }
        public string? CorporateScale { get; set; }
        public string? BeneficialOwner { get; set; }
        public string? BusinessEnvironment { get; set; }
        public string? RoadAccess { get; set; }
        public string? ApplicantValidation { get; set; }
        public string? ReferenceValidation { get; set; }
        public decimal? Mrp { get; set; }
        public string? SpkName { get; set; }
        public DateTime? SpkDate { get; set; }
        public string? SubmissionValidation { get; set; }
        public string? VertelValidationReason { get; set; }
        public string? SlikLink { get; set; }
        public string? PositiveAspects { get; set; }
        public string? NegativeAspects { get; set; }
        public string? CaNik { get; set; }
        public string? CaDecision { get; set; }
        public string? CreditAnalysis { get; set; }
        public string? Approval { get; set; }
        public string? CaStatus { get; set; }
        public string? LastPrintedBy { get; set; }
        public DateTime? LastPrintedOn { get; set; }
        public int? SumOfPrint { get; set; }

        public virtual List<CreditAnalystFinancialModels>? TrCaFinancials { get; set; }
    }
}
