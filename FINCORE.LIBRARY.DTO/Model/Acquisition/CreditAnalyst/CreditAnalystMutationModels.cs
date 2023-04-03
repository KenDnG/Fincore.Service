using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst
{
    public class CreditAnalystMutationModels
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? Id { get; set; }
        public string? AccountDetailId { get; set; }
        public string? MutationMonth { get; set; }
        public string? MutationYear { get; set; }
        public decimal? TotalCreditMutation { get; set; }
        public decimal? TotalDebitMutation { get; set; }
        public decimal? EndOfMonthBalance { get; set; }

        public virtual CreditAnalystDetailModels? AccountDetail { get; set; }
    }
}
