﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsInsuranceProportionR2
    {
        /// <summary>
        /// user yang membuat master data
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// tanggal &amp; waktu pembuatan master data
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// user yang mengubah master data
        /// </summary>
        public string LastUpdatedBy { get; set; }
        /// <summary>
        /// tanggal &amp; waktu perubahan master data
        /// </summary>
        public DateTime? LastUpdatedOn { get; set; }
        /// <summary>
        /// ID asuransi
        /// </summary>
        public string InsuranceId { get; set; }
        /// <summary>
        /// proporsi
        /// </summary>
        public int? Proportion { get; set; }
        /// <summary>
        /// posisi
        /// </summary>
        public int? Position { get; set; }
        /// <summary>
        /// melebihi kuota
        /// </summary>
        public int? OverQuota { get; set; }
        /// <summary>
        /// indikator aktif atau tidaknya master data
        /// </summary>
        public int? IsActive { get; set; }
    }
}