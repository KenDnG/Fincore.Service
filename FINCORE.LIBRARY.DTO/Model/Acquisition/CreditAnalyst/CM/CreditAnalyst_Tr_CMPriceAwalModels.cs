using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst.CM
{
    public class CreditAnalyst_Tr_CMPriceAwalModels
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string? CreditId { get; set; }
        public byte? Tenor { get; set; }
        public decimal? AssetCost { get; set; }
        public decimal? GrossDownPayment { get; set; }
        public decimal? AdminFee { get; set; }
        public decimal? InsuranceFee { get; set; }
        public decimal? NettDownPayment { get; set; }
        public decimal? JmlPembiayaan { get; set; }
        public decimal? AmountInstallment { get; set; }
        public decimal? RateValue { get; set; }
        public decimal? EffectiveRate { get; set; }
        public decimal? FlatRate { get; set; }
        public decimal? PersenNfa { get; set; }
        public decimal? MdpsAwal { get; set; }
        public decimal? MdpsCurr { get; set; }
        public decimal? Subsidi { get; set; }
        public decimal? TotalUppingOtr { get; set; }
        public int? CountUppingOtr { get; set; }
        public decimal? DiscDeposit { get; set; }
        public decimal? BiayaProvisiIns { get; set; }
        public string? TypeKonversi { get; set; } = string.Empty;
    }
}
