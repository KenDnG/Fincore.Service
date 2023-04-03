using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.Vertel
{
    public class VertelApprovalModels
    {
        public int ReasonId { get; set; }
        public int? Type { get; set; }
        public string? ReasonDescription { get; set; }
        public string? EmployeeId { get; set; }
        public string TransId { get; set; }
    }
}
