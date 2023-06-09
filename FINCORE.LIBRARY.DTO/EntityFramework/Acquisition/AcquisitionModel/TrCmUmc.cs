﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class TrCmUmc
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
        /// nama rekening UMC
        /// </summary>
        public string AccountNameUmc { get; set; }
        /// <summary>
        /// ID bank UMC
        /// </summary>
        public string BankIdUmc { get; set; }
        /// <summary>
        /// nomor rekening UMC
        /// </summary>
        public string AccountNoUmc { get; set; }
        /// <summary>
        /// indikator apakah KK sama atau tidak
        /// </summary>
        public bool? IsSameKk { get; set; }
        /// <summary>
        /// ID skema
        /// </summary>
        public string SchemeId { get; set; }
        /// <summary>
        /// indikator rekening pribadi atau tidak
        /// </summary>
        public string IsPersonalAccount { get; set; }
        /// <summary>
        /// ID perusahaan
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// ID tipe agen
        /// </summary>
        public string IdAgentType { get; set; }
        /// <summary>
        /// ID agen
        /// </summary>
        public string AgentId { get; set; }
        /// <summary>
        /// indikator eksternal atau tidak
        /// </summary>
        public bool? IsExternal { get; set; }
        /// <summary>
        /// nomor STNK
        /// </summary>
        public string IdentityNumberOfStnk { get; set; }
        /// <summary>
        /// nama agen
        /// </summary>
        public string AgentName { get; set; }
        /// <summary>
        /// ID tipe pemilik akun
        /// </summary>
        public string OwnershipAccountTypeId { get; set; }
        /// <summary>
        /// ID akun bank UMC
        /// </summary>
        public string BankAccountIdUmc { get; set; }
        /// <summary>
        /// nama bank UMC
        /// </summary>
        public string BankNameUmc { get; set; }
    }
}