﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsPackageHeaderGiias
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
        /// ID paket
        /// </summary>
        public string PackageId { get; set; }
        /// <summary>
        /// nama paket
        /// </summary>
        public string PackageName { get; set; }
        /// <summary>
        /// tanggal mulai
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// tanggal berakhir
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// indikator apakah item baru atau tidak
        /// </summary>
        public int? IsItemNew { get; set; }
        /// <summary>
        /// ID tipe aplikasi
        /// </summary>
        public string ApplicationTypeId { get; set; }
        /// <summary>
        /// ID asuransi
        /// </summary>
        public string InsuranceId { get; set; }
        /// <summary>
        /// indikator aktif atau tidaknya master data
        /// </summary>
        public int IsActive { get; set; }
    }
}