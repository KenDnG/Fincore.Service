﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class sp_get_data_order_source_TPResult
    {
        public int JobTitleId { get; set; }
        public int PersonnelId { get; set; }
        public string JobTitleDescription { get; set; }
        public string PersonnelName { get; set; }
        public decimal AmountProvisiRefund { get; set; }
        public decimal AmountProvisiRefundAfterTax { get; set; }
    }
}
