using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst.CAS.CAS_Reference
{
    public class CreditAnalyst_CASReferencePasanganModels
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string? CreditId { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferencesName { get; set; }
        public string? ReferencesIdentityTypeId { get; set; }
        public string? ReferencesIdentityNumber { get; set; }
        public string? ReferencesBirthPlace { get; set; }
        public DateTime? ReferencesBirthDate { get; set; }
        public string? ReferencesAddress { get; set; }
        public string? ReferencesTelephoneNumber { get; set; }
        public string? ReferencesOccupation { get; set; }
        public decimal? ReferencesIncome { get; set; }
        public decimal? ReferencesOtherIncome { get; set; }
        public string? ReferencesOtherIncomeDesc { get; set; }
        public int? ReferencesLocationId { get; set; }
        public string? ReferencesFax { get; set; }
        public int? ReferencesRelationship { get; set; }
        public string? ReferencesOfficePhoneNumber { get; set; }
        public string? ReferencesMobileNumber { get; set; }
    }
}
