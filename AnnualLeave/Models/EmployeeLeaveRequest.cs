using System;

namespace AnnualLeave.Models
{
    public class EmployeeLeaveRequest
    {
        public int EmployeeId { get; set; }
        public DateTime LeaveStartDateTime { get; set; }
        public DateTime LeaveEndDateTime { get; set; }
        public bool IsApproved { get; set; }

    }
}