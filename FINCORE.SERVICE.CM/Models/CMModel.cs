﻿namespace FINCORE.SERVICE.CM.Models
{
    public class CMModel
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal? LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string? credit_id { get; set; }

        public string? is_item_new { get; set; }

        public string? application_type_id { get; set; }
        public string? application_type_name { get; set; }

        public string? product_finance_id { get; set; }
        public string? product_finance_name { get; set; }

        public string? item_brand_id { get; set; }
        public string? item_brand { get; set; }

        public string? asset_kind_id { get; set; }
        public string? asset_kind_class_id { get; set; }
        public string? asset_kind_class_name { get; set; }

        public string? year { get; set; }

        public string? product_id { get; set; }
        public string? product_name { get; set; }

        public string? product_marketing_id { get; set; }
        public string? product_marketing_name { get; set; }

        public string? STNK_name_id { get; set; }
        public string? STNK_name_description { get; set; }

        public string? provenance_PO_id { get; set; }
        public string? provenance_PO_description { get; set; }

        public string? usage_type_id { get; set; }
        public string? usage_type_name { get; set; }

        public string? item_brand_type_id { get; set; }
        public string? item_type_name { get; set; }

        public string? dealer_code { get; set; }
        public string? dealer_name { get; set; }

        public string? surveyor_id { get; set; }
        public string? surveyor_name { get; set; }

        public string? marketinghead_id { get; set; }
        public string? marketinghead_name { get; set; }

        public string? CGSCabangNo { get; set; }

        public string? CC { get; set; }
        public string? account_receiveable { get; set; }
        public string? tipe_cover { get; set; }
        public string? insurance_type_id { get; set; }
        public string? interest_rate_type_id { get; set; }

        public string? tenor { get; set; }
        public string? asset_cost { get; set; }
        public string? gross_down_payment { get; set; }
        public string? admin_fee { get; set; }
        public string? biaya_provisi { get; set; }
        public string? insurance_fee { get; set; }
        public string? uang_muka_murni_kons { get; set; }
        public string? jml_pembiayaan { get; set; }
        public string? amount_installment { get; set; }
        public string? effective_rate { get; set; }
        public string? flat_rate { get; set; }
        public string? disc_deposit { get; set; }
        public string? overdue_rate { get; set; }
        public string? TAC_max { get; set; }
        public string? komper_max { get; set; }
    }
}