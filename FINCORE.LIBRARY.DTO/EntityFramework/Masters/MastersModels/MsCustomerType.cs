﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsCustomerType
    {
        public MsCustomerType()
        {
            MsIdentityType = new HashSet<MsIdentityType>();
        }

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
        /// kode tipe konsumen
        /// </summary>
        public string CustomerType { get; set; }
        /// <summary>
        /// deskripsi dari tipe konsumen
        /// </summary>
        public string CustomerTypeDescription { get; set; }
        /// <summary>
        /// indikator aktif atau tidaknya master data
        /// </summary>
        public bool IsActive { get; set; }

        public virtual ICollection<MsIdentityType> MsIdentityType { get; set; }
    }
}