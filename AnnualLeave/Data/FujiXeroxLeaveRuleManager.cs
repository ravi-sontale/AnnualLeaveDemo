using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnualLeave.Data
{
    public class FujiXeroxLeaveRuleManager : EmployeeLeaveRuleManager
    {
        //as per calendar year
        private readonly DateTime _financialYearStartDate = Convert.ToDateTime("01/01/2015");
        private readonly DateTime _financialYearendDate = Convert.ToDateTime("31/12/2016");

        public override double GetAccoumulatedLeaves(DateTime joiningDate, int employeeId)
        {
            //rule specific to commbank for annual leaves
            //The leave accumulates gradually during the year and any unused annual leave will roll over from year to year
            if (joiningDate >= _financialYearStartDate && joiningDate < _financialYearendDate)
            {
                var diffMonths = (_financialYearendDate.Month + _financialYearendDate.Year * 12) - (joiningDate.Month + joiningDate.Year * 12);

                return diffMonths * 1.5; //1.5 leaves each month
            }
            return 0;
        }

        //
        public bool ProvideSupportingDocsForSickLeave(DateTime leaveStartDate, int days)
        {
            return days > 3;
        }
    }
}
