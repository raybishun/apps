using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using DotNetCore31MSTestUnitTest.Models;

namespace DotNetCore31MSTestUnitTest
{
    [TestClass]
    public class RestApiUnitTest
    {
        private static readonly string _baseUrl = "https://reqres.in/";
        private static readonly string _resource = "/api/users/2";
        private static readonly IRestClient _client = new RestClient(_baseUrl);
        private static readonly IRestRequest _request = new RestRequest(_resource, DataFormat.Json);
        private static readonly IRestResponse _response = _client.Get(_request);

        [TestMethod]
        public void TestMethodGet()
        {
            Console.WriteLine(_response.Content);
        }

        [TestMethod]
        public void TestMethodGetStatus()
        {
            Console.WriteLine(_response.StatusCode);
        }

        [TestMethod]
        public void AssertFromTheAAAPattern()
        {
            // Arrange
            // ...

            // Act
            // ...
            
            // Assert
            Assert.AreEqual("OK", _response.StatusCode.ToString());
        }

        [TestMethod]
        public async Task GetAsync()
        {
            IRestResponse response = await _client.ExecuteAsync(_request);
            Console.WriteLine(response.Content);
        }

        [TestMethod]
        public async Task DeserializeJsonPayload()
        {
            IRestResponse<List<TestDataRootObject>> response = await _client.ExecuteAsync<List<TestDataRootObject>>(_request);

            foreach (var item in response.Data)
            {
                Console.WriteLine(item.Data.Email);
            }
        }
    }
}
