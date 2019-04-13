using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

namespace TestLineSystem
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUserClassConstructor()
        {
            User user1 = new User("Anders", "Springborg", "888_aaen", "aaspringborg@gmail.com");


            Assert.AreEqual("Anders", user1.FirstName);
            Assert.AreEqual("Springborg", user1.LastName);
            Assert.AreEqual((UInt32)101, user1.MyId);
            Assert.AreEqual("888_aaen", user1.UserName);
        }
    }
}
