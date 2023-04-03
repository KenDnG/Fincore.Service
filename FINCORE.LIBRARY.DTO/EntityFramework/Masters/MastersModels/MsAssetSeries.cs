﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsAssetSeries
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
        /// ID seri aset
        /// </summary>
        public string AssetSeriesId { get; set; }
        /// <summary>
        /// ID merk aset
        /// </summary>
        public string AssetBrandId { get; set; }
        /// <summary>
        /// ID jenis aset
        /// </summary>
        public string AssetKindId { get; set; }
        /// <summary>
        /// ID kelas jenis aset
        /// </summary>
        public string AssetKindClassId { get; set; }
        /// <summary>
        /// deskripsi dari seri aset
        /// </summary>
        public string AssetSeriesDescription { get; set; }
        /// <summary>
        /// indikator aktif atau tidaknya master data
        /// </summary>
        public bool IsActive { get; set; }
    }
}