﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class sp_update_status_approval_vertelResult
    {
        public string user_name { get; set; }
        public int? error_number { get; set; }
        public int? error_state { get; set; }
        public string error_message { get; set; }
        public string error_procedure { get; set; }
        public DateTime error_date_time { get; set; }
    }
}
