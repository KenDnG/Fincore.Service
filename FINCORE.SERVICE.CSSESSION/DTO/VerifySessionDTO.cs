using System.ComponentModel.DataAnnotations;

namespace FINCORE.SERVICE.CSSESSION.DTO
{
    public class VerifySessionDTO
    {
        [Required]
        public string SessionId { get; set; }
        [Required]
        public string EmployeeId { get; set; }
    }
}
