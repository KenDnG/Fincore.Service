﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class sp_get_fcl_result_header_slikResult
    {
        public string FCLID { get; set; }
        public string KTPNo { get; set; }
        public string NPWPNo { get; set; }
        public string TipePengajuan { get; set; }
        public DateTime? TanggalPengajuan { get; set; }
        public string NamaKonsumen { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string TempatLahir { get; set; }
        public string Alamat { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateOn { get; set; }
        public int? BranchID { get; set; }
        public string Source { get; set; }
        public int? IsDukcapil { get; set; }
        public int? IsPefindo { get; set; }
        public string isExport { get; set; }
    }
}
