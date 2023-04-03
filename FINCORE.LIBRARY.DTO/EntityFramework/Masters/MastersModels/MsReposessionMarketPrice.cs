﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsReposessionMarketPrice
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
        /// ID harga pasar
        /// </summary>
        public string MarketPriceId { get; set; }
        /// <summary>
        /// ID cabang
        /// </summary>
        public string BranchId { get; set; }
        /// <summary>
        /// tahun
        /// </summary>
        public string Tahun { get; set; }
        /// <summary>
        /// nominal harga
        /// </summary>
        public decimal? Harga { get; set; }
        /// <summary>
        /// sumber pembuatan
        /// </summary>
        public string SourceCreate { get; set; }
        /// <summary>
        /// deskripsi pembuatan
        /// </summary>
        public string DeskripsiCreate { get; set; }
        /// <summary>
        /// sumber update
        /// </summary>
        public string SourceUpdate { get; set; }
        /// <summary>
        /// deskripsi update
        /// </summary>
        public string DeskripsiUpdate { get; set; }
        /// <summary>
        /// ID tipe merk item baru
        /// </summary>
        public string ItemMerkTypeIdBaru { get; set; }
        /// <summary>
        /// status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// nominal harga 2
        /// </summary>
        public decimal? Harga2 { get; set; }
        /// <summary>
        /// ID log
        /// </summary>
        public int? LogId { get; set; }
    }
}