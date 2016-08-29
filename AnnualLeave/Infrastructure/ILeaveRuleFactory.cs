using System;
using AnnualLeave.Data;

namespace AnnualLeave.Infrastructure
{
    public interface ILeaveRuleFactory
    {
        T Create<T>()
            where T : EmployeeLeaveRuleManager;
    }
}
