﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class TrCaDocuments
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
        /// ID dokumen approval CA
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// nomor CA
        /// </summary>
        public string CaNo { get; set; }
        /// <summary>
        /// pernyataan akte pendirian
        /// </summary>
        public string AktePendirianStatement { get; set; }
        /// <summary>
        /// hasil cek akte pendirian
        /// </summary>
        public string AktePendirianCheckResult { get; set; }
        /// <summary>
        /// pernyataan akte perubahan
        /// </summary>
        public string AktePerubahanStatement { get; set; }
        /// <summary>
        /// hasil cek akte perubahan
        /// </summary>
        public string AktePerubahanCheckResult { get; set; }
        /// <summary>
        /// pernyataan SIUP NIB
        /// </summary>
        public string SiupNibStatement { get; set; }
        /// <summary>
        /// hasil cek SIUP NIB
        /// </summary>
        public string SiupNibCheckResult { get; set; }
        /// <summary>
        /// pernyataan NPWP
        /// </summary>
        public string NpwpStatement { get; set; }
        /// <summary>
        /// hasil cek NPWP
        /// </summary>
        public string NpwpCheckResult { get; set; }
        /// <summary>
        /// pernyataan TDP NIB
        /// </summary>
        public string TdpNibStatement { get; set; }
        /// <summary>
        /// hasil cek TDP NIB
        /// </summary>
        public string TdpNibCheckResult { get; set; }
        /// <summary>
        /// pernyataan SKMenkeh
        /// </summary>
        public string SkmenkehStatement { get; set; }
        /// <summary>
        /// hasil cek SKMenkeh
        /// </summary>
        public string SkmenkehCheckResult { get; set; }
        /// <summary>
        /// pernyataan SKDomisili
        /// </summary>
        public string SkdomisiliStatement { get; set; }
        /// <summary>
        /// hasil cek SKDomisili
        /// </summary>
        public string SkdomisiliCheckResult { get; set; }
        /// <summary>
        /// pernyataan pengecekan rekening
        /// </summary>
        public string CheckingAccountStatement { get; set; }
        /// <summary>
        /// hasil cek rekening
        /// </summary>
        public string AccountCheckResult { get; set; }
        /// <summary>
        /// keterangan KTP pemohon melalui sistem Dukcapil
        /// </summary>
        public string KetKtppemohonKomisarisDukcapil { get; set; }
        /// <summary>
        /// hasil cek KTP pemohon melalui sistem Dukcapil
        /// </summary>
        public string HasilCheckKtppemohonKomisarisDukcapil { get; set; }
        /// <summary>
        /// keterangan KTP pemohon melalui apps playstore
        /// </summary>
        public string KetKtppemohonKomisarisPlaystore { get; set; }
        /// <summary>
        /// hasil cek KTP pemohon melalui apps playstore
        /// </summary>
        public string HasilCheckKtppemohonKomisarisPlaystore { get; set; }
        /// <summary>
        /// keterangan KTP pasangan melalui sistem Dukcapil
        /// </summary>
        public string KetKtppasanganDirutDukcapil { get; set; }
        /// <summary>
        /// hasil cek KTP pasangan melalui sistem Dukcapil
        /// </summary>
        public string HasilCheckKtppasanganDirutDukcapil { get; set; }
        /// <summary>
        /// keterangan KTP pasangan melalui apps playstore
        /// </summary>
        public string KetKtppasanganDirutPlaystore { get; set; }
        /// <summary>
        /// hasil cek KTP pasangan melalui apps playstore
        /// </summary>
        public string HasilCheckKtppasanganDirutPlaystore { get; set; }
        /// <summary>
        /// keterangan KTP penjamin melalui sistem Dukcapil
        /// </summary>
        public string KetKtppenjaminDirekturDukcapil { get; set; }
        /// <summary>
        /// hasil cek KTP penjamin melalui sistem Dukcapil
        /// </summary>
        public string HasilCheckKtppenjaminDirekturDukcapil { get; set; }
        /// <summary>
        /// keterangan KTP penjamin melalui apps playstore
        /// </summary>
        public string KetKtppenjaminDirekturPlaystore { get; set; }
        /// <summary>
        /// hasil cek KTP penjamin melalui apps playstore
        /// </summary>
        public string HasilCheckKtppenjaminDirekturPlaystore { get; set; }
        /// <summary>
        /// keterangan kartu keluarga
        /// </summary>
        public string KeteranganKartuKeluarga { get; set; }
        /// <summary>
        /// hasil cek kartu keluarga
        /// </summary>
        public string HasilCheckKartuKeluarga { get; set; }
        /// <summary>
        /// keterangan NPWP komisaris
        /// </summary>
        public string KeteranganNpwpkomisaris { get; set; }
        /// <summary>
        /// hasil cek NPWP komisaris
        /// </summary>
        public string HasilCheckNpwpkomisaris { get; set; }
        /// <summary>
        /// keterangan NPWP direktur utama
        /// </summary>
        public string KeteranganNpwpdirekturUtama { get; set; }
        /// <summary>
        /// hasil cek NPWP direktur utama
        /// </summary>
        public string HasilCheckNpwpdirekturUtama { get; set; }
        /// <summary>
        /// keterangan NPWP direktur
        /// </summary>
        public string KeteranganNpwpdirektur { get; set; }
        /// <summary>
        /// hasil cek NPWP direktur
        /// </summary>
        public string HasilCheckNpwpdirektur { get; set; }
        /// <summary>
        /// keterangan bukti kepemilikan rumah
        /// </summary>
        public string KetBuktiKepemilikanRumah { get; set; }
        /// <summary>
        /// hasil cek bukti kepemilikan rumah
        /// </summary>
        public string HasilCheckBuktiKepemilikanRumah { get; set; }
        /// <summary>
        /// bentuk bukti kepemilikan rumah
        /// </summary>
        public string BentukBuktiKepemilikanRumah { get; set; }
        /// <summary>
        /// keterangan rekening
        /// </summary>
        public string KeteranganRekening { get; set; }
        /// <summary>
        /// hasil cek rekening
        /// </summary>
        public string HasilCheckRekening { get; set; }
        /// <summary>
        /// keterangan survey kontak darurat
        /// </summary>
        public string KetSurveyEmergencyContact { get; set; }
        /// <summary>
        /// hasil cek survey kontak darurat
        /// </summary>
        public string HasilCheckSurveyEmergencyContact { get; set; }
        /// <summary>
        /// keterangan STNK
        /// </summary>
        public string KeteranganStnk { get; set; }
        /// <summary>
        /// status berlaku STNK
        /// </summary>
        public string StatusBerlakuStnk { get; set; }
        /// <summary>
        /// tanggal kadaluarsa STNK dan BPKB
        /// </summary>
        public DateTime? ExpiredDateStnkbpkb { get; set; }
        /// <summary>
        /// keterangan media sosial
        /// </summary>
        public string KeteranganMedsos { get; set; }
        /// <summary>
        /// hasil cek media sosial
        /// </summary>
        public string HasilCheckMedsos { get; set; }
        /// <summary>
        /// situs sumber info media sosial
        /// </summary>
        public string SitusSumberInfoMedsos { get; set; }
        /// <summary>
        /// keterangan cek survey domisili pemohon atau perusahaan
        /// </summary>
        public string KeteranganCheckSurveyDomisiliPemohonPerusahaan { get; set; }
        /// <summary>
        /// hasil cek survey domisili pemohon atau perusahaan
        /// </summary>
        public string HasilCheckSurveyDomisiliPemohonPerusahaan { get; set; }
        /// <summary>
        /// keterangan survey kantor
        /// </summary>
        public string KeteranganSurveyKantor { get; set; }
        /// <summary>
        /// hasil cek survey kantor
        /// </summary>
        public string HasilCheckSurveyKantor { get; set; }
        /// <summary>
        /// keterangan survey usaha
        /// </summary>
        public string KeteranganSurveyUsaha { get; set; }
        /// <summary>
        /// hasil cek survey usaha
        /// </summary>
        public string HasilCheckSurveyUsaha { get; set; }
        /// <summary>
        /// keterangan survey lingkungan RT RW atau perusahaan
        /// </summary>
        public string KetSurveyLingkunganRtrwPerusahaan { get; set; }
        /// <summary>
        /// hasil cek survey  RT RW atau perusahaan
        /// </summary>
        public string HasilCheckSurveyLigkunganRtrwPerusahaan { get; set; }
        /// <summary>
        /// keterangan survey domisili penjamin atau pengguna unit
        /// </summary>
        public string KeteranganSurveyDomisiliPenjaminPenggunaUnit { get; set; }
        /// <summary>
        /// hasil cek survey domisili penjamin atau pengguna unit
        /// </summary>
        public string HasilCheckSurveyDomisiliPenjaminPenggunaUnit { get; set; }
        /// <summary>
        /// keterangan survey taksasi unit
        /// </summary>
        public string KetSurveyTaksasiUnit { get; set; }
        /// <summary>
        /// hasil cek survey taksasi unit
        /// </summary>
        public string HasilCheckSurveyTaksasiUnit { get; set; }
        /// <summary>
        /// status APPI pemohon atau badan hukum
        /// </summary>
        public string StatusAppipemohonBadanHukum { get; set; }
        /// <summary>
        /// nominal APPI pemohon atau badan hukum
        /// </summary>
        public string NominalAppipemohonBadanHukum { get; set; }
        /// <summary>
        /// status APPI pasangan atau komisaris
        /// </summary>
        public string StatusAppipasanganKomisaris { get; set; }
        /// <summary>
        /// nominal APPI pasangan atau komisaris
        /// </summary>
        public string NominalAppipasanganKomisaris { get; set; }
        /// <summary>
        /// status APPI penjamin atau direktur
        /// </summary>
        public string StatusAppipenjaminDirektur { get; set; }
        /// <summary>
        /// nominal APPI penjamin atau direktur
        /// </summary>
        public string NominalAppipenjaminDirektur { get; set; }
        /// <summary>
        /// keterangan rekening koran
        /// </summary>
        public string KeteranganRekeningKoran { get; set; }
        /// <summary>
        /// hasil cek rekening koran
        /// </summary>
        public string HasilCheckRekeningKoran { get; set; }
    }
}