namespace FINCORE.LIBRARY.DTO.Model.Acquisition.CAS
{
    public class TrCasApupptModels
    {
        public string created_by { get; set; }
        public DateTime? created_on { get; set; }
        public string credit_id { get; set; }
        public int[] question_id { get; set; }
        public string[] answer { get; set; }
        public string question_flag { get; set; }
    }
}