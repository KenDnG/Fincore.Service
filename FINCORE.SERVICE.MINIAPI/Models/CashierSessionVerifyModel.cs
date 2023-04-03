using System.ComponentModel.DataAnnotations;

namespace FINCORE.SERVICE.MINIAPI.Models
{
    public class CashierSessionVerifyModel
    {
        [Required]
        public string? BranchId { get; set; }
        public string? SearchTerm { get; set; } = "";
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
