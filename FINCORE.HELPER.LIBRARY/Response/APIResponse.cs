namespace FINCORE.HELPER.LIBRARY.Response
{
    public class APIResponse
    {
        public int code { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public object? data { get; set; }

        public APIResponse(int code, string status, string message, object data)
        {
            this.code = code;
            this.status = status;
            this.message = message;
            this.data = data;
        }

        /// <summary>
        /// APIResponse for Success condition
        /// </summary>
        /// <param name="data">Response data</param>
        public APIResponse(object data)
        {
            this.code = Collection.Codes.SUCCESS;
            this.status = Collection.Status.SUCCESS;
            this.message = Collection.Messages.SUCCESS;
            this.data = data;
        }

        /// <summary>
        /// APIResponse for Failed condition with optional data
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="data">optional data (default: null)</param>
        public APIResponse(string message, object data)
        {
            this.code = Collection.Codes.INTERNAL_SERVER_ERROR;
            this.status = Collection.Status.FAILED;
            this.message = message;
            this.data = data;
        }

        /// <summary>
        /// APIResponse for Failed condition
        /// </summary>
        /// <param name="message">Error message</param>
        public APIResponse(string message)
        {
            this.code = Collection.Codes.INTERNAL_SERVER_ERROR;
            this.status = Collection.Status.FAILED;
            this.message = message;
            this.data = data;
        }
    }
}