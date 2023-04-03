using FINCORE.HELPER.LIBRARY.Helper;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CAS
{
    public class TrCasInstallmentModels
    {
        public string? created_by { get; set; }
        public DateTime? created_on { get; set; }
        public string? last_updated_by { get; set; } = String.Empty;
        public DateTime? last_updated_on { get; set; } = Commons.GetDefaultDatetime();
        public string? credit_id { get; set; }
        public string[] monthly_other_installment_id { get; set; }
    }

    public class TrInstallmentViewModels
    {
        public List<TrCasInstallmentModels> NewData { get; set; }
        public List<TrCasInstallmentModels> ExistingData { get; set; }
    }
}