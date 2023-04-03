using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst
{
    public class CreditAnalystDetailModels
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string? AccountDetailId { get; set; }
        public string? CaNo { get; set; }
        public string? AccountName { get; set; }
        public string? AccountNumber { get; set; }
        public string? BankId { get; set; }
        public decimal? PreviousMonthBalance { get; set; }

        public virtual List<CreditAnalystMutationModels>? TrCaAccountMutations { get; set; }
    }
}
