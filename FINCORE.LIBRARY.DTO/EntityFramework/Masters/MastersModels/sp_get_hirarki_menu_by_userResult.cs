﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class sp_get_hirarki_menu_by_userResult
    {
        public int module_id { get; set; }
        public string module_name { get; set; }
        public int parent_module_id { get; set; }
        public string menu_title { get; set; }
        public string menu_action { get; set; }
        public string menu_controller { get; set; }
        public int? module_sort { get; set; }
        public int? menu_sort { get; set; }
    }
}
