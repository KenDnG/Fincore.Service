using FINCORE.HELPER.LIBRARY.Helper;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CAS
{
    public class TrCasRepeatOrderModels
    {
        public string? created_by { get; set; }
        public DateTime? created_on { get; set; }
        public string? last_updated_by { get; set; } = String.Empty;
        public DateTime? last_updated_on { get; set; } = Commons.GetDefaultDatetime();
        public string? credit_id { get; set; }
        public string? agreement_number_old { get; set; } = string.Empty;
        public string? repeat_order_description { get; set; } = string.Empty;
        public string? repeat_order_category_id { get; set; } = string.Empty;
        public string? repeat_order_decision_id { get; set; } = string.Empty;
        public string? repeat_order_reference_source_id { get; set; } = string.Empty;
        public string? repeat_order_applicant_relation_id { get; set; } = string.Empty;
        public string? bank_id { get; set; }
        public string? account_name { get; set; }
        public string? account_number { get; set; }
        public string? telephone_number { get; set; }
        public string reference_source_desc { get; set; } = string.Empty;
    }
}