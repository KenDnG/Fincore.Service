﻿using FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst.CAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst.CAS
{
    public class CreditAnalyst_CASModels
    {
        public string? CreatedBy { get; set; }
        /// <summary>
        /// tanggal &amp; waktu pembuatan master data
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// user yang mengubah master data
        /// </summary>
        public string? LastUpdatedBy { get; set; }
        /// <summary>
        /// tanggal &amp; waktu perubahan master data
        /// </summary>
        public DateTime? LastUpdatedOn { get; set; }
        /// <summary>
        /// ID kredit
        /// </summary>
        public string? CreditId { get; set; }
        /// <summary>
        /// ID perusahaan
        /// </summary>
        public string? CompanyId { get; set; }
        /// <summary>
        /// ID cabang
        /// </summary>
        public string? BranchId { get; set; }
        /// <summary>
        /// kode outlet
        /// </summary>
        public string? OutletCode { get; set; }
        /// <summary>
        /// ID sumber kredit
        /// </summary>
        public string? CreditSourceId { get; set; }
        /// <summary>
        /// ID order
        /// </summary>
        public string? OrderId { get; set; }
        /// <summary>
        /// tipe konsumen
        /// </summary>
        public string? CustomerType { get; set; }
        /// <summary>
        /// indikator repeat order atau tidak
        /// </summary>
        public bool? IsRepeatOrder { get; set; }
        /// <summary>
        /// indikator instant approval atau tidak
        /// </summary>
        public bool? IsInstantApproval { get; set; }
        /// <summary>
        /// alasan repeat order
        /// </summary>
        public string? RepeatOrderReason { get; set; }
        /// <summary>
        /// nama nasabah
        /// </summary>
        public string? CustomerName { get; set; }
        /// <summary>
        /// tempat lahir nasabah
        /// </summary>
        public string? BirthPlace { get; set; }
        /// <summary>
        /// tanggal lahir nasabah
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// jenis kelamin nasabah
        /// </summary>
        public string? Gender { get; set; }
        /// <summary>
        /// nama ibu nasabah
        /// </summary>
        public string? MotherName { get; set; }
        /// <summary>
        /// email nasabah
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// ID tipe identitas
        /// </summary>
        public string? IdentityTypeId { get; set; }
        /// <summary>
        /// nomor identitas
        /// </summary>
        public string? IdentityNumber { get; set; }
        /// <summary>
        /// masa berlaku kartu identitas
        /// </summary>
        public DateTime? ValidThru { get; set; }
        /// <summary>
        /// tanggal penerbitan kartu identitas
        /// </summary>
        public DateTime? IssueDate { get; set; }
        /// <summary>
        /// alamat pada kartu identitas
        /// </summary>
        public string? IdentityAddress { get; set; }
        /// <summary>
        /// ID lokasi identitas
        /// </summary>
        public int? IdentityLocationId { get; set; }
        /// <summary>
        /// indikator blacklist atau tidak
        /// </summary>
        public bool? IsBlacklist { get; set; }
        /// <summary>
        /// alamat nasabah
        /// </summary>
        public string? CustomerAddress { get; set; }
        /// <summary>
        /// ID lokasi nasabah
        /// </summary>
        public int? CustomerLocationId { get; set; }
        /// <summary>
        /// nomor NPWP
        /// </summary>
        public string? NpwpNo { get; set; }
        /// <summary>
        /// nomor telepon
        /// </summary>
        public string? TelephoneNumber { get; set; }
        /// <summary>
        /// nomor handphone
        /// </summary>
        public string? MobilePhone { get; set; }
        /// <summary>
        /// jarak rumah nasabah
        /// </summary>
        public int? ResidenceDistance { get; set; }
        /// <summary>
        /// ID sumber konsumen
        /// </summary>
        public string? CustomerSourceId { get; set; }
        /// <summary>
        /// indikator sudah survey atau belum
        /// </summary>
        public bool? IsSurveyed { get; set; }
        /// <summary>
        /// ID narasumber
        /// </summary>
        public int? SourcesId { get; set; }
        /// <summary>
        /// nama narasumber
        /// </summary>
        public string? SourcesName { get; set; }
        /// <summary>
        /// alamat narasumber
        /// </summary>
        public string? SourcesAddress { get; set; }
        /// <summary>
        /// ID evaluasi
        /// </summary>
        public int? EvaluationId { get; set; }
        /// <summary>
        /// ID status tempat tinggal
        /// </summary>
        public string? ResidenceStatusId { get; set; }
        /// <summary>
        /// bukti kepemilikan
        /// </summary>
        public int? OwnershipProof { get; set; }
        /// <summary>
        /// nama bukti kepemilikan
        /// </summary>
        public string? OwnershipProofName { get; set; }
        /// <summary>
        /// kondisi rumah
        /// </summary>
        public string? ResidenceCondition { get; set; }
        /// <summary>
        /// status pernikahan
        /// </summary>
        public int? MaritalStatus { get; set; }
        /// <summary>
        /// ID sumber tertagih
        /// </summary>
        public int? MailToSourceId { get; set; }
        /// <summary>
        /// alamat tertagih
        /// </summary>
        public string? MailToAddress { get; set; }
        /// <summary>
        /// ID lokasi tertagih
        /// </summary>
        public int? MailToLocationId { get; set; }
        /// <summary>
        /// nomor telepon tertagih
        /// </summary>
        public string? MailToTelephoneNumber { get; set; }
        /// <summary>
        /// status sumber kredit
        /// </summary>
        public string? CreditSourceStatus { get; set; }
        /// <summary>
        /// analisa
        /// </summary>
        public string? Analysis { get; set; }
        /// <summary>
        /// kesimpulan
        /// </summary>
        public string? Conclusion { get; set; }
        /// <summary>
        /// indikator APUPPT atau tidak
        /// </summary>
        public int? IsApuppt { get; set; }
        public virtual CreditAnalyst_CASCorporateModels? TrCasCorporateDocument { get; set; }
        public virtual CreditAnalyst_CASFinancialModels? TrCasFinancial { get; set; }
        //public virtual TrCasRepeatOrder TrCasRepeatOrder { get; set; }
        //public virtual ICollection<TrCasApuppt> TrCasApuppts { get; set; }
        //public virtual ICollection<TrCasInstallment> TrCasInstallments { get; set; }
        //public virtual ICollection<TrCasPaymentPoint> TrCasPaymentPoints { get; set; }
        //public virtual List<CreditAnalyst_CASReferenceModels> TrCasReferences { get; set; }
    }

}
