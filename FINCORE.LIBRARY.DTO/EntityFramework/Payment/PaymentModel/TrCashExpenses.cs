﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentModel
{
    public partial class TrCashExpenses
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string SourceTypeId { get; set; }
        public string SessionId { get; set; }
        public string BranchId { get; set; }
        public string CreditId { get; set; }
        public DateTime ExpensesDate { get; set; }
        public decimal Amount { get; set; }
        public string VerifyBy { get; set; }
        public DateTime VerifyDate { get; set; }
        public bool FlagDepositBank { get; set; }
    }
}