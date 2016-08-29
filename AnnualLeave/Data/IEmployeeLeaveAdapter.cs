using System;
using AnnualLeave.Models;

namespace AnnualLeave.Data
{
    public interface IEmployeeLeaveAdapter
    {
        void ProcessLeaveRequest(DateTime leaveStartDate, int days, string reason, int employeeId);
        void SaveLeaveRequest(EmployeeLeaveRequest leaveRequest);
        Employee FindEmployee(int employeeId);
    }
}
