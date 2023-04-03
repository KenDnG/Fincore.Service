﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class TrCm
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
        /// tanggal kredit
        /// </summary>
        public DateTime? CreditDate { get; set; }
        /// <summary>
        /// kode produk finance
        /// </summary>
        public string FinCode { get; set; }
        /// <summary>
        /// pemilik STNK
        /// </summary>
        public string IsQq { get; set; }
        /// <summary>
        /// nama STNK
        /// </summary>
        public string QqName { get; set; }
        /// <summary>
        /// kode dealer
        /// </summary>
        public string DealerCode { get; set; }
        /// <summary>
        /// lama angsuran
        /// </summary>
        public int? Tenor { get; set; }
        /// <summary>
        /// tipe account receivable
        /// </summary>
        public string AccountReceiveable { get; set; }
        /// <summary>
        /// ID angsuran
        /// </summary>
        public string InstallmentId { get; set; }
        /// <summary>
        /// harga/biaya aset
        /// </summary>
        public decimal? AssetCost { get; set; }
        /// <summary>
        /// uang muka gross
        /// </summary>
        public decimal? GrossDownPayment { get; set; }
        /// <summary>
        /// biaya administrasi dealer
        /// </summary>
        public decimal? DiscDeposit { get; set; }
        /// <summary>
        /// deposit angsuran
        /// </summary>
        public int? DepositInstallment { get; set; }
        /// <summary>
        /// nominal deposit
        /// </summary>
        public decimal? Deposit { get; set; }
        /// <summary>
        /// nilai angsuran
        /// </summary>
        public decimal? AmountInstallment { get; set; }
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
        /// nilai bunga
        /// </summary>
        public decimal? RateValue { get; set; }
        /// <summary>
        /// bunga efektif
        /// </summary>
        public double? EffectiveRate { get; set; }
        /// <summary>
        /// bunga flat
        /// </summary>
        public double? FlatRate { get; set; }
        /// <summary>
        /// bunga OD
        /// </summary>
        public double? OverdueRate { get; set; }
        /// <summary>
        /// ID item
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// ID merk item
        /// </summary>
        public string ItemMerkId { get; set; }
        /// <summary>
        /// ID tipe merk item
        /// </summary>
        public string ItemMerkTypeId { get; set; }
        /// <summary>
        /// tahun kendaraan
        /// </summary>
        public string YearItem { get; set; }
        /// <summary>
        /// ID produk
        /// </summary>
        public int? ProductId { get; set; }
        /// <summary>
        /// tanggal selesai
        /// </summary>
        public DateTime? FinishDate { get; set; }
        /// <summary>
        /// status approval
        /// </summary>
        public string StatusApproval { get; set; }
        /// <summary>
        /// tipe biaya administrasi dealer
        /// </summary>
        public string DiscType { get; set; }
        /// <summary>
        /// ongkos penagihan
        /// </summary>
        public decimal? OngkosTagih { get; set; }
        /// <summary>
        /// ongkos biaya balik nama
        /// </summary>
        public decimal? OngkosBbn { get; set; }
        /// <summary>
        /// indikator kendaraan baru atau tidak
        /// </summary>
        public byte? IsItemNew { get; set; }
        /// <summary>
        /// nama saluran
        /// </summary>
        public string ChannelName { get; set; }
        /// <summary>
        /// status kredit
        /// </summary>
        public string StatusCredit { get; set; }
        /// <summary>
        /// indikator tutup buka atau tidak
        /// </summary>
        public string IsTutupBuka { get; set; }
        /// <summary>
        /// deskripsi approval
        /// </summary>
        public string ApprovalDescription { get; set; }
        /// <summary>
        /// ID tipe aplikasi
        /// </summary>
        public string ApplicationTypeId { get; set; }
        /// <summary>
        /// alasan RFA
        /// </summary>
        public DateTime? ReasonRfa { get; set; }
        /// <summary>
        /// periode tertagih
        /// </summary>
        public bool? CollectiblePeriod { get; set; }
        /// <summary>
        /// periode urutan tertagih
        /// </summary>
        public string CollectibleSequencePeriod { get; set; }
        /// <summary>
        /// nominal OP
        /// </summary>
        public decimal? Op { get; set; }
        /// <summary>
        /// nominal ULI
        /// </summary>
        public decimal? Uli { get; set; }
        /// <summary>
        /// nominal LCR
        /// </summary>
        public decimal? Lcr { get; set; }
        /// <summary>
        /// nominal OP awal
        /// </summary>
        public decimal? FirstOp { get; set; }
        /// <summary>
        /// nominal ULI awal
        /// </summary>
        public decimal? FirstUli { get; set; }
        /// <summary>
        /// nominal LCR awal
        /// </summary>
        public decimal? FirstLcr { get; set; }
        /// <summary>
        /// user yang menyetujui
        /// </summary>
        public string ApprovedBy { get; set; }
        /// <summary>
        /// tanggal disetujui
        /// </summary>
        public DateTime? ApprovedDate { get; set; }
        /// <summary>
        /// indikator dikonversi atau tidak
        /// </summary>
        public string IsConvert { get; set; }
        /// <summary>
        /// tanggal bayar terakhir
        /// </summary>
        public string LastPayDate { get; set; }
        /// <summary>
        /// ID area collection konsumen
        /// </summary>
        public string AreaCollectionKonsId { get; set; }
        /// <summary>
        /// indikator milik PT atau tidak
        /// </summary>
        public bool? IsMilikPt { get; set; }
        /// <summary>
        /// sumber PO
        /// </summary>
        public string PoSource { get; set; }
        /// <summary>
        /// sumber lain PO
        /// </summary>
        public string PoSourceOther { get; set; }
        /// <summary>
        /// NIK collector
        /// </summary>
        public string NikCollectionCode { get; set; }
        /// <summary>
        /// NIK surveyor
        /// </summary>
        public string NikSurveryorCode { get; set; }
        /// <summary>
        /// ID kanal
        /// </summary>
        public string ChannelId { get; set; }
        /// <summary>
        /// ID produk marketing
        /// </summary>
        public string ProductMarketingId { get; set; }
        /// <summary>
        /// user yang mengkoreksi
        /// </summary>
        public string UsrCorrection { get; set; }
        /// <summary>
        /// tanggal koreksi
        /// </summary>
        public string DtmCorrection { get; set; }
        /// <summary>
        /// indikator flagging quota atau tidak
        /// </summary>
        public DateTime? IsFlagQuota { get; set; }
        /// <summary>
        /// ID paket
        /// </summary>
        public string PackageId { get; set; }
        /// <summary>
        /// ID program
        /// </summary>
        public bool? ProgramId { get; set; }
        /// <summary>
        /// biaya asuransi gross
        /// </summary>
        public decimal? InsuranceFeeGross { get; set; }
        /// <summary>
        /// uang muka murni konsumen
        /// </summary>
        public decimal? UangMukaMurniKons { get; set; }
        /// <summary>
        /// nominal desimal angsuran
        /// </summary>
        public decimal? InstallmentDecimal { get; set; }
        /// <summary>
        /// ID model
        /// </summary>
        public string ModelId { get; set; }
        /// <summary>
        /// CC kendaraan
        /// </summary>
        public string Cc { get; set; }
        /// <summary>
        /// pembayaran pertama
        /// </summary>
        public decimal? FirstPayment { get; set; }
        /// <summary>
        /// tipe guna
        /// </summary>
        public string TipeGuna { get; set; }
        /// <summary>
        /// indikator price list baru atau tidak
        /// </summary>
        public string IsNewPriceList { get; set; }
        /// <summary>
        /// biaya provisi
        /// </summary>
        public decimal? BiayaProvisi { get; set; }
        /// <summary>
        /// biaya provisi asuransi
        /// </summary>
        public decimal? BiayaProvisiIns { get; set; }
        /// <summary>
        /// NIK marketing head
        /// </summary>
        public string NikMh { get; set; }
        /// <summary>
        /// tipe cover
        /// </summary>
        public string TipeCover { get; set; }
        /// <summary>
        /// ID biaya proses
        /// </summary>
        public string BiayaProsesId { get; set; }
        /// <summary>
        /// nominal biaya proses
        /// </summary>
        public decimal? NominalBiayaProses { get; set; }
        /// <summary>
        /// urutan paket pembiayaan
        /// </summary>
        public bool? PackagePembiayaanSecq { get; set; }
        /// <summary>
        /// ID paket pembiayaan
        /// </summary>
        public string PaketPembiayaanId { get; set; }
        /// <summary>
        /// urutan biaya proses
        /// </summary>
        public string BiayaProsesSeq { get; set; }
        /// <summary>
        /// indikator TAC atau tidak
        /// </summary>
        public string IsTac { get; set; }
        /// <summary>
        /// nominal TAC maksimum
        /// </summary>
        public decimal? TacMax { get; set; }
        /// <summary>
        /// nominal komper maksimum
        /// </summary>
        public string KomperMax { get; set; }
        /// <summary>
        /// kode leasing
        /// </summary>
        public bool? LeasingCode { get; set; }
        /// <summary>
        /// nilai bunga refund
        /// </summary>
        public decimal? RefundBunga { get; set; }
        /// <summary>
        /// persen bunga refund
        /// </summary>
        public double? RefundBungaPercent { get; set; }
        /// <summary>
        /// ID jenis suku bunga
        /// </summary>
        public string InterestRateTypeId { get; set; }
        /// <summary>
        /// nomor CGS cabang
        /// </summary>
        public string CgscabangNo { get; set; }
        /// <summary>
        /// indikator avalis atau tidak
        /// </summary>
        public bool? IsAvalis { get; set; }
        /// <summary>
        /// tipe angsuran
        /// </summary>
        public string InstallmentType { get; set; }
        /// <summary>
        /// nominal biaya proses kredit
        /// </summary>
        public decimal? NominalBiayaProsesKredit { get; set; }
        /// <summary>
        /// biaya admin kredit
        /// </summary>
        public decimal? AdminFeeKredit { get; set; }
        /// <summary>
        /// biaya kerugian
        /// </summary>
        public decimal? LossFee { get; set; }
        /// <summary>
        /// biaya kerugian kredit
        /// </summary>
        public decimal? LossFeeKredit { get; set; }
        /// <summary>
        /// biaya provisi kredit
        /// </summary>
        public decimal? BiayaProvisiKredit { get; set; }
        /// <summary>
        /// biaya provisi asuransi kredit
        /// </summary>
        public decimal? BiayaProvisiInsKredit { get; set; }
        /// <summary>
        /// jumlah bayar nasabah
        /// </summary>
        public decimal? CustomerPayAmount { get; set; }
        /// <summary>
        /// nilai residual/sisa
        /// </summary>
        public decimal? ResidualValue { get; set; }
        /// <summary>
        /// jumlah diskon dealer
        /// </summary>
        public decimal? DiscountDealer { get; set; }
        /// <summary>
        /// ID cabang
        /// </summary>
        public string BranchId { get; set; }
        public string BranchIdFirst { get; set; }
        /// <summary>
        /// indikator asuransi jiwa atau tidak
        /// </summary>
        public string IsLifeIns { get; set; }
        /// <summary>
        /// indikator top up mega solusi atau tidak
        /// </summary>
        public bool? IsTopupMs { get; set; }
        /// <summary>
        /// nomor PO (purchase order)
        /// </summary>
        public string PoNo { get; set; }
        /// <summary>
        /// ID perusahaan
        /// </summary>
        public string CompanyId { get; set; }
        public string StnkStatusId { get; set; }
        public string RiskCategoryId { get; set; }
        /// <summary>
        /// npp lama
        /// </summary>
        public string OldNpp { get; set; }
        /// <summary>
        /// ID tipe pemilik akun
        /// </summary>
        public string OwnershipAccountTypeId { get; set; }
        /// <summary>
        /// ID akun bank UMC
        /// </summary>
        public string BankAccountIdUmc { get; set; }
        public bool? BpkbInvoice { get; set; }
    }
}