using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace UnitTestMDATP
{
    [TestClass]
    public class MDATPUnitTest
    {
        [TestMethod]
        public void TestMethodHelloWorld()
        {
            // Reference:
            // Demo REST-API to test requests at: https://reqres.in/

            string baseUrl = "https://reqres.in/";
            string resource = "/api/users/2";

            IRestClient client = new RestClient(baseUrl);
            IRestRequest request = new RestRequest(resource, DataFormat.Json);
            IRestResponse response = client.Get(request);

            Console.WriteLine(response.Content);
        }

        string tenantId     = string.Empty;
        string appId        = string.Empty;
        string appSecret    = string.Empty;
        string token        = string.Empty;

        public void GetTenantInfo()
        {
            string path = @"C:\SecureStore\BBS_Get_ATP_Alerts.txt";

            string[] creds = File.ReadAllLines(path);

            tenantId = creds[0];
            appId = creds[1];
            appSecret = creds[2];
        }

        public void GetTokenUsingADAL()
        {
            // Reference:
            // 1. https://www.nuget.org/packages/Microsoft.IdentityModel.Clients.ActiveDirectory/

            const string authority = "https://login.windows.net";
            const string wdatpResourceId = "https://api.securitycenter.windows.com";

            AuthenticationContext auth = new AuthenticationContext($"{authority}/{tenantId}/");
            ClientCredential clientCredential = new ClientCredential(appId, appSecret);
            AuthenticationResult authenticationResult = auth.AcquireTokenAsync(wdatpResourceId, clientCredential).GetAwaiter().GetResult();

            // Token valid for 1 hour

            // Validate the token at: https://jwt.ms/, this will:
            // 1. Decode the token (into JSON)
            // 2. Explain the Claim types and their values

            token = authenticationResult.AccessToken;
        }

        [TestMethod]
        public async Task TestMethodGetAlertsUsingHttpClient()
        {
            GetTenantInfo();
            GetTokenUsingADAL();

            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.securitycenter.windows.com/api/alerts");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = httpClient.SendAsync(request).GetAwaiter().GetResult();

            var payload = await response.Content.ReadAsStringAsync();

            Console.WriteLine(payload);
        }

        [TestMethod]
        public void TestMethodGetAlertsUsingRestClient() { }
        
    }
}
