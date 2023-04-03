﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsDealerTax
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
        /// kode dealer
        /// </summary>
        public string DealerCode { get; set; }
        /// <summary>
        /// nama dealer
        /// </summary>
        public string DealerName { get; set; }
        /// <summary>
        /// tipe pajak PPh
        /// </summary>
        public string PphType { get; set; }
        /// <summary>
        /// tipe pajak PPN
        /// </summary>
        public string PpnType { get; set; }
        /// <summary>
        /// tanggal mulai
        /// </summary>
        public DateTime StartDate { get; set; }
    }
}