using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst
{
    public class CreditAnalystSLikModels
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? Id { get; set; }
        public string? CaNo { get; set; }
        public string? Relation { get; set; }
        public string? FacilityName { get; set; }
        public string? BankId { get; set; }
        public string? FacilityType { get; set; }
        public string? Plafon { get; set; }
        public string? Os { get; set; }
        public string? KolStatus { get; set; }
        public string? KolMax { get; set; }
        public string? Status { get; set; }
    }
}
