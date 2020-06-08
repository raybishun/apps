using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace UnitTestMDATP
{
    [TestClass]
    public class MDATPPoCUnitTest
    {
        [TestMethod]
        public void TestMethodHelloWorld()
        {
            // Use a hosted REST-API to test requests at: https://reqres.in/
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("/api/users/2", DataFormat.Json);
            var response = client.Get(request);
            Console.WriteLine(response.Content);
        }
    }
}
