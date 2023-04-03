using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst.Prints
{
    public class CreditAnalyst_PrintHistoryModels
    {
        public long? Id { get; set; }
        public string? CaNo { get; set; }
        public string? PrintedBy { get; set; }
        public DateTime? PrintedDate { get; set; }
        public int? Sequence { get; set; }
    }
}
