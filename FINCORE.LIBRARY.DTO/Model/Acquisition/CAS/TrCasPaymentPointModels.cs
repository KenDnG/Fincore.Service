using FINCORE.HELPER.LIBRARY.Helper;
using FINCORE.LIBRARY.DTO.Model.Acquisition.CAS.ModelHelper;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CAS
{
    public class TrCasPaymentPointModels
    {
        public string? created_by { get; set; }
        public DateTime? created_on { get; set; }
        public string? last_updated_by { get; set; } = String.Empty;
        public DateTime? last_updated_on { get; set; } = Commons.GetDefaultDatetime();
        public string? credit_id { get; set; }
        public int[] payment_type_id { get; set; }
        public int[] payment_point_id { get; set; }
        public List<PaymentLocationPlansModels>? PaymentLocationPlans { get; set; }
    }

    //public class PaymentLocationPlansModels
    //{
    //    public int payment_type_id { get; set; }
    //    public int payment_point_id { get; set; }
    //}
}