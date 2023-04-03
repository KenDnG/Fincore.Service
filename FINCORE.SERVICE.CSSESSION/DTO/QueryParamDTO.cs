using System.ComponentModel.DataAnnotations;

namespace FINCORE.SERVICE.CSSESSION.DTO
{
    public class QueryParamDTO
    {
        [Required]
        public string? BranchId { get; set; }

        public string? SearchTerm { get; set; } = "";

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 5;
    }
}