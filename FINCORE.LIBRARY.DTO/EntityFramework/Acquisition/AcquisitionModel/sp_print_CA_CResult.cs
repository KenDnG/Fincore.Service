﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class sp_print_CA_CResult
    {
        public string corporate_legal_entity { get; set; }
        public string customer_name { get; set; }
        public string corporate_telephone_number { get; set; }
        public byte? corporate_year_period { get; set; }
        public string CMONIK { get; set; }
        public string CMOName { get; set; }
        public string KeteranganRFA { get; set; }
        public string tanggalKeputusanCA { get; set; }
        public string CA { get; set; }
        public string branch_name { get; set; }
        public string credit_id { get; set; }
        public string office_address { get; set; }
        public string company_ownership { get; set; }
        public string ownership_proof_desc { get; set; }
        public string business_activity { get; set; }
        public string BidangUsaha { get; set; }
        public string corporate_scale { get; set; }
        public string business_environment { get; set; }
        public string road_access { get; set; }
        public decimal? corporate_number_of_employee { get; set; }
        public decimal? primary_income { get; set; }
        public decimal? other_income { get; set; }
        public string Omzet { get; set; }
        public string OtherIncome { get; set; }
        public string applicant_validation { get; set; }
        public string ReferenceName { get; set; }
        public string ReferenceAddress { get; set; }
        public string ReferenceMobilePhone { get; set; }
        public string RelationshipDescription { get; set; }
        public string reference_validation { get; set; }
        public string DealerName { get; set; }
        public string MerkItem { get; set; }
        public string TypeItem { get; set; }
        public string DP { get; set; }
        public byte? tenor { get; set; }
        public string account_receiveable { get; set; }
        public string year_item { get; set; }
        public decimal? OTR { get; set; }
        public decimal? DPMurni { get; set; }
        public decimal? TotalPH { get; set; }
        public string OTRCurrency { get; set; }
        public string DPMurniCurrency { get; set; }
        public string TotalPHCurrency { get; set; }
        public string MRPCurrency { get; set; }
        public string SPK_name { get; set; }
        public string SPKDate { get; set; }
        public DateTime? SPK_date { get; set; }
        public string QQ_name { get; set; }
        public decimal? MRP { get; set; }
        public string ExpiredDate { get; set; }
        public string DPNet { get; set; }
        public decimal? Angsuran { get; set; }
        public string AngsuranCurrency { get; set; }
        public string submission_validation { get; set; }
        public string vertel_validation_reason { get; set; }
        public string created_by { get; set; }
        public DateTime? created_on { get; set; }
        public string last_updated_by { get; set; }
        public DateTime? last_updated_on { get; set; }
        public long? id { get; set; }
        public string CA_no { get; set; }
        public string akte_pendirian_statement { get; set; }
        public string akte_pendirian_check_result { get; set; }
        public string akte_perubahan_statement { get; set; }
        public string akte_perubahan_check_result { get; set; }
        public string SIUP_NIB_statement { get; set; }
        public string SIUP_NIB_check_result { get; set; }
        public string NPWP_statement { get; set; }
        public string NPWP_check_result { get; set; }
        public string TDP_NIB_statement { get; set; }
        public string TDP_NIB_check_result { get; set; }
        public string SKMenkeh_statement { get; set; }
        public string SKMenkeh_check_result { get; set; }
        public string SKDomisili_statement { get; set; }
        public string SKDomisili_check_result { get; set; }
        public string checking_account_statement { get; set; }
        public string account_check_result { get; set; }
        [Column("KetKTPPemohon/komisarisDukcapil")]
        public string KetKTPPemohonkomisarisDukcapil { get; set; }
        [Column("HasilCheckKTPPemohon/komisarisDukcapil")]
        public string HasilCheckKTPPemohonkomisarisDukcapil { get; set; }
        [Column("KetKTPPemohon/komisarisPlaystore")]
        public string KetKTPPemohonkomisarisPlaystore { get; set; }
        [Column("HasilCheckKTPPemohon/komisarisPlaystore")]
        public string HasilCheckKTPPemohonkomisarisPlaystore { get; set; }
        [Column("KetKTPPasangan/DirutDukcapil")]
        public string KetKTPPasanganDirutDukcapil { get; set; }
        [Column("HasilCheckKTPPasangan/DirutDukcapil")]
        public string HasilCheckKTPPasanganDirutDukcapil { get; set; }
        [Column("KetKtppasangan/DirutPlaystore")]
        public string KetKtppasanganDirutPlaystore { get; set; }
        [Column("HasilCheckKTPPasangan/DirutPlaystore")]
        public string HasilCheckKTPPasanganDirutPlaystore { get; set; }
        [Column("KetKTPPenjamin/DirekturDukcapil")]
        public string KetKTPPenjaminDirekturDukcapil { get; set; }
        [Column("HasilCheckKTPPenjamin/DirekturDukcapil")]
        public string HasilCheckKTPPenjaminDirekturDukcapil { get; set; }
        [Column("KetKTPPenjamin/DirekturPlaystore")]
        public string KetKTPPenjaminDirekturPlaystore { get; set; }
        [Column("HasilCheckKTPPenjamin/DirekturPlaystore")]
        public string HasilCheckKTPPenjaminDirekturPlaystore { get; set; }
        public string KeteranganKartuKeluarga { get; set; }
        public string HasilCheckKartuKeluarga { get; set; }
        public string KeteranganNPWPKomisaris { get; set; }
        public string HasilCheckNPWPKomisaris { get; set; }
        public string KeteranganNPWPDirekturUtama { get; set; }
        public string HasilCheckNPWPDirekturUtama { get; set; }
        public string KeteranganNPWPDirektur { get; set; }
        public string HasilCheckNPWPDirektur { get; set; }
        public string KetBuktiKepemilikanRumah { get; set; }
        public string HasilCheckBuktiKepemilikanRumah { get; set; }
        public string BentukBuktiKepemilikanRumah { get; set; }
        public string KeteranganRekening { get; set; }
        public string HasilCheckRekening { get; set; }
        public string KetSurveyEmergencyContact { get; set; }
        public string HasilCheckSurveyEmergencyContact { get; set; }
        public string KeteranganSTNK { get; set; }
        public string StatusBerlakuSTNK { get; set; }
        public DateTime? ExpiredDateSTNKBPKB { get; set; }
        public string KeteranganMedsos { get; set; }
        public string HasilCheckMedsos { get; set; }
        public string SitusSumberInfoMedsos { get; set; }
        [Column("KeteranganCheckSurveyDomisiliPemohon/perusahaan")]
        public string KeteranganCheckSurveyDomisiliPemohonperusahaan { get; set; }
        [Column("HasilCheckSurveyDomisiliPemohon/perusahaan")]
        public string HasilCheckSurveyDomisiliPemohonperusahaan { get; set; }
        public string KeteranganSurveyKantor { get; set; }
        public string HasilCheckSurveyKantor { get; set; }
        public string KeteranganSurveyUsaha { get; set; }
        public string HasilCheckSurveyUsaha { get; set; }
        [Column("KetSurveyLingkunganRTRW/perusahaan")]
        public string KetSurveyLingkunganRTRWperusahaan { get; set; }
        [Column("HasilCheckSurveyLigkunganRTRW/perusahaan")]
        public string HasilCheckSurveyLigkunganRTRWperusahaan { get; set; }
        [Column("KeteranganSurveyDomisiliPenjamin/PenggunaUnit")]
        public string KeteranganSurveyDomisiliPenjaminPenggunaUnit { get; set; }
        [Column("HasilCheckSurveyDomisiliPenjamin/PenggunaUnit")]
        public string HasilCheckSurveyDomisiliPenjaminPenggunaUnit { get; set; }
        public string KetSurveyTaksasiUnit { get; set; }
        public string HasilCheckSurveyTaksasiUnit { get; set; }
        [Column("StatusAPPIPemohon/BadanHukum")]
        public string StatusAPPIPemohonBadanHukum { get; set; }
        [Column("NominalAPPIPemohon/BadanHukum")]
        public string NominalAPPIPemohonBadanHukum { get; set; }
        [Column("StatusAPPIPasangan/Komisaris")]
        public string StatusAPPIPasanganKomisaris { get; set; }
        public string NominalAPPIPasanganKomisaris { get; set; }
        [Column("StatusAPPIPenjamin/Direktur")]
        public string StatusAPPIPenjaminDirektur { get; set; }
        [Column("NominalAPPIPenjamin/Direktur")]
        public string NominalAPPIPenjaminDirektur { get; set; }
        public string KeteranganRekeningKoran { get; set; }
        public string HasilCheckRekeningKoran { get; set; }
        public string NominalAPPIBadanHukumCurrency { get; set; }
        public string NominalAPPIKomisarisCurrency { get; set; }
        public string NominalAPPIDirekturCurrency { get; set; }
        public string DSR { get; set; }
        public string LTV { get; set; }
        public string FinalApprover { get; set; }
        public string positive_aspects { get; set; }
        public string negative_aspects { get; set; }
        public string CA_status { get; set; }
        public string CA_decision { get; set; }
        public string credit_analysis { get; set; }
    }
}
