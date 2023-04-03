﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class sp_get_pagination_BPKBResult
    {
        public long? RowNumber { get; set; }
        public string BPKBNo { get; set; }
        public int? CompanyID { get; set; }
        public string BranchId { get; set; }
        public string AgreementNumber { get; set; }
        public string CarNO { get; set; }
        public string FakturNO { get; set; }
        public DateTime? FakturDate { get; set; }
        public DateTime? BPKBin { get; set; }
        public string Lokasi { get; set; }
        public string NoLemari { get; set; }
        public string NoRack { get; set; }
        public string NoLaci { get; set; }
        public string NoUrut { get; set; }
        public DateTime? BPKBout { get; set; }
        public string OutCode { get; set; }
        public string ReceiverCode { get; set; }
        public string ReceiverDesc { get; set; }
        public string Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public string StatusBy { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? BASTDATE { get; set; }
        public string BASTBY { get; set; }
        public string LocationCode { get; set; }
        public int? TotalPinjam { get; set; }
        public DateTime? BPKBPinjam { get; set; }
        public DateTime? BPKBRencanaKembali { get; set; }
        public string AlasanPinjam { get; set; }
        public string Kelurahan { get; set; }
        public string ReceiverCodePinjam { get; set; }
        public string ReceiverDescPinjam { get; set; }
        public DateTime? BPKBKembali { get; set; }
        public string StatusBPKB { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateOn { get; set; }
        public bool? IsClose { get; set; }
        public DateTime? CloseDate { get; set; }
        public string CloseBy { get; set; }
        public DateTime? BPKBDate { get; set; }
        public string Officer { get; set; }
        public DateTime? SettingDate { get; set; }
        public bool? IsPrintSK { get; set; }
        public int? SumPrint { get; set; }
        public string PrintedFirstBy { get; set; }
        public DateTime? PrintedFirstDate { get; set; }
        public string PrintedLastBy { get; set; }
        public DateTime? PrintedLastDate { get; set; }
        public string Alamat { get; set; }
        public string NamaPenerima { get; set; }
        public string NoTeleponPenerima { get; set; }
        public decimal? UangDiterima { get; set; }
        public bool? IsMB { get; set; }
        public bool? StatusBBN { get; set; }
        public DateTime? BBNDate { get; set; }
        public decimal? BBNValue { get; set; }
        public string BBNDesc { get; set; }
        public bool? isPrintPihakTiga { get; set; }
        public int? SumPrintPihakTiga { get; set; }
        public string PrintFirstByPihakTiga { get; set; }
        public DateTime? PrintFirstDatePihakTiga { get; set; }
        public string PrintLastByPihakTiga { get; set; }
        public DateTime? PrintLastDatePihakTiga { get; set; }
        public string TipeKeperluanBiroJasaID { get; set; }
        public string KetSelisiBPKB { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public string KodePenerima { get; set; }
        public string IsPrintSK2 { get; set; }
        public string CustomerName { get; set; }
        public string ChasisNo { get; set; }
        public string MachineNo { get; set; }
        public string CMNo { get; set; }
        public string StatusCM { get; set; }
        public string IsOD { get; set; }
        public bool? Isprint { get; set; }
        public string StatusBPKB2 { get; set; }
        public string NamaTipePenerimaPinjam { get; set; }
        public string NamaTipePenerimaOut { get; set; }
        public int CompanyID2 { get; set; }
        public string NoTeleponKons { get; set; }
        public string AlamatTagihKons { get; set; }
        public string EmailKons { get; set; }
        public string NoTeleponPasanganKons { get; set; }
        public string TipeaplikasiID { get; set; }
        public decimal? BiayaPenitipanBPKB { get; set; }
        public int? LamaPenitipanBPKB { get; set; }
        public string TipeKeperluanBiroJasa { get; set; }
    }
}
