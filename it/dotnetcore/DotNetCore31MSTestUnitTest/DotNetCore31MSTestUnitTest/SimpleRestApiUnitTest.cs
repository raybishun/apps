using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;

namespace DotNetCore31MSTestUnitTest
{
    [TestClass]
    public class SimpleRestApiUnitTest
    {
        [TestMethod]
        public void TestMethodRestSharp()
        {
            string baseUrl = "https://reqres.in/";
            string resource = "/api/users/2";

            IRestClient client = new RestClient(baseUrl);
            IRestRequest request = new RestRequest(resource, DataFormat.Json);
            IRestResponse response = client.Get(request);

            Console.WriteLine(response.Content);
        }
    }
}
