using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst.CA_Financial
{
    public class CreditAnalyst_FinancialTambahanModels
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? Id { get; set; }
        public string? CaNo { get; set; }
        public long? IncomeTypeId { get; set; }
        public string? SourceOfIncome { get; set; }
        public string? CorporateOrBussinessName { get; set; }
        public string? CorporateOrBussinessAddress { get; set; }
        public string? Position { get; set; }
        public string? ProfessionId { get; set; }
        public string? LengthOfWork { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmployeeStatus { get; set; }
        public string? IndustryTypeId { get; set; }
        public string? NumberOfEmployees { get; set; }
        public string? IsOtherIncome { get; set; }
        public string? IncomeValidation { get; set; }
    }
}
