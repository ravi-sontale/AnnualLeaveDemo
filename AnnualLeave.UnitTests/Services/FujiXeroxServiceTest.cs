using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using AnnualLeave.Data;
using AnnualLeave.Infrastructure;
using AnnualLeave.Models;
using AnnualLeave.Services;
using log4net;
using NSubstitute;
using NUnit.Framework;

namespace AnnualLeave.UnitTests.Services
{
    [TestFixture]
    public class FujiXeroxServiceTest
    {
        private FujiXeroxLeaveService _fujiXeroxLeaveService;
        private IEmployeeLeaveAdapter _employeeLeaveAdapter;
        private ILog _log;
        private ILeaveRuleFactory _factory;
        private DateTime _startDate;
        private int _noOfDays;
        private string _reason;
        private int _empId;
        private EmployeeLeaveRequest _employeeLeaveRequest;

        [SetUp]
        public void SetUp()
        {
            _employeeLeaveAdapter = Substitute.For<IEmployeeLeaveAdapter>();
            _log = Substitute.For<ILog>();
            _factory = Substitute.For<ILeaveRuleFactory>();
            _fujiXeroxLeaveService = new FujiXeroxLeaveService(_factory, _employeeLeaveAdapter, _log);
            _startDate = DateTime.Now;
            _noOfDays = 2;
            _reason = " Personal Work";
            _empId = 1234;
            _employeeLeaveRequest = new EmployeeLeaveRequest
            {
                EmployeeId = 1234,
                IsApproved = false,
                LeaveStartDateTime = DateTime.Now,
                LeaveEndDateTime = DateTime.Now.AddDays(2)
            };
        }

        [Test]
        public void CommBank_Service_Should_Process_Leave_Request_Using_Adapter()
        {
            var counter = 0;

            //Arrange
            _employeeLeaveAdapter.When(x => x.ProcessLeaveRequest(Arg.Any<DateTime>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<int>()))
                .Do(x => counter++);
            
            //Act
            _employeeLeaveAdapter.ProcessLeaveRequest(_startDate, _noOfDays, _reason, _empId);

            //Assert
            Assert.AreEqual(1, counter);
        }

        [Test]
        public void CommBank_Service_Should_Save_Leave_Request_Using_Adapter()
        {
            var counter = 0;
            
            //Arrange
            _employeeLeaveAdapter.When(x => x.SaveLeaveRequest(Arg.Any<EmployeeLeaveRequest>()))
                .Do(x => counter++);
            
            //Act
            _employeeLeaveAdapter.SaveLeaveRequest(_employeeLeaveRequest);
            
            //Assert
            Assert.AreEqual(1, counter);
        }
    }
}
