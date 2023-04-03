using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition
{
    public class BPKBCustomModel
    {
        public TrBpkb? Bpkb { get; set; }
        public TrBpkbLoan? BpkbPinjam { get; set; }
        public string? CustomerName { get; set; }
        public string? QQName { get; set; }
        public string? sBPKB { get; set; }
        public string? ChasisNo { get; set; }
        public string? MachineNo { get; set; }
        public string? DealerCode { get; set; }
        public string? ItemMerk { get; set; }
        public string? ItemTypeName { get; set; }
        public string? ItemColor { get; set; }
        public string? StatusNPP { get; set; }
        public string? StatusLunasNPP { get; set; }
        public string? STATUSBPKB { get; set; }
        public string? ItemYear { get; set; }
        public string? CompanyId { get; set; }
        public string? UserName { get; set; }
        public string? BranchName { get; set; }
        public string? BranchId { get; set; }
    }
}