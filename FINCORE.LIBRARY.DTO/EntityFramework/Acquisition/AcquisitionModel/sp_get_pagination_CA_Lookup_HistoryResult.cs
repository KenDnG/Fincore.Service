﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class sp_get_pagination_CA_Lookup_HistoryResult
    {
        public string created_by { get; set; }
        public DateTime created_on { get; set; }
        public string last_updated_by { get; set; }
        public DateTime? last_updated_on { get; set; }
        public int company_id { get; set; }
        public string CF_No { get; set; }
        public string approval_scheme_id { get; set; }
        public string approval_level_id { get; set; }
        public string NIK { get; set; }
        public string policy_id { get; set; }
        public bool level_active { get; set; }
        public int level_quorum { get; set; }
        public string level_escalation_type { get; set; }
        public byte? level_escalation_day { get; set; }
        public DateTime? level_request_date { get; set; }
        public DateTime? level_complete_date { get; set; }
        public bool user_mandatory { get; set; }
        public DateTime? user_dtm_status_changed { get; set; }
        public string user_status_type { get; set; }
        public string user_keterangan_approval { get; set; }
        public string next_approval_level_id { get; set; }
        public byte? media_approve { get; set; }
        public bool is_notification { get; set; }
        public string nama { get; set; }
        public string approval_level_desc { get; set; }
        public string trans_type_id { get; set; }
        public string trans_type_desc { get; set; }
        public string StatusApproval { get; set; }
        public string Active { get; set; }
    }
}
