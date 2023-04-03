using FINCORE.LIBRARY.DTO.Model.Interfaces;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition
{
    public class Year : ICreateUpdateTime
    {
        public string CASId { get; set; }
        public string PhotoTypeID { get; set; }
        public string PhotoID { get; set; }
        public string filename { get; set; }
        public string filePath { get; set; }
        public string? namefile { get; set; }
        public string created_by { get; set; }
        public DateTime created_on { get; set; }
        public string? last_updated_by { get; set; }
        public DateTime? last_updated_on { get; set; }
    }

    public class GetFoto
    {
        public string PhotoTypeID { get; set; }
        public string PhotoID { get; set; }
        public string PhotoTypeDescription { get; set; }
        public string PhotoDescription { get; set; }
        public string filename { get; set; }
        public string urlfoto { get; set; }
    }
}