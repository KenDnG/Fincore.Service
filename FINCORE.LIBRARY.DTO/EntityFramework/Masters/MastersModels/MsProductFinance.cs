﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsProductFinance
    {
        /// <summary>
        /// user yang membuat master data
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// tanggal &amp; waktu pembuatan master data
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// user yang mengubah master data
        /// </summary>
        public DateTime? LastUpdatedOn { get; set; }
        /// <summary>
        /// tanggal &amp; waktu perubahan master data
        /// </summary>
        public string LastUpdatedBy { get; set; }
        /// <summary>
        /// ID produk finance
        /// </summary>
        public string ProductFinanceId { get; set; }
        /// <summary>
        /// nama produk finance
        /// </summary>
        public string ProductFinanceName { get; set; }
        /// <summary>
        /// indikator aktif atau tidaknya master data
        /// </summary>
        public bool? IsActive { get; set; }
    }
}