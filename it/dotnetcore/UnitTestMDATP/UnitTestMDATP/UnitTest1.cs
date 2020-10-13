using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
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

        [TestMethod]
        public async Task TestMethodGetAlertsUsingHttpClient()
        {
            HttpClient client = new HttpClient();

            string alertsUrl = "https://api.securitycenter.windows.com/api/alerts";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, alertsUrl);
            
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Auth.GetToken());

            HttpResponseMessage response = client.SendAsync(request).GetAwaiter().GetResult();

            string alerts = await response.Content.ReadAsStringAsync();

            Console.WriteLine(alerts);
        }

        [TestMethod]
        public void TestMethodGetAlertsUsingRestClient()
        {
            // Client
            IRestClient client = new RestClient("https://api.securitycenter.windows.com/api/alerts");

            // Request
            IRestRequest request = new RestRequest(Method.GET);

            // TODO: Replace with 'AddJsonBody to tell RestSharp how to serialize the body...'
            request.RequestFormat = DataFormat.Json;
            // request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {Auth.GetToken()}");

            // Response
            IRestResponse response = client.Execute(request);
            
            Console.WriteLine(response.Content);
        }
    }
}
