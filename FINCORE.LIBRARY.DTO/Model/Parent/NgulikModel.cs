using FINCORE.LIBRARY.DTO.Model.Acquisition;

namespace FINCORE.LIBRARY.DTO.Model.Parent
{
    public class NgulikModel
    {
        public CreditModel casModel { get; set; }
        public CreditTypeModel creditTypeModel { get; set; }
        //TODO: List Model
        //public List<CreditTypeModel> creditTypeModel { get; set; }
    }
}