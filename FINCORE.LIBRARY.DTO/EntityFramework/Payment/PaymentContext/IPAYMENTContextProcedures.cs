﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentContext
{
    public partial interface IPAYMENTContextProcedures
    {
        Task<List<sp_get_pagination_cashier_sessionResult>> sp_get_pagination_cashier_sessionAsync(string BranchId, string SearchTerm, OutputParameter<int?> PageIndex, OutputParameter<int?> PageSize, OutputParameter<int?> TotalPages, OutputParameter<double?> RecordCount, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<sp_get_pagination_cashier_session_expensesResult>> sp_get_pagination_cashier_session_expensesAsync(string BranchId, string SessionId, string SearchTerm, OutputParameter<int?> PageIndex, OutputParameter<int?> PageSize, OutputParameter<int?> TotalPages, OutputParameter<double?> RecordCount, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<sp_get_pagination_cashier_session_verifyResult>> sp_get_pagination_cashier_session_verifyAsync(string BranchId, string SearchTerm, OutputParameter<int?> PageIndex, OutputParameter<int?> PageSize, OutputParameter<int?> TotalPages, OutputParameter<double?> RecordCount, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<sp_update_cashier_session_verifyResult>> sp_update_cashier_session_verifyAsync(string SessionId, string EmployeeId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}