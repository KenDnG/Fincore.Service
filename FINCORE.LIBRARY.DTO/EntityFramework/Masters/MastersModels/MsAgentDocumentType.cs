﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsAgentDocumentType
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
        /// ID tipe agen
        /// </summary>
        public string AgentTypeId { get; set; }
        /// <summary>
        /// ID dokumen
        /// </summary>
        public string DocumentId { get; set; }
        /// <summary>
        /// ukuran file maksimum
        /// </summary>
        public int MaxFileSize { get; set; }
        /// <summary>
        /// indikator mandatory atau tidak
        /// </summary>
        public bool IsMandatory { get; set; }
        /// <summary>
        /// indikator aktif atau tidaknya master data
        /// </summary>
        public bool IsActive { get; set; }
    }
}