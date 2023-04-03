﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels
{
    public partial class MsModuleMenu
    {
        /// <summary>
        /// user yang membuat master data
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// tanggal &amp; waktu pembuatan master data
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// user yang mengubah master data
        /// </summary>
        public string LastUpdatedBy { get; set; }
        /// <summary>
        /// tanggal &amp; waktu perubahan master data
        /// </summary>
        public DateTime? LastUpdatedOn { get; set; }
        /// <summary>
        /// ID menu
        /// </summary>
        public int MenuId { get; set; }
        /// <summary>
        /// ID modul
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// ID induk modul
        /// </summary>
        public int? ParentModuleId { get; set; }
        /// <summary>
        /// judul menu
        /// </summary>
        public string MenuTitle { get; set; }
        /// <summary>
        /// indikator aktif atau tidaknya master data
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// urutan menu modul
        /// </summary>
        public int? Sequence { get; set; }
        /// <summary>
        /// menu controller
        /// </summary>
        public string MenuController { get; set; }
        /// <summary>
        /// menu action
        /// </summary>
        public string MenuAction { get; set; }
        /// <summary>
        /// menu action approved
        /// </summary>
        public string MenuActionApproved { get; set; }
        /// <summary>
        /// menu action view
        /// </summary>
        public string MenuActionView { get; set; }
        /// <summary>
        /// menu action edit
        /// </summary>
        public string MenuActionEdit { get; set; }
        /// <summary>
        /// trans type id prefix
        /// </summary>
        public string TransTypeIdPrefix { get; set; }
    }
}