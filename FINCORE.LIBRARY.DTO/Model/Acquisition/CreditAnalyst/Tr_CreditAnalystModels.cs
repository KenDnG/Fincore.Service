using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst.CA_Financial;
using FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst.CAS;
using FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst.CAS.CAS_Reference;
using FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst.CM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CreditAnalyst
{
    public class Tr_CreditAnalystModels
    {
        public string? CANo { get; set; }
        public string? CreditId { get; set; }
        public string? Clik { get; set; }
        public string? ApprovalSchemeID { get; set; }
        public string? ApprovalSchemeDesc { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public CreditAnalyst_Tr_CAModels? tr_CA { get; set; }
        public CreditAnalystDocumentModels? tr_CADocument { get; set; }
        public CreditAnalyst_FinancialUtamaModels? financialUtama { get; set; }
        public CreditAnalyst_FinancialTambahanModels? financialTambahan { get; set; }
        public CreditAnalyst_FinancialPasanganModels? financialPasangan { get; set; }
        public CreditAnalyst_CASModels? tr_CAS { get; set; }
        public CreditAnalyst_CASReferenceReferensiModels? referenceReferensi { get; set; }
        public CreditAnalyst_CASReferencePasanganModels? referencePasangan { get; set; }
        public CreditAnalyst_CASReferencePenjaminModels? referencePenjamin { get; set; }
        public CreditAnalyst_Tr_CMModels? tr_CM { get; set; }
        public List<CreditAnalystSLikModels>? Slik { get; set; }
        public CreditAnalyst_Tr_CMPriceAwalModels? tr_CMPriceAwal { get; set; }
        public List<CreditAnalystDetailModels>? DetailRekening { get; set; }

    }
}
