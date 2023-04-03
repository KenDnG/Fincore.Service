using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/location/")]
    [ApiController]
    public class MsLocationController : ControllerBase
    {
        private readonly IMsLocation msLocation;

        public MsLocationController(IMsLocation msLocation)
        {
            this.msLocation = msLocation;
        }

        [HttpGet("getlocationbyid")]
        public async Task<IActionResult> GetLocationById(int locationId)
        {
            return Ok(await msLocation.GetLocationByIdAsync(locationId));
        }

        [HttpGet("getlocation")]
        public async Task<IActionResult> GetLocation()
        {
            return Ok(await msLocation.GetLocationAsync());
        }
    }
}