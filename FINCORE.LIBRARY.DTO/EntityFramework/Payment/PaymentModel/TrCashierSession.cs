﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentModel
{
    public partial class TrCashierSession
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public string BranchId { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public bool IsDeposit { get; set; }
        public string CloseBy { get; set; }
        public string VerifyBy { get; set; }
        public DateTime? VerifyDate { get; set; }
        public decimal? CloseAmount { get; set; }
        public decimal? CurrentAmount { get; set; }
        public decimal? CashAmount { get; set; }
    }
}