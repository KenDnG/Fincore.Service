﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class sp_get_pagination_lookup_incentive_codeResult
    {
        public long? RowNumber { get; set; }
        [Column("Insentif ID")]
        public string InsentifID { get; set; }
        [Column("Tipe Perantara")]
        public string TipePerantara { get; set; }
        [Column("Is Dynamic")]
        public bool IsDynamic { get; set; }
    }
}