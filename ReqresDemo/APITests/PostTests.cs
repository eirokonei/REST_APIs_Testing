using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReqresDemo.Model;
using ReqresDemo.Utilities;
using System;


namespace APITests
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void CreateNewUser()
        {
            string payLoad = @"{
                                ""name"": ""XYZ"",
                                ""job"": ""Helper"" 
                               }";

            var testHelper = new TestHelper<CreateUser>();
            var user = testHelper.CreateNewUserTest("api/users", payLoad);

            Assert.AreEqual("XYZ", user.Name);
            Assert.AreEqual("Helper", user.Job);
        }
    }
}
