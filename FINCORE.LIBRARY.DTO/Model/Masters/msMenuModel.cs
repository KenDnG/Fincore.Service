namespace FINCORE.LIBRARY.DTO.Model.Masters
{
    public class trMenuModel
    {
        public string module_name { get; set; }
        public int module_sort { get; set; }
        public List<child> childs { get; set; }
    }

    public class child
    {
        public string menu_title { get; set; }
        public string menu_sort { get; set; }
        public string controller { get; set; }
        public string action { get; set; }
    }
}