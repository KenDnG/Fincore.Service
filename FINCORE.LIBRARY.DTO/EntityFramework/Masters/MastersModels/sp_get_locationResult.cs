﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class sp_get_locationResult
    {
        public int location_id { get; set; }
        public string zip_code { get; set; }
        public string village_name { get; set; }
        public string regency_name { get; set; }
        public int? DT2_Type { get; set; }
        public string district_name { get; set; }
        public string province_name { get; set; }
    }
}
