using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
    }
}
