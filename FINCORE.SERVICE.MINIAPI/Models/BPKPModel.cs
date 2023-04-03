using System.ComponentModel.DataAnnotations;
namespace FINCORE.SERVICE.BPKB.Models
{
    public class BPKPModel
    {
        [Required]
        public Int64 RowNumber {get;set;}
        public string BPKBNo { get; set; }
        public string BranchId { get; set; }
        public string AgreementNumber { get; set; }
        public DateTime BPKBDateIn { get;set; }
        public DateTime BPBKDate { get; set; }
        public string FakturNo { get; set; }
        public DateTime FakturDate { get; set; }
        public string PoliceNo { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string SerialNo { get; set; }
        public string BPKBStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        
    }
}
