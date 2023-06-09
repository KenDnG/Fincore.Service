﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class TrCasAcDetail
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
        public int Id { get; set; }
        /// <summary>
        /// ID kredit
        /// </summary>
        public string CreditId { get; set; }
        /// <summary>
        /// nomor dokumen
        /// </summary>
        public string DocumentNo { get; set; }
        /// <summary>
        /// ID tipe foto
        /// </summary>
        public string PhotoTypeId { get; set; }
        /// <summary>
        /// ID foto
        /// </summary>
        public string PhotoId { get; set; }
        /// <summary>
        /// nama file
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// path/lokasi file
        /// </summary>
        public string FilePath { get; set; }
    }
}