namespace FINCORE.SERVICE.CM.Models
{
    public class CMPhotoTypeModel
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string? credit_id { get; set; }
        public string? photo_type_id { get; set; }
        public string? photo_type_desc { get; set; }
        public string? photo_id { get; set; }
        public string? photo_desc { get; set; }
        public string? filename { get; set; }
        public string? filePath { get; set; }
    }
}