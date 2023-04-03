using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.Model.Acquisition.NPP;
using FINCORE.SERVICE.REPORT.Repositories.Interface;
//using System.Net;

namespace FINCORE.SERVICE.REPORT.Repositories.Acquisition
{
    public class NPPReportsRepository : INPP
    {
        private readonly AcquisitionContext acquisitionContext;

        public NPPReportsRepository(AcquisitionContext _acquisitionContext)
        {
            this.acquisitionContext = _acquisitionContext;
        }

        /// <summary>
        /// Dokumen Perjanjian Pembiayaan
        /// </summary>
        /// <param name="creditId"></param>
        /// <returns></returns>
        public async Task<APIResponse> PrintMemorandumOfUnderstanding(string creditId)
        {
            try
            {
                List<sp_print_npp_memorandum_of_understandingResult>? report =
                    await acquisitionContext.GetProcedures()
                    .sp_print_npp_memorandum_of_understandingAsync(creditId);

                if (report is not null && report.Count > 0)
                {
                    var reportData = report.FirstOrDefault();

                    if (reportData is not null)
                        return new APIResponse(reportData);

                }

                return DataNotFoundResponse();
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        /// <summary>
        /// Dokumen pemberitahuan penting
        /// </summary>
        /// <param name="creditId"></param>
        /// <returns></returns>
        public async Task<APIResponse> PrintImportantNotice(string creditId)
        {
            try
            {
                List<sp_print_npp_important_noticeResult>? report = 
                    await acquisitionContext.GetProcedures().sp_print_npp_important_noticeAsync(creditId);

                if (report is not null && report.Count > 0)
                {
                    var reportData = report.FirstOrDefault();

                    if (reportData is not null)
                        return new APIResponse(reportData);

                }

                return DataNotFoundResponse();
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        /// <summary>
        /// Dokumen Kuasa membebankan fidusia
        /// </summary>
        /// <param name="creditId"></param>
        /// <returns></returns>
        public async Task<APIResponse> PrintPowerOfAttorneyFidusia(string creditId)
        {
            try
            {
                List<sp_print_npp_power_of_attorney_fidusiaResult>? report = 
                    await acquisitionContext.GetProcedures().sp_print_npp_power_of_attorney_fidusiaAsync(creditId);

                if (report is not null && report.Count > 0)
                {
                    var reportData = report.FirstOrDefault();

                    if (reportData is not null)
                        return new APIResponse(reportData);
                }

                return DataNotFoundResponse();
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<APIResponse> PrintPowerOfAttorney(string creditId)
        {
            try
            {
                List<sp_print_npp_power_of_attorneyResult>? report = 
                    await acquisitionContext.GetProcedures().sp_print_npp_power_of_attorneyAsync(creditId);

                if (report is not null && report.Count > 0)
                {
                    var reportData = report.FirstOrDefault();

                    if (reportData is not null)
                        return new APIResponse(reportData);
                }

                return DataNotFoundResponse();
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<APIResponse> PrintStatementLetter(string creditId)
        {
            try
            {
                List<sp_print_npp_statement_letterResult>? report =
                    await acquisitionContext.GetProcedures().sp_print_npp_statement_letterAsync(creditId);

                if (report is not null && report.Count > 0)
                {
                    var reportData = report.FirstOrDefault();

                    if (reportData is not null)
                        return new APIResponse(reportData);
                }

                return DataNotFoundResponse();
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<APIResponse> PrintSecondStatementLetter(string creditId)
        {
            try
            {
                List<sp_print_npp_second_statement_letterResult>? report = 
                    await acquisitionContext.GetProcedures().sp_print_npp_second_statement_letterAsync(creditId);

                if (report is not null && report.Count > 0)
                {
                    var reportData = report.FirstOrDefault();

                    if (reportData is not null)
                        return new APIResponse(reportData);
                }

                return DataNotFoundResponse();
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        internal async Task<APIResponse> PrintApprovalLetter(string creditId)
        {
            try
            {
                List<sp_print_npp_approval_letterResult> result = 
                    await acquisitionContext.GetProcedures().sp_print_npp_approval_letterAsync(creditId);

                if (result is not null && result.Count > 0)
                {
                    var reportData = result.FirstOrDefault();

                    if (reportData is not null)
                        return new APIResponse(reportData);

                }

                return DataNotFoundResponse();
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<APIResponse> PrintConsumentStatementLetter(string creditId)
        {
            try
            {
                List<sp_print_npp_consument_statement_letterResult>? report = 
                    await acquisitionContext.GetProcedures().sp_print_npp_consument_statement_letterAsync(creditId);

                if (report is not null && report.Count > 0)
                {
                    var reportData = report.FirstOrDefault();

                    if (reportData is not null)
                        return new APIResponse(reportData);

                }

                return DataNotFoundResponse();
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<APIResponse> PrintNameChangeStatementLetter(string creditId)
        {
            try
            {

                //check if data is used car or motorbike
                byte? result = acquisitionContext.TrCm
                                .Where(cm=>cm.CreditId==creditId)
                                .Select(cm=>cm.IsItemNew)
                                .FirstOrDefault();

                var isBrandNew = Convert.ToBoolean(result);

                //if brand new return no content
                //if (isBrandNew)
                    //return ForbiddenResponse();

                List<sp_print_npp_name_change_statement_letterResult>? report = 
                    await acquisitionContext.GetProcedures().sp_print_npp_name_change_statement_letterAsync(creditId);


                if (report is not null && report.Count > 0)
                {
                    var reportData = report.FirstOrDefault();

                    if (reportData is not null) 
                    {
                       return new APIResponse(reportData);
                    }                       

                }

                return DataNotFoundResponse();
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<APIResponse> PrintNameChangeReceipt(string creditId)
        {
            try
            {
                List<sp_print_npp_name_change_receiptResult>? report = 
                    await acquisitionContext.GetProcedures().sp_print_npp_name_change_receiptAsync(creditId);

                if (report is not null && report.Count > 0)
                {
                    var reportData = report.FirstOrDefault();

                    if (reportData is not null)
                        return new APIResponse(reportData);

                }

                return DataNotFoundResponse();
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        internal async Task<APIResponse> LogNppPrint(TrNppPrintRequest trNppPrintRequest)
        {
            try
            {

                int result = await acquisitionContext
                    .GetProcedures()
                    .sp_print_npp_log_insertAsync(
                        trNppPrintRequest.CreditId,
                        trNppPrintRequest.IsPrintPK,
                        trNppPrintRequest.IsPrintPK ? DateTime.Now:null,
                        trNppPrintRequest.IsPrintPK ? trNppPrintRequest.UserName: null,
                        trNppPrintRequest.IsPrintAkad,
                        trNppPrintRequest.IsPrintAkad ? DateTime.Now : null,
                        trNppPrintRequest.IsPrintAkad ? trNppPrintRequest.UserName : null,
                        trNppPrintRequest.IsPrintFidusia,
                        trNppPrintRequest.IsPrintFidusia ? DateTime.Now : null,
                        trNppPrintRequest.IsPrintFidusia ? trNppPrintRequest.UserName : null                       
                     );


                if (result > 0)
                    return new APIResponse
                        (
                            Collection.Codes.SUCCESS,
                            Collection.Status.SUCCESS,
                            Collection.Messages.SUCCESS,
                            new { }
                        );


                return DataNotFoundResponse();
            }
            catch (Exception ex)
            {
                return new APIResponse
                    (
                        Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                        new { }
                    );
            }
        }

        private static APIResponse DataNotFoundResponse()
        {
            return new APIResponse
                (
                    Collection.Codes.NOT_FOUND,
                    Collection.Status.FAILED,
                    Collection.Messages.NOT_FOUND,
                    new { }
                );
        }

        private static APIResponse ForbiddenResponse()
        {
            return new APIResponse
                (
                    Collection.Codes.FORBIDDEN,
                    Collection.Status.FAILED,
                    Collection.Messages.FORBIDDEN,
                    new { }
                );
        }

        private static APIResponse InternalErrorResponse(Exception ex)
        {
            return new APIResponse
                (
                    Collection.Codes.INTERNAL_SERVER_ERROR,
                    Collection.Status.FAILED,
                    $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                    new { }
                );
        }

    }
}