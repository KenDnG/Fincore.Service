﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel
{
    public partial class sp_print_npp_power_of_attorney_fidusiaResult
    {
        public string CreditId { get; set; }
        public string AgreementDate { get; set; }
        public string CustomerName { get; set; }
        public string Occupation { get; set; }
        public string IdentityNumber { get; set; }
        public string CustomerAddress { get; set; }
        public string OnBehalfOf { get; set; }
        public string PowerAttorneyName { get; set; }
        public string PowerAttorneyPosition { get; set; }
        public string PowerAttorneyAddress { get; set; }
        public string MCFHOAdress { get; set; }
        public string MAFHOAdress { get; set; }
        public string MCFBranchAddress { get; set; }
        public string MAFBranchAddress { get; set; }
        public decimal DebtAmount { get; set; }
        public string DebtAmountFormatted { get; set; }
        public string LetterDateDayMonth { get; set; }
        public string LetterDateYear { get; set; }
        public string BranchName { get; set; }
    }
}
