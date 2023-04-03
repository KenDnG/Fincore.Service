using FINCORE.LIBRARY.DTO.Model.Interfaces;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition
{
    public class POModel : ICreateUpdateTime
    {
        public string kode_cabang { get; set; }
        public string po_no { get; set; }
        public string tipe_konsumen { get; set; }
        public string existing_customer_ro { get; set; }
        public string nama_nasabah { get; set; }
        public string created_by { get; set; }
        public DateTime created_on { get; set; }
        public string? last_updated_by { get; set; }
        public DateTime? last_updated_on { get; set; }
    }
}