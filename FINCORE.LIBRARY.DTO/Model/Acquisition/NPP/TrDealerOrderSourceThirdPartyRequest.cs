namespace FINCORE.LIBRARY.DTO.Model.Acquisition.NPP
{
    public class TrDealerOrderSourceThirdPartyRequest
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string? CreditId { get; set; }
        public int? JobTitleId { get; set; }
        public int? PersonelId { get; set; }
        public string? PersonelName { get; set; }
        public decimal? RateProvisiRefund { get; set; }
        public decimal? AmountProvisiRefund { get; set; }
        public decimal? AmountProvisiRefundAfterTax { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankAccountName { get; set; }
    }
}