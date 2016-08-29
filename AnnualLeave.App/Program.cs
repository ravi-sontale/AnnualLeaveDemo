using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnualLeave.Controllers;
using AnnualLeave.Data;
using AnnualLeave.Infrastructure;
using AnnualLeave.Services;
using log4net;

namespace AnnualLeave.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var commBankConsumer = new CommBankLeaveController();
            commBankConsumer.ProcessLeaveRequest();

            var fujiConsumer = new FujiLeaveController();
            fujiConsumer.ProcessLeaveRequest();
        }
    }
}
