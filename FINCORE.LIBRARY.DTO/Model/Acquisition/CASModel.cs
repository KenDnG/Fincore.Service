using FINCORE.LIBRARY.DTO.Model.Interfaces;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition
{
    public class CreditModel : ICreateUpdateTime
    {
        public string? credit_id { get; set; }
        public string? outlet_code { get; set; }
        public string? credit_source_id { get; set; }
        public string? mobile_product { get; set; }
        public string? order_id { get; set; }
        public string? customer_type { get; set; } = "P";
        public bool? is_repeat_order { get; set; } = true;
        public bool? is_instant_approval { get; set; } = true;
        public string? repeat_order_reason { get; set; }
        public string? customer_name { get; set; }
        public string created_by { get; set; }
        public DateTime created_on { get; set; }
        public string? last_updated_by { get; set; }
        public DateTime? last_updated_on { get; set; }
    }
}