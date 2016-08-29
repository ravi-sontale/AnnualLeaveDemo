using System;
using AnnualLeave.Data;
using AnnualLeave.Infrastructure;
using AnnualLeave.Models;
using log4net;

namespace AnnualLeave.Services
{
    public class CommBankLeaveService : IEmployeeLeaveService
    {
        private readonly IEmployeeLeaveAdapter _employeeLeaveAdapter;
        private readonly ILog _logger;
        private readonly ILeaveRuleFactory _factory;

        public CommBankLeaveService(ILeaveRuleFactory factory, IEmployeeLeaveAdapter employeeLeaveAdapter, ILog logger)
        {
            _employeeLeaveAdapter = employeeLeaveAdapter;
            _logger = logger;
            _factory = factory;
        }

        public void ProcessLeaveRequest(DateTime leaveStartDate, int days, string reason, int employeeId)
        {
            try
            {
                //Commabank related validations other business logic
                var commBankRuleManager = _factory.Create<CommBankLeaveRuleManager>();
                var leaves = commBankRuleManager.GetAccoumulatedLeaves(Convert.ToDateTime("10/08/2015"), 1234);

                if (leaves > days)
                    _employeeLeaveAdapter.ProcessLeaveRequest(leaveStartDate, days, reason, employeeId);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("[ProcessLeave] Unable to process Leave Request due to following error: {0}", ex.InnerException);
            }
        }

        public void SaveLeaveRequest(EmployeeLeaveRequest leaveRequest)
        {
            try
            {
                //Commabank related validations other business logic
                _employeeLeaveAdapter.SaveLeaveRequest(leaveRequest);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("[SaveLeaveRequest] Unable to Save Leave Request due to following error: {0}", ex.InnerException);
            }
        }
    }
}
