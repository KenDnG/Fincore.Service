﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class TrCmPriceAwal
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
        /// ID kredit
        /// </summary>
        public string CreditId { get; set; }
        /// <summary>
        /// lama angsuran
        /// </summary>
        public byte? Tenor { get; set; }
        /// <summary>
        /// harga/biaya aset
        /// </summary>
        public decimal? AssetCost { get; set; }
        /// <summary>
        /// uang muka gross
        /// </summary>
        public decimal? GrossDownPayment { get; set; }
        /// <summary>
        /// biaya admin
        /// </summary>
        public decimal? AdminFee { get; set; }
        /// <summary>
        /// biaya asuransi
        /// </summary>
        public decimal? InsuranceFee { get; set; }
        /// <summary>
        /// uang muka murni
        /// </summary>
        public decimal? NettDownPayment { get; set; }
        /// <summary>
        /// jumlah pembiayaan
        /// </summary>
        public decimal? JmlPembiayaan { get; set; }
        /// <summary>
        /// nilai angsuran
        /// </summary>
        public decimal? AmountInstallment { get; set; }
        /// <summary>
        /// nilai bunga
        /// </summary>
        public decimal? RateValue { get; set; }
        /// <summary>
        /// bunga efektif
        /// </summary>
        public decimal? EffectiveRate { get; set; }
        /// <summary>
        /// bunga flat
        /// </summary>
        public decimal? FlatRate { get; set; }
        /// <summary>
        /// persenan NFA
        /// </summary>
        public decimal? PersenNfa { get; set; }
        /// <summary>
        /// selisih bunga awal
        /// </summary>
        public decimal? MdpsAwal { get; set; }
        /// <summary>
        /// selisih bunga saat ini
        /// </summary>
        public decimal? MdpsCurr { get; set; }
        /// <summary>
        /// nominal subsidi
        /// </summary>
        public decimal? Subsidi { get; set; }
        /// <summary>
        /// nominal konversi OTR
        /// </summary>
        public decimal? TotalUppingOtr { get; set; }
        /// <summary>
        /// berapa kali konversi OTR
        /// </summary>
        public int? CountUppingOtr { get; set; }
        /// <summary>
        /// biaya administrasi dealer
        /// </summary>
        public decimal? DiscDeposit { get; set; }
        /// <summary>
        /// biaya provisi asuransi
        /// </summary>
        public decimal? BiayaProvisiIns { get; set; }
        /// <summary>
        /// tipe konversi
        /// </summary>
        public string TypeKonversi { get; set; }
    }
}