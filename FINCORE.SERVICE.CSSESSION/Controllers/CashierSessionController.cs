using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentModel;
using FINCORE.SERVICE.CSSESSION.DTO;
using FINCORE.SERVICE.CSSESSION.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.CSSESSION.Controllers
{
    [Route("api/v1/services/payment/cashiersession/")]
    [ApiController]
    public sealed class CashierSessionController : ControllerBase
    {
        private readonly ICashierSessionRepository _sessionRepository;

        public CashierSessionController(ICashierSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCashierSession([FromQuery]QueryParamDTO queryParams)
        {

            if (ModelState.IsValid)
            {
                APIResponse result = await _sessionRepository.GetCashierSessionAsync(queryParams);

                if (result.code == StatusCodes.Status500InternalServerError)
                    return StatusCode(statusCode: StatusCodes.Status500InternalServerError, result);                    

                return Ok(result);
            }

            return BadRequest(new APIResponse(
                    Collection.Codes.BAD_REQUEST,
                    Collection.Status.FAILED,
                    "One of input not valid",
                    new { }));

        }

        [HttpPost]
        public async Task<IActionResult> InsertCashierSession(InsertCashierSessionDTO insertCashierSessionDTO) 
        {
            if (ModelState.IsValid)
            {
                var cashierSessionEntity = MapDTOTOEntity(insertCashierSessionDTO);
               

                var sessionId = insertCashierSessionDTO.GetSessionId();

                bool hasOpenedCashierSession = false;

                if (insertCashierSessionDTO.BranchId is not null)    
                    hasOpenedCashierSession = await _sessionRepository.GetOpenedCashierSesionAsync(insertCashierSessionDTO.BranchId);

                if (hasOpenedCashierSession) 
                {
                    return BadRequest(new APIResponse(
                                                    Collection.Codes.FORBIDDEN,
                                                    Collection.Status.FAILED,
                                                    "Has Open Session",
                                                    new { }));
                }   
                

                var lastTodayCashierSession = 
                    await _sessionRepository.GetCashierSessionAsync(sessionId);

                if (lastTodayCashierSession.data is not null)
                {

                    TrCashierSession cashierSession = (TrCashierSession)lastTodayCashierSession.data;

                    //create new session
                    //get two last digit (uniqueNumber)
                    int sessionLength = cashierSession.SessionId.Length;
                    int uniqueNumber = int.Parse( cashierSession.SessionId.Substring(sessionLength - 2, 2));
                    uniqueNumber++;

                    string uniqueNumberString = uniqueNumber.ToString();

                    if (uniqueNumberString.Length < 2)
                    {
                        uniqueNumberString = "0" + uniqueNumberString;
                    }

                    cashierSessionEntity.SessionId = sessionId + uniqueNumberString;

                }
                else 
                {
                    cashierSessionEntity.SessionId = sessionId + "01";
                }

                APIResponse result = await _sessionRepository.InsertCashierSessionAsync(cashierSessionEntity);
                if (result.code == Collection.Codes.SUCCESS)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest( new APIResponse(
                    Collection.Codes.BAD_REQUEST,
                    Collection.Status.FAILED,
                    "One of input not valid",
                    new { }));
           
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCashierSession(UpdateCashierSessionDTO updateCashierSessionDTO) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _sessionRepository.CloseCashierSessionAsync(updateCashierSessionDTO);

                    return result.code switch
                    {

                        400 => BadRequest(result),
                        403 => StatusCode(StatusCodes.Status403Forbidden, new APIResponse(
                                        Collection.Codes.FORBIDDEN,
                                        Collection.Status.FAILED,
                                        result.message,
                                        new { })),

                        500 => StatusCode(StatusCodes.Status500InternalServerError, new APIResponse(
                                        Collection.Codes.INTERNAL_SERVER_ERROR,
                                        Collection.Status.FAILED,
                                        result.message,
                                        new { })),
                        _ => Ok(result),
                    };

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new APIResponse(
                                        Collection.Codes.INTERNAL_SERVER_ERROR,
                                        Collection.Status.FAILED,
                                        ex.Message,
                                        new { }));
                }
            }

            return BadRequest(new APIResponse(
                                        Collection.Codes.BAD_REQUEST,
                                        Collection.Status.FAILED,
                                        "One of input not valid",
                                        new { }));
        }

        private static TrCashierSession MapDTOTOEntity(InsertCashierSessionDTO insertCashierSessionDTO)
        {
            return new TrCashierSession 
            {
                BranchId = insertCashierSessionDTO.BranchId,
                CashAmount = 0,
                CloseAmount = 0,  
                CreatedBy = insertCashierSessionDTO.UserName,
                CreatedOn = DateTime.Now, 
                LastUpdatedBy = insertCashierSessionDTO.UserName,
                LastUpdatedOn = DateTime.Now,
                CurrentAmount = 0,
                OpenDate = DateTime.Now,
                UserId = insertCashierSessionDTO.UserId          
                
            };
        }
    }
}
