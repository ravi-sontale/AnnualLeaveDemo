using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnualLeave.Data;

using log4net;

namespace AnnualLeave.Infrastructure
{
    public class LeaveRuleFactory : ILeaveRuleFactory
    {
        public T Create<T>()
           where T : EmployeeLeaveRuleManager
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}
