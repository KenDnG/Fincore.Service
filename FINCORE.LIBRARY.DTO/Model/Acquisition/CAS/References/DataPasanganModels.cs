namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CAS
{
    public class DataPasanganModels
    {
        public int? pasangan_id { get; set; }
        public string? nama_pasangan { get; set; }
        public string? tipe_identitas { get; set; }
        public string? no_identitas { get; set; }
        public string? tempat_lahir { get; set; }
        public DateTime? tanggal_lahir { get; set; }
        public string? alamat_pasangan { get; set; }
        public string? no_telepon { get; set; }
        public string? pekerjaan_pasangan { get; set; }
        public decimal? income { get; set; }
        public decimal? other_income { get; set; }
        public string? income_desc { get; set; }
        public int? lokasi_pasangan_id { get; set; }
        public bool is_merried { get; set; }
    }
}