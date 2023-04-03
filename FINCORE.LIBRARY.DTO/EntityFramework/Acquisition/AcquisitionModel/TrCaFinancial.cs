﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class TrCaFinancial
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
        /// ID keuangan CA
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// nomor CA
        /// </summary>
        public string CaNo { get; set; }
        /// <summary>
        /// ID tipe penghasilan
        /// </summary>
        public long? IncomeTypeId { get; set; }
        /// <summary>
        /// sumber penghasilan
        /// </summary>
        public string SourceOfIncome { get; set; }
        /// <summary>
        /// nama perusahaan atau usaha
        /// </summary>
        public string CorporateOrBussinessName { get; set; }
        /// <summary>
        /// alamat perusahaan atau usaha
        /// </summary>
        public string CorporateOrBussinessAddress { get; set; }
        /// <summary>
        /// jabatan
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// ID profesi
        /// </summary>
        public string ProfessionId { get; set; }
        /// <summary>
        /// lama bekerja atau usaha
        /// </summary>
        public string LengthOfWork { get; set; }
        /// <summary>
        /// nomor telepon
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// status kepegawaian
        /// </summary>
        public string EmployeeStatus { get; set; }
        /// <summary>
        /// ID bidang usaha
        /// </summary>
        public string IndustryTypeId { get; set; }
        /// <summary>
        /// jumlah karyawan
        /// </summary>
        public string NumberOfEmployees { get; set; }
        /// <summary>
        /// indikator penghasilan tambahan atau tidak
        /// </summary>
        public string IsOtherIncome { get; set; }
        /// <summary>
        /// validasi penghasilan
        /// </summary>
        public string IncomeValidation { get; set; }

        public virtual TrCa CaNoNavigation { get; set; }
    }
}