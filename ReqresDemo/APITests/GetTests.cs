using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ReqresDemo.Model;
using ReqresDemo.Utilities;
using RestSharp;
using AventStack.ExtentReports;

namespace APITests
{
    [TestClass]
    public class GetTests
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
            var dir = testContext.TestRunDirectory;
            Reporter.SetupExtentReport("Reqres API Test", "Reqres API Test Report", dir);
        }

        [TestInitialize]

        public void SetUpTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;

            Status logStatus;

            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    logStatus = Status.Fail;
                    Reporter.TestStatus(logStatus.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;
            }
        }

        [ClassCleanup]

        public static void CleanUp()
        {
            Reporter.FlushReport();
        }

        [TestMethod]
        public void GetAllUser()
        {
            var testHelper = new TestHelper<ListUsers>();
            var user = testHelper.GetAllUserHelper("api/users?page=2");

            Assert.AreEqual(2, user.Page);

            Reporter.LogToReport(Status.Fail, "Page no not matched");

            Assert.AreEqual("Michael", user.Data[0].first_name);

            Reporter.LogToReport(Status.Fail, "User fn not matched");
        }

    }
}
