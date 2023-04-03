using FINCORE.LIBRARY.DTO.Model.Acquisition.CAS;
using FINCORE.LIBRARY.DTO.Model.Acquisition.CAS.ModelHelper;
using FINCORE.SERVICE.CREDITS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.CREDITS.Controllers
{
    [Route("api/v1/services/acquisition/cas/")]
    [ApiController]
    public class TrCasController : ControllerBase
    {
        private readonly ITrCas iTrcas;

        public TrCasController(ITrCas _iTrCas)
        {
            this.iTrcas = _iTrCas;
        }

        [HttpPost("insert/motor")]
        public async Task<IActionResult> InsertTrCreditMotor([FromBody] TrCasModels trCredits)
        {
            return Ok(await iTrcas.InsertTrCasMotorAsync(trCredits));
        }

        [HttpPost("update/motor")]
        public async Task<IActionResult> UpdateTrCreditMotor([FromBody] TrCasModels trCredits)
        {
            var response = await iTrcas.UpdateTrCasMotorAsync(trCredits);
            return Ok(response);
        }

        [HttpPost("insert/car")]
        public async Task<IActionResult> InsertTrCreditCar([FromBody] TrCasModels trCredits)
        {
            var response = await iTrcas.InsertTrCasMobilAsync(trCredits);
            return Ok(response);
        }

        [HttpPost("update/car")]
        public async Task<IActionResult> UpdateTrCreditCar([FromBody] TrCasModels trCredits)
        {
            var response = await iTrcas.UpdateTrCasMobilAsync(trCredits);
            return Ok(response);
        }

        [HttpGet("ef/get/generatecode")]
        public async Task<IActionResult> GenerateCodeCreditId(string branchId)
        {
            var response = await iTrcas.GenerateCreditId(branchId);
            return Ok(response);
        }

        [HttpGet("ef/get/trcas")]
        public async Task<IActionResult> GetTrCasByCreditId(string creditid)
        {
            var response = await iTrcas.GetTrCasByCreditId(creditid);
            return Ok(response);
        }

        [HttpGet("get/bank")]
        public async Task<IActionResult> GetBankMasterAsync()
        {
            var response = await iTrcas.GetBankMasterAsync();
            return Ok(response);
        }

        [HttpGet("validasi/checkblacklistktp")]
        public async Task<IActionResult> CheckBlacklistKTPAsync(string ktpNo)
        {
            var response = await iTrcas.CheckBlacklistAsync(ktpNo);
            return Ok(response);
        }

        [HttpPost("validasi/checkapuppt")]
        public async Task<IActionResult> CheckApupptAsync([FromBody] ApupptParamModels apupptParam)
        {
            var response = await iTrcas.CheckApupptsAsync(apupptParam);
            return Ok(response);
        }

        [HttpGet("get/findcreditidbyorder")]
        public async Task<IActionResult> FindCreditIdByOrderId(string orderId)
        {
            var response = await iTrcas.FindCreditIdByOrderIdAsync(orderId);
            return Ok(response);
        }

        [HttpGet("ef/validasi/agreementold")]
        public async Task<IActionResult> GetNppLamaRO(string ktpNo)
        {
            var data = await iTrcas.GetNPPLamaROAsync(ktpNo);
            return Ok(data);
        }

        [HttpGet("get/poolingorder")]
        public async Task<IActionResult> GetDataPoolingOrder(string orderId)
        {
            var data = await iTrcas.GetDataPoolingOrderAsync(orderId);
            return Ok(data);
        }

        [HttpGet("get/datareferensi_slik")]
        public async Task<IActionResult> GetDataReferensiByNik(string nik)
        {
            var data = await iTrcas.CheckDataReferensiByNik(nik);
            return Ok(data);
        }

        [HttpGet("get/dealers_by_code")]
        public async Task<IActionResult> GetDealerByCode(string dealerCode)
        {
            var data = await iTrcas.GetDealerById(dealerCode);
            return Ok(data);
        }
    }
}