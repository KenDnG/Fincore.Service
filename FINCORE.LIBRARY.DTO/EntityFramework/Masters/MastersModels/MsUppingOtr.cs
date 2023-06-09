﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsUppingOtr
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
        /// ID item
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// ID merk item
        /// </summary>
        public string ItemMerkId { get; set; }
        /// <summary>
        /// ID tipe merk item
        /// </summary>
        public string ItemMerkTypeId { get; set; }
        /// <summary>
        /// nilai maksimum
        /// </summary>
        public decimal? MaxValue { get; set; }
        /// <summary>
        /// nilai kenaikan
        /// </summary>
        public decimal? UppingValue { get; set; }
        /// <summary>
        /// indikator aktif atau tidaknya master data
        /// </summary>
        public int? IsActive { get; set; }
    }
}