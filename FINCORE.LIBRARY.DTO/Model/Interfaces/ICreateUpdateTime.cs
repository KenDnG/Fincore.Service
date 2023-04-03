namespace FINCORE.LIBRARY.DTO.Model.Interfaces
{
    public interface ICreateUpdateTime
    {
        public string created_by { get; set; }
        public DateTime created_on { get; set; }
        public string? last_updated_by { get; set; }
        public DateTime? last_updated_on { get; set; }
    }
}