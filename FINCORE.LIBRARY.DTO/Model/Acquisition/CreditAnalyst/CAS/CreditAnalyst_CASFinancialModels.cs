using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst.CAS
{
    public class CreditAnalyst_CASFinancialModels
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string? CreditId { get; set; }
        public decimal? PrimaryIncome { get; set; }
        public decimal? OtherIncome { get; set; }
        public string? OtherIncomeDesc { get; set; }
        public string? OfficeName { get; set; }
        public string? OfficeAddress { get; set; }
        public int? OfficeLocationId { get; set; }
        public string? OfficeTelephoneNumber { get; set; }
        public string? OfficeFax { get; set; }
        public string? Position { get; set; }
        public int? IndustryTypeId { get; set; }
        public string? CommodityType { get; set; }
        public decimal? YearsOfWorkExperience { get; set; }
        public string? ProfessionId { get; set; }
        public decimal? HouseholdExpenses { get; set; }
        public decimal? EducationExpenses { get; set; }
        public decimal? HealthExpenses { get; set; }
        public int? NumberOfDependents { get; set; }
        public decimal? MonthlyOtherInstallment { get; set; }

        public virtual CreditAnalyst_CASModels? Credit { get; set; }
    }
}
