﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentModel
{
    public partial class sp_get_pagination_cashier_session_expensesResult
    {
        public string SessionId { get; set; }
        public DateTime OutDate { get; set; }
        public string BranchId { get; set; }
        public string SourceExpenditure { get; set; }
        public DateTime PayDate { get; set; }
        public decimal PayAmount { get; set; }
        public string ReferenceNumber { get; set; }
    }
}
