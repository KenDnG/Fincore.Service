﻿namespace FINCORE.LIBRARY.DTO.Model.Response
{
    public class ErrorModel
    {
        public string user_name { get; set; }
        public int? error_number { get; set; }
        public int? error_state { get; set; }
        public string error_message { get; set; }
        public string error_procedure { get; set; }
        public DateTime error_date_time { get; set; }
    }
}