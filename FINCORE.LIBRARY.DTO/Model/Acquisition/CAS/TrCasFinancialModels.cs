using FINCORE.HELPER.LIBRARY.Helper;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CAS
{
    public class TrCasFinancialModels
    {
        public string? created_by { get; set; }
        public DateTime? created_on { get; set; }
        public string? last_updated_by { get; set; } = String.Empty;
        public DateTime? last_updated_on { get; set; } = Commons.GetDefaultDatetime();
        public string? credit_id { get; set; }
        public decimal? primary_income { get; set; }
        public decimal? other_income { get; set; }
        public string? other_income_desc { get; set; }
        public string? office_name { get; set; }
        public string? office_address { get; set; }
        public int? office_location_id { get; set; }
        public string? office_telephone_number { get; set; }
        public string? office_fax { get; set; }
        public string? position { get; set; }
        public int? industry_type_id { get; set; }
        public string? commodity_type { get; set; }
        public decimal? years_of_work_experience { get; set; }
        public string profession_id { get; set; }
        public decimal? household_expenses { get; set; }
        public decimal? education_expenses { get; set; }
        public decimal? health_expenses { get; set; }
        public int? number_of_dependents { get; set; }
        public decimal? monthly_other_installment { get; set; }
    }
}