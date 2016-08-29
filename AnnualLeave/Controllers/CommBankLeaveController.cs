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
    public class CommBankLeaveController
    {
        private readonly IEmployeeLeaveService _employeeService;
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CommBankLeaveController(IEmployeeLeaveService service)
        {
            _employeeService = service;
        }

        public CommBankLeaveController() : this(new CommBankLeaveService(new LeaveRuleFactory(), new EmployeeLeaveAdapter(),Log)){}

        public void ProcessLeaveRequest()
        {
            _employeeService.ProcessLeaveRequest(DateTime.Now, 3, "Personal Work", 1234);
        }
    }
}
