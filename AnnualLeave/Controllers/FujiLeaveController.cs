using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnualLeave.Data;
using AnnualLeave.Infrastructure;
using AnnualLeave.Services;
using log4net;

namespace AnnualLeave.Controllers
{
    public class FujiLeaveController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IEmployeeLeaveService _employeeService;

        public FujiLeaveController(IEmployeeLeaveService service)
        {
            _employeeService = service;
        }

        public FujiLeaveController(): this(new FujiXeroxLeaveService(new LeaveRuleFactory(), new EmployeeLeaveAdapter(), Log)){}

        public void ProcessLeaveRequest()
        {
            var startDateTime = DateTime.Now;
            const int noOfDays = 5;
            _employeeService.ProcessLeaveRequest(startDateTime, noOfDays, "Personal Work", 100001);
        }
    }
        
}
