﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsAssetMapping
    {
        /// <summary>
        /// user yang membuat master data
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// tanggal &amp; waktu pembuatan master data
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// user yang mengubah master data
        /// </summary>
        public string LastUpdatedBy { get; set; }
        /// <summary>
        /// tanggal &amp; waktu perubahan master data
        /// </summary>
        public DateTime? LastUpdatedOn { get; set; }
        /// <summary>
        /// ID tipe aset
        /// </summary>
        public string AssetTypeId { get; set; }
        /// <summary>
        /// ID warna kendaraan
        /// </summary>
        public string VehicleColorId { get; set; }
        /// <summary>
        /// ID cc kendaraan
        /// </summary>
        public string VehicleCcId { get; set; }
        /// <summary>
        /// ID pemetaan aset
        /// </summary>
        public string AssetMappingId { get; set; }
        /// <summary>
        /// deskripsi dari pemetaan aset
        /// </summary>
        public string AssetMappingDescription { get; set; }
        /// <summary>
        /// indikator aktif atau tidaknya master data
        /// </summary>
        public bool IsActive { get; set; }
    }
}