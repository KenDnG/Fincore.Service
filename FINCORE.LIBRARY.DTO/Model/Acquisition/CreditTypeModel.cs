using FINCORE.LIBRARY.DTO.Model.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition
{
    public class CreditTypeModel : ICreateUpdateTime
    {
        public string credit_type_id { get; set; }

        [Required]
        public int id_type { get; set; }

        public string credit_id { get; set; }

        [Required]
        public DateTime valid_thru { get; set; }

        [Required]
        public DateTime issue_date { get; set; }

        [Required]
        public string id_no { get; set; }

        public string id_address { get; set; }
        public int location_id { get; set; }

        [Required]
        public bool is_active { get; set; }

        public string created_by { get; set; }
        public DateTime created_on { get; set; }
        public string? last_updated_by { get; set; }
        public DateTime? last_updated_on { get; set; }
    }
}