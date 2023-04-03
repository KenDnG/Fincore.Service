﻿using FINCORE.Models.Models.Vertel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.Vertel
{
    public class TrVerificationConsumenModels
    {
        public string? VerifikasiNo { get; set; }
        public string Cmno { get; set; }
        public string StatusVerifikasi { get; set; }
        public int? OptBisaDiHubungi { get; set; }
        public string? NamaStnk { get; set; }
        public string? NamaPasanganStnk { get; set; }
        public DateTime? TglTerimaTagihan { get; set; }
        public DateTime? TglKonfirmasi { get; set; }
        public string JamKonfirmasi { get; set; }
        public DateTime? TglApproveNpp { get; set; }
        public bool? OptTglTerimaMotor { get; set; }
        public DateTime? OptTglTerimaMotorSebenarnya { get; set; }
        public bool? OptTipeMotor { get; set; }
        public string? OptTipeMotorSebenarnya { get; set; }
        public bool? OptAngsuran { get; set; }
        public decimal? OptAngsuranSebenarnya { get; set; }
        public bool? OptTenor { get; set; }
        public int? OptTenorSebenarnya { get; set; }
        public string? NamaPenerimaMotor { get; set; }
        public string? HubunganPenerimaMotor { get; set; }
        public string? PermintaanJt { get; set; }
        public string CatatanLain { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? OptPencairanMb { get; set; }
        public decimal? OptPencairanMbsebenarnya { get; set; }
        public bool? OptDpsetor { get; set; }
        public decimal? OptDpsetorSebenarnya { get; set; }
        public bool? BiayaAdminLainnya { get; set; }
        public decimal? JumlahNominalAdmin { get; set; }
        public DateTime? TanggalBayar { get; set; }
        public int? LokasiMotorDiTerima { get; set; }
        public string? LokasiDiTerima { get; set; }

        public List<DocFieldModels> docFieldModels { get; set; }

        public string? SaveType { get; set; }
        public int OptBiayaAdmin { get; set; }
        public decimal? BiayaAdmin { get; set; }

    }
}