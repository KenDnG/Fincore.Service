﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class TrPo
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
        /// nomor PO (purchase order)
        /// </summary>
        public string PoNo { get; set; }
        /// <summary>
        /// ID kredit
        /// </summary>
        public string CreditId { get; set; }
        /// <summary>
        /// tanggal PO (purchase order)
        /// </summary>
        public DateTime? PoDate { get; set; }
        /// <summary>
        /// ID perusahaan
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// ID cabang
        /// </summary>
        public string BranchId { get; set; }
        /// <summary>
        /// status PO (purchase order)
        /// </summary>
        public string StatusPo { get; set; }
        /// <summary>
        /// indikator print atau tidak
        /// </summary>
        public bool IsPrint { get; set; }
        /// <summary>
        /// jumlah berapa kali print
        /// </summary>
        public int SumOfPrint { get; set; }
        /// <summary>
        /// tanggal pertama print
        /// </summary>
        public DateTime? FirstPrintDate { get; set; }
        /// <summary>
        /// tanggal terakhir print
        /// </summary>
        public DateTime? LastPrintDate { get; set; }
        /// <summary>
        /// user pertama print
        /// </summary>
        public string FirstPrintBy { get; set; }
        /// <summary>
        /// user terakhir print
        /// </summary>
        public string LastPrintBy { get; set; }
    }
}