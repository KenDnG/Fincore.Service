namespace FINCORE.LIBRARY.DTO.Model.Acquisition
{
    public class TrCAS_CreditAnalyst
    {
        public string? CASId { get; set; }
        public string Capacity { get; set; }
        public string Capital { get; set; }
        public string Character { get; set; }
        public string Condition { get; set; }
        public string Collateral { get; set; }
        public string Strenght { get; set; }
        public string Weakness { get; set; }

        public List<string>? PhotoTypeID { get; set; }
        public List<string>? PhotoID { get; set; }
        public List<string>? filename { get; set; }
        public List<string>? filePath { get; set; }
        public string created_by { get; set; }
        public DateTime created_on { get; set; }
        public string? last_updated_by { get; set; }
        public DateTime? last_updated_on { get; set; }
    }
}