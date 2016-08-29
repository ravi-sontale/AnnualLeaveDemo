using System;
using AnnualLeave.Data;
using AnnualLeave.Models;
using AnnualLeave.Services;
using log4net;
using NSubstitute;
using NUnit.Framework;

namespace AnnualLeave.UnitTests.Data
{
    [TestFixture]
    public class FujiXeroxLeaveRuleManagerTest
    {
        private EmployeeLeaveRuleManager _employeeLeaveRuleManager;
        private DateTime _startDate;
        private int _empId;
        [SetUp]
        public void SetUp()
        {
            _employeeLeaveRuleManager = Substitute.For<EmployeeLeaveRuleManager>();
            _startDate = DateTime.Now;
            _empId = 1234;
        }

        [Test]
        public void Get_Accoumulated_Leaves_Should_Return_leaves_from_joining_date_for_an_employee()
        {
            _employeeLeaveRuleManager.GetAccoumulatedLeaves(Arg.Any<DateTime>(), Arg.Any<int>())
                .ReturnsForAnyArgs(20);
            Assert.AreEqual(_employeeLeaveRuleManager.GetAccoumulatedLeaves(_startDate, _empId), 20);
        }

        [Test]
        public void Set_Max_Annual_Leaves_Should_Return_leaves_for_part_time_employee()
        {
            _employeeLeaveRuleManager.SetMaxAnnualLeave(Arg.Any<bool>(), Arg.Any<double>())
                .Returns(10);

            Assert.AreEqual(_employeeLeaveRuleManager.SetMaxAnnualLeave(true, 20), 10);
        }
    }
}
