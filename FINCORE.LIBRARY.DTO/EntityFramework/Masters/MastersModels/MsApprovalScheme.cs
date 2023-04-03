﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsApprovalScheme
    {
        public MsApprovalScheme()
        {
            MsApprovalLevel = new HashSet<MsApprovalLevel>();
        }

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
        /// ID tipe transaksi
        /// </summary>
        public string TransTypeId { get; set; }
        /// <summary>
        /// ID skema approval
        /// </summary>
        public string ApprovalSchemeId { get; set; }
        /// <summary>
        /// deskripsi skema approval
        /// </summary>
        public string ApprovalSchemeDesc { get; set; }
        /// <summary>
        /// tanggal mulai
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// tanggal selesai
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// indikator aktif atau tidaknya master data
        /// </summary>
        public bool IsActive { get; set; }

        public virtual ICollection<MsApprovalLevel> MsApprovalLevel { get; set; }
    }
}