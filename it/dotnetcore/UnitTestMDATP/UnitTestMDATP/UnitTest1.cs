using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestMDATP.Utilities;

namespace UnitTestMDATP
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGetToken()
        {
            string token = Auth.GetToken();
            Console.WriteLine(token);
        }
    }
}
