﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class TrVerificationCustomer
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
        /// status verifikasi konsumen
        /// </summary>
        public string VerificationStatus { get; set; }
        /// <summary>
        /// nomor telepon konsumen
        /// </summary>
        public int? ContactedOption { get; set; }
        /// <summary>
        /// tanggal terima tagihan
        /// </summary>
        public DateTime? BillingDate { get; set; }
        /// <summary>
        /// tanggal konfirmasi
        /// </summary>
        public DateTime? ConfirmationDate { get; set; }
        /// <summary>
        /// jam konfirmasi
        /// </summary>
        public string ConfirmationTime { get; set; }
        /// <summary>
        /// tanggal approve NPP
        /// </summary>
        public DateTime? ApprovedDateNpp { get; set; }
        /// <summary>
        /// opsi tanggal terima kendaraan (sesuai/tidak sesuai)
        /// </summary>
        public bool? OptionItemReceivedDate { get; set; }
        /// <summary>
        /// tanggal terima kendaraan sebenarnya
        /// </summary>
        public DateTime? OptionItemReceivedDateReal { get; set; }
        /// <summary>
        /// opsi tipe kendaraan (sesuai/tidak sesuai)
        /// </summary>
        public bool? OptionItemType { get; set; }
        /// <summary>
        /// tipe kendaraan sebenarnya
        /// </summary>
        public string OptionItemTypeReal { get; set; }
        /// <summary>
        /// opsi angsuran (sesuai/tidak sesuai)
        /// </summary>
        public bool? OptionInstallment { get; set; }
        /// <summary>
        /// angsuran sebenarnya
        /// </summary>
        public decimal? OptionInstallmentReal { get; set; }
        /// <summary>
        /// opsi tenor (sesuai/tidak sesuai)
        /// </summary>
        public bool? OptionTenor { get; set; }
        /// <summary>
        /// tenor sebenarnya
        /// </summary>
        public int? OptionTenorReal { get; set; }
        /// <summary>
        /// nama penerima kendaraan
        /// </summary>
        public string ItemReceiverName { get; set; }
        /// <summary>
        /// hubungan penerima kendaraan
        /// </summary>
        public string ItemReceiverRelation { get; set; }
        /// <summary>
        /// opsi pencairan UMC (sesuai/tidak sesuai)
        /// </summary>
        public bool? OptionDisbursementUmc { get; set; }
        /// <summary>
        /// pencairan UMC sebenarnya
        /// </summary>
        public decimal? OptionDisbursementUmcReal { get; set; }
        /// <summary>
        /// opsi pembayaran konsumen (sesuai/tidak sesuai)
        /// </summary>
        public bool? OptionConsumenPayment { get; set; }
        /// <summary>
        /// pembayaran konsumen sebenarnya
        /// </summary>
        public decimal? OptionConsumenPaymentReal { get; set; }
        /// <summary>
        /// opsi biaya admin lainnya
        /// </summary>
        public bool? AdminFeeOther { get; set; }
        /// <summary>
        /// jumlah nominal biaya admin lainnya
        /// </summary>
        public decimal? AdminFeeOtherAmount { get; set; }
        /// <summary>
        /// jatuh tempo
        /// </summary>
        public string RequestOfDueDate { get; set; }
        /// <summary>
        /// catatan lain
        /// </summary>
        public string OtherNotes { get; set; }
    }
}