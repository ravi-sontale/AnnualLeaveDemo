using System;
using System.Data.SqlClient;

namespace AnnualLeave.Data
{
    public abstract class EmployeeLeaveRuleManager
    {
        public abstract double GetAccoumulatedLeaves(DateTime joiningDate, int employeeId);

        public double SetMaxAnnualLeave(bool isPartTime, double hrsPerWeek)
        {
            //total number of leaves = 4 weeks
            return isPartTime ? 10 : 20;
        }
    }
}
