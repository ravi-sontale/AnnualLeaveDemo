using System;
using AnnualLeave.Data;
using AnnualLeave.Infrastructure;
using AnnualLeave.Models;
using AnnualLeave.Services;
using log4net;
using log4net.Core;

namespace AnnualLeave.Services
{
    public class FujiXeroxLeaveService : IEmployeeLeaveService
    {
        private readonly IEmployeeLeaveAdapter _employeeLeaveAdapter;
        private readonly ILog _logger;
        private readonly ILeaveRuleFactory _factory;
        public FujiXeroxLeaveService(ILeaveRuleFactory factory,IEmployeeLeaveAdapter employeeLeaveAdapter, ILog logger)
        {
            _employeeLeaveAdapter = employeeLeaveAdapter;
            _logger = logger;
            _factory = factory;
        }

        public void ProcessLeaveRequest(DateTime leaveStartDate, int days, string reason, int employeeId)
        {
            try
            {
                //do some validation specific to Fuji
                var fujiRuleManager = _factory.Create<FujiXeroxLeaveRuleManager>();
                var leaves = fujiRuleManager.GetAccoumulatedLeaves(Convert.ToDateTime("02/02/2015"), 100001);
                if (leaves > days)
                {
                    //check for supporting docs needed or not
                    if (!fujiRuleManager.ProvideSupportingDocsForSickLeave(leaveStartDate, days))
                        _employeeLeaveAdapter.ProcessLeaveRequest(leaveStartDate, days, reason, employeeId);
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Error in [ProcessLeaveRequest] : {0}", ex.InnerException);
            }
        }

        public void SaveLeaveRequest(EmployeeLeaveRequest leaveRequest)
        {
            try
            {
                //do some validation specific to Fuji
                _employeeLeaveAdapter.SaveLeaveRequest(leaveRequest);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Error in [SaveLeaveRequest] : {0}", ex.InnerException);
            }
        }
    }
}
