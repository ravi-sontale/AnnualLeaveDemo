using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace AnnualLeave.Data
{
    public class CommBankLeaveRuleManager : EmployeeLeaveRuleManager
    {
        //as per fiscle year
        private readonly DateTime _financialYearStartDate = Convert.ToDateTime("01/07/2015");
        private readonly DateTime _financialYearendDate = Convert.ToDateTime("30/06/2016");

        public override double GetAccoumulatedLeaves(DateTime joiningDate, int employeeId)
        {
            //rule specific to commbank for annual leaves
            //The leave accumulates gradually during the year and any unused annual leave will roll over from year to year
            if (joiningDate >= _financialYearStartDate && joiningDate < _financialYearendDate)
            {
                var diffMonths = (_financialYearendDate.Month + _financialYearendDate.Year * 12) - (joiningDate.Month + joiningDate.Year * 12);

                return diffMonths*2; //Two leaves each month
            }
            return 0;
        }

    }
}
