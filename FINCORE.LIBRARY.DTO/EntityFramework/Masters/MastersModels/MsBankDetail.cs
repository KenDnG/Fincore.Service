﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsBankDetail
    {
        /// <summary>
        /// user yang membuat master data
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// tanggal &amp; waktu pembuatan master data
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// user yang mengubah master data
        /// </summary>
        public string LastUpdatedBy { get; set; }
        /// <summary>
        /// tanggal &amp; waktu perubahan master data
        /// </summary>
        public DateTime? LastUpdatedOn { get; set; }
        /// <summary>
        /// ID bank
        /// </summary>
        public string BankId { get; set; }
        /// <summary>
        /// ID cabang
        /// </summary>
        public string BranchId { get; set; }
        /// <summary>
        /// nama bank
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// alamat bank
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// kota
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// nomor telepon
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// nomor fax
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// akun bank
        /// </summary>
        public string BankAccount { get; set; }
        /// <summary>
        /// nama akun bank
        /// </summary>
        public string BankAccountName { get; set; }
        /// <summary>
        /// nomor grup bank
        /// </summary>
        public string BgNumber { get; set; }
        /// <summary>
        /// indikator aktif atau tidaknya master data
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// nomor COA
        /// </summary>
        public string NumberCoa { get; set; }
        /// <summary>
        /// ID grup bank
        /// </summary>
        public string BankGroupId { get; set; }
        /// <summary>
        /// indikator bank eksternal atau tidak
        /// </summary>
        public bool IsEksternal { get; set; }
        /// <summary>
        /// indikator bank default cabang atau tidak
        /// </summary>
        public bool IsDefaultBranch { get; set; }
        /// <summary>
        /// indikator bank masih beroperasi atau tidak
        /// </summary>
        public bool IsOperational { get; set; }
        /// <summary>
        /// indikator default bank RRV atau tidak
        /// </summary>
        public bool IsDefaultBankRrv { get; set; }
        /// <summary>
        /// indikator default bank ITR atau tidak
        /// </summary>
        public bool IsDefaultBankItr { get; set; }
    }
}