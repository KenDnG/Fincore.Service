namespace FINCORE.HELPER.LIBRARY.Response
{
    public static class Collection
    {
        public struct Codes
        {
            public static readonly int SUCCESS = 200;
            public static readonly int CREATED = 201;
            public static readonly int NO_CONTENT = 204;

            public static readonly int BAD_REQUEST = 400;
            public static readonly int UNAUTHORIZED = 401;
            public static readonly int FORBIDDEN = 403;
            public static readonly int NOT_FOUND = 404;
            public static readonly int METHOD_NOT_ALLOWED = 405;
            public static readonly int REQUEST_TIMEOUT = 408;
            public static readonly int UNSUPPORTED_MEDIA_TYPE = 415;
            public static readonly int UNPROCESSABLE_ENTITY = 422;
            public static readonly int LOCKED = 423;
            public static readonly int TO_MANY_REQUESTS = 429;



            public static readonly int INTERNAL_SERVER_ERROR = 500;
            public static readonly int BAD_GATEWAY = 502;
            public static readonly int SERVICE_UNAVAILABLE = 503;
            public static readonly int GATEWAY_TIMEOUT = 504;
        }

        public struct Messages
        {
            public static readonly string SUCCESS = "OK";
            public static readonly string CREATED = "Created";
            public static readonly string UPDATED = "Updated";
            public static readonly string NO_CONTENT = "No Content";
            public static readonly string UNPROCESSABLE_ENTITY = "Unprocessable Entity";
            

            public static readonly string BAD_REQUEST = "Bad Request";
            public static readonly string UNAUTHORIZED = "Unauthorized";
            public static readonly string FORBIDDEN = "Forbidden";
            public static readonly string NOT_FOUND = "Not Found";
            public static readonly string METHOD_NOT_ALLOWED = "Method Not Allowed";
            public static readonly string REQUEST_TIMEOUT = "Request Timeout";
            public static readonly string UNSUPPORTED_MEDIA_TYPE = "Unsupported Media Type";
            public static readonly string LOCKED = "Locked";
            public static readonly string TO_MANY_REQUESTS = "To Many Request";

            public static readonly string INTERNAL_SERVER_ERROR = "Internal Server Error";
            public static readonly string BAD_GATEWAY = "Bad Gateway";
            public static readonly string SERVICE_UNAVAILABLE = "Service Unavailable";
            public static readonly string GATEWAY_TIMEOUT = "Gateway Timeout";
            public static readonly string TRANSACTION_ROLLBACK = "Transaction has been rollback.";
        }

        public struct Status
        {
            public static readonly string SUCCESS = "Success";
            public static readonly string FAILED = "Failed";
        }

        public struct ErrorState
        {
            public static readonly int NOT_ERROR = 0;
            public static readonly int ERROR = 1;
        }
    }
}