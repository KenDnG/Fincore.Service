using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst.CAS
{
    public class CreditAnalyst_CASCorporateModels
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string? CreditId { get; set; }
        public string? CorporateCommisionerName { get; set; }
        public string? CorporateDirectorName { get; set; }
        public string? CorporateStatus { get; set; }
        public string? CorporateIndustryId { get; set; }
        public string? CorporateOtherIndustry { get; set; }
        public byte? CorporateYearPeriod { get; set; }
        public byte? CorporateMonthPeriod { get; set; }
        public decimal? CorporateNumberOfEmployee { get; set; }
        public string? CorporateDebiturType { get; set; }
        public string? CorporateTelephoneNumber { get; set; }
        public string? CorporateFaxNumber { get; set; }
        public string? CorporateSite { get; set; }
        public string? CorporateEmail { get; set; }
        public string? FoundersDeedNumber { get; set; }
        public DateTime? FoundersDeedDate { get; set; }
        public string? FoundersNotaryName { get; set; }
        public string? ManagementDeedNumber { get; set; }
        public DateTime? ManagementDeedDate { get; set; }
        public string? ManagementNotaryName { get; set; }
        public string? DirectorIdentityNumber { get; set; }
        public string? CommissionerIdentityNumber { get; set; }
        public string? CorporateTaxIdNumber { get; set; }
        public string? DirectorTaxIdNumber { get; set; }
        public string? SiupId { get; set; }
        public DateTime? SiupIssueDate { get; set; }
        public DateTime? SiupDueDate { get; set; }
        public string? TdpId { get; set; }
        public DateTime? TdpIssueDate { get; set; }
        public DateTime? TdpDueDate { get; set; }
        public bool? IsCompletenessLetter { get; set; }
        public DateTime? CompletenessLetterIssueDate { get; set; }
        public DateTime? CompletenessLetterDueDate { get; set; }

        public virtual CreditAnalyst_CASModels? Credit { get; set; }
    }
}
