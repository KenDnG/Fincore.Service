using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FINCORE.SERVICE.MINIAPI.Controllers.Approval
{
    [Route("api/v1/services/mini/approval/")]
    [ApiController]
    public sealed class InboxApprovalController : ControllerBase
    {
        private readonly IApproval approval;

        public InboxApprovalController(IApproval approval)
        {
            this.approval = approval;
        }

        [HttpPost("pagination/inbox")]
        public async Task<IActionResult> PaginationInboxApproval([FromBody] QueryParams queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(new APIResponse(Collection.Codes.BAD_REQUEST,
                                       Collection.Status.FAILED,
                                       "Id is Required",
                new { }));

            if (queryParams is not null && !string.IsNullOrEmpty(queryParams.SearchTerm))
            {
                queryParams.SearchTerm = queryParams.SearchTerm.Trim();
            }

            return Ok(await approval.GetPaginationInboxApproval(queryParams.EmployeeId,
                queryParams.SearchTerm, queryParams.PageIndex, queryParams.PageSize));

        }
    }

    public class QueryParams
    {
        [Required]
        public string? EmployeeId { get; set; }

        public string? SearchTerm { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 5;

    }
}
