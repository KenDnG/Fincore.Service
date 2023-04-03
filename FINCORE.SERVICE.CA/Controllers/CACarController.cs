using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.CA.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.CA.Controllers
{
    [Route("api/v0/services/acquisition/cacar/")]
    [ApiController]
    public class CACarController : ControllerBase
    {
        private readonly ICACar iCACar;

        public CACarController(ICACar _iCACar)
        {
            iCACar = _iCACar;
        }

        /// <summary>
        /// Command with Entity Framework.
        /// </summary>

        [HttpPost("ef/insert-cm_photo_detail")]
        public async Task<IActionResult> InsertCM_Photo_Detail(Tr_CM_photo_detail Tr_CM_photo_detailModel)
        {
            return Ok(await iCACar.InsertCM_Photo_Detail(Tr_CM_photo_detailModel));
        }

        [HttpPost("ef/insert-cmo_analisa")]
        public async Task<IActionResult> Insertcmo_analisa(Tr_CAS_AC_header Tr_CAS_AC_headerModel)
        {
            return Ok(await iCACar.Insertcmo_analisa(Tr_CAS_AC_headerModel));
        }

        [HttpGet("ef/get-Tr_CM_photo_detail")]
        public async Task<IActionResult> Get_Tr_CM_photo_detail(string credit_id, string photo_type_id, string photo_id)
        {
            return Ok(await iCACar.Get_Tr_CM_photo_detail(credit_id, photo_type_id, photo_id));
        }

        [HttpGet("ef/get-ms_photo_type")]
        public async Task<IActionResult> Get_ms_photo_type()
        {
            return Ok(await iCACar.Get_ms_photo_type());
        }

        [HttpGet("ef/get-ca_car_detail")]
        public async Task<IActionResult> Get_ca_car_detail(string credit_id, string CreatedBy)
        {
            return Ok(await iCACar.Get_ca_car_detail(credit_id, CreatedBy));
        }
    }
}