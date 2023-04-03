﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class TrCa
    {
        public TrCa()
        {
            TrCaFinancial = new HashSet<TrCaFinancial>();
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
        /// nomor CA
        /// </summary>
        public string CaNo { get; set; }
        /// <summary>
        /// ID perusahaan
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// ID cabang
        /// </summary>
        public string BranchId { get; set; }
        /// <summary>
        /// ID kredit
        /// </summary>
        public string CreditId { get; set; }
        /// <summary>
        /// badan hukum
        /// </summary>
        public string CorporateLegalEntity { get; set; }
        /// <summary>
        /// kondisi rumah
        /// </summary>
        public string HouseCondition { get; set; }
        /// <summary>
        /// kondisi lingkungan
        /// </summary>
        public string EnvironmentCondition { get; set; }
        /// <summary>
        /// lama tinggal
        /// </summary>
        public string LengthOfStay { get; set; }
        /// <summary>
        /// kepemilikan perusahaan
        /// </summary>
        public string CompanyOwnership { get; set; }
        /// <summary>
        /// aktifitas usaha
        /// </summary>
        public string BusinessActivity { get; set; }
        /// <summary>
        /// skala perusahaan
        /// </summary>
        public string CorporateScale { get; set; }
        /// <summary>
        /// pemilik manfaat
        /// </summary>
        public string BeneficialOwner { get; set; }
        /// <summary>
        /// lingkungan bisnis
        /// </summary>
        public string BusinessEnvironment { get; set; }
        /// <summary>
        /// akses jalan
        /// </summary>
        public string RoadAccess { get; set; }
        /// <summary>
        /// validasi data pemohon
        /// </summary>
        public string ApplicantValidation { get; set; }
        /// <summary>
        /// validasi pihak ke-3
        /// </summary>
        public string ReferenceValidation { get; set; }
        /// <summary>
        /// nominal MRP
        /// </summary>
        public decimal? Mrp { get; set; }
        /// <summary>
        /// nama SPK
        /// </summary>
        public string SpkName { get; set; }
        /// <summary>
        /// tanggal SPK
        /// </summary>
        public DateTime? SpkDate { get; set; }
        /// <summary>
        /// validasi unit pengajuan
        /// </summary>
        public string SubmissionValidation { get; set; }
        /// <summary>
        /// alasan validasi vertel
        /// </summary>
        public string VertelValidationReason { get; set; }
        /// <summary>
        /// link SLIK
        /// </summary>
        public string SlikLink { get; set; }
        /// <summary>
        /// aspek positif
        /// </summary>
        public string PositiveAspects { get; set; }
        /// <summary>
        /// aspek negatif
        /// </summary>
        public string NegativeAspects { get; set; }
        /// <summary>
        /// NIK (Nomor Induk Karyawan) CA
        /// </summary>
        public string CaNik { get; set; }
        /// <summary>
        /// keputusan CA
        /// </summary>
        public string CaDecision { get; set; }
        /// <summary>
        /// keterangan CA
        /// </summary>
        public string CreditAnalysis { get; set; }
        /// <summary>
        /// jumlah approval
        /// </summary>
        public string Approval { get; set; }
        /// <summary>
        /// status CA
        /// </summary>
        public string CaStatus { get; set; }
        /// <summary>
        /// user yang melakukan print terakhir
        /// </summary>
        public string LastPrintedBy { get; set; }
        /// <summary>
        /// tanggal print terakhir
        /// </summary>
        public DateTime? LastPrintedOn { get; set; }
        /// <summary>
        /// total berapa kali print
        /// </summary>
        public int? SumOfPrint { get; set; }

        public virtual ICollection<TrCaFinancial> TrCaFinancial { get; set; }
    }
}