﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsDealer
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
        /// indikator dealer resmi atau tidak
        /// </summary>
        public bool IsAuthorizedDealer { get; set; }
        /// <summary>
        /// indikator dealer hanya menjual produk baru atau tidak
        /// </summary>
        public bool IsSellingNewProductOnly { get; set; }
        /// <summary>
        /// id jenis produk aset
        /// </summary>
        public string ProductAssetKindId { get; set; }
        /// <summary>
        /// merek item
        /// </summary>
        public string ItemMerk { get; set; }
        /// <summary>
        /// induk dealer
        /// </summary>
        public string DealerParent { get; set; }
        /// <summary>
        /// id dealer utama
        /// </summary>
        public string MainDealerId { get; set; }
        /// <summary>
        /// id grup dealer
        /// </summary>
        public string DealerGroupId { get; set; }
        /// <summary>
        /// jabatan orang yang dapat dihubungi
        /// </summary>
        public int ContactPersonJobTitle { get; set; }
        /// <summary>
        /// nama pemilik
        /// </summary>
        public string OwnerName { get; set; }
        /// <summary>
        /// orang yang dapat dihubungi
        /// </summary>
        public string ContactPerson { get; set; }
        /// <summary>
        /// nomor KTP
        /// </summary>
        public string KtpNo { get; set; }
        /// <summary>
        /// nama sesuai KTP
        /// </summary>
        public string KtpName { get; set; }
        /// <summary>
        /// alamat sesuai KTP
        /// </summary>
        public string KtpAddress { get; set; }
        /// <summary>
        /// alamat
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// ID lokasi
        /// </summary>
        public string LocationId { get; set; }
        /// <summary>
        /// nomor telepon
        /// </summary>
        public string TelephoneNumber { get; set; }
        /// <summary>
        /// nomor handphone
        /// </summary>
        public string MobilePhoneNumber { get; set; }
        /// <summary>
        /// nomor fax
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// nomor nota kesepakatan
        /// </summary>
        public string MouNo { get; set; }
        /// <summary>
        /// tanggal nota kesepakatan
        /// </summary>
        public DateTime? MouDate { get; set; }
        /// <summary>
        /// indikator ada biaya bank atau tidak
        /// </summary>
        public bool? IsBankCharges { get; set; }
        /// <summary>
        /// indikator apakah pembayaran sebelum jatuh tempo atau tidak
        /// </summary>
        public bool? IsPaymentBeforeDue { get; set; }
        /// <summary>
        /// nomor NPWP
        /// </summary>
        public string NpwpNo { get; set; }
        /// <summary>
        /// nama sesuai NPWP
        /// </summary>
        public string NpwpName { get; set; }
        /// <summary>
        /// alamat sesuai NPWP
        /// </summary>
        public string NpwpAddress { get; set; }
        /// <summary>
        /// tipe NPWP
        /// </summary>
        public string NpwpType { get; set; }
        /// <summary>
        /// indikator pembayaran di muka atau tidak
        /// </summary>
        public bool? IsPrepayment { get; set; }
        /// <summary>
        /// pembayaran di muka
        /// </summary>
        public decimal? Prepayment { get; set; }
        /// <summary>
        /// catatan
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// indikator mobil bekas atau tidak
        /// </summary>
        public bool? IsUsedCar { get; set; }
        /// <summary>
        /// status dari dealer
        /// </summary>
        public string StatusDealer { get; set; }
        /// <summary>
        /// tanggal aktivasi
        /// </summary>
        public DateTime? ActivationDate { get; set; }
        /// <summary>
        /// tanggal deaktivasi
        /// </summary>
        public DateTime? DeactivationDate { get; set; }
        /// <summary>
        /// tingkat pengembalian dana
        /// </summary>
        public decimal RateRefund { get; set; }
        /// <summary>
        /// PKP kumulatif
        /// </summary>
        public decimal? PkpCumulative { get; set; }
        /// <summary>
        /// status dari tingkat pengembalian dana
        /// </summary>
        public string StatusRateRefund { get; set; }
        /// <summary>
        /// file MP master dealer
        /// </summary>
        public string MpMasterDealerFile { get; set; }
        /// <summary>
        /// file SIUP
        /// </summary>
        public string SiupFile { get; set; }
        /// <summary>
        /// file TDP NIB
        /// </summary>
        public string TdpNibFile { get; set; }
        /// <summary>
        /// file NPWP
        /// </summary>
        public string NpwpFile { get; set; }
        /// <summary>
        /// file KTP
        /// </summary>
        public string KtpOwnerFile { get; set; }
        /// <summary>
        /// file buku akun SPT
        /// </summary>
        public string SptAccountBookFile { get; set; }
        /// <summary>
        /// indikator sinkron atau tidak
        /// </summary>
        public bool? IsSync { get; set; }
        /// <summary>
        /// ID merek asset
        /// </summary>
        public string AssetBrandId { get; set; }
    }
}