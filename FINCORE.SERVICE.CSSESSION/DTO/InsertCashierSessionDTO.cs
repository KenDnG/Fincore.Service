using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FINCORE.SERVICE.CSSESSION.DTO
{
    public class CashierSessionDTO 
    {

        [Required]
        [StringLength(15)]
        public string? UserName { get; set; }

    }

    public class InsertCashierSessionDTO : CashierSessionDTO
    {
        [Required]
        [StringLength(15)]
        public string? UserId { get; set; }

        [Required]
        [StringLength(maximumLength:5, MinimumLength =5)]
        public string? BranchId { get; set; }

        public string GetSessionId() => BranchId + DateTime.Today.ToString("yyMMdd");

    }

    public class UpdateCashierSessionDTO : CashierSessionDTO
    {
        [Required]
        [StringLength(13)]
        public string? SessionId { get; set; }

        [Required]
        public double CashAmount { get; set; }

        [Required]
        public double CurrentAmount { get; set; }

    }
}
