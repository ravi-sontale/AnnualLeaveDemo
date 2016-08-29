using System;
using AnnualLeave.Data;
using AnnualLeave.Models;

namespace AnnualLeave.Services
{
    public interface IEmployeeLeaveService
    {
        void ProcessLeaveRequest(DateTime leaveStartDate, int days, string reason, int employeeId);
        void SaveLeaveRequest(EmployeeLeaveRequest leaveRequest);
    }
}
