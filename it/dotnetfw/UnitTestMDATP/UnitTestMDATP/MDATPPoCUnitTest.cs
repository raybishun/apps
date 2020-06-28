using System;
using System.IO;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace UnitTestMDATP
{
    [TestClass]
    public class MDATPPoCUnitTest
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
        
        [TestMethod]
        public void TestMethodUsingADAL()
        {
            // Reference:
            // 1. https://www.nuget.org/packages/Microsoft.IdentityModel.Clients.ActiveDirectory/

            string path = @"C:\SecureStore\BBS_Get_ATP_Alerts.txt";
            string[] creds = File.ReadAllLines(path);

            string tenantId = creds[0];
            string appId = creds[1];
            string appSecret = creds[2];

            const string authority = "https://login.windows.net";
            const string wdatpResourceId = "https://api.securitycenter.windows.com";

            AuthenticationContext auth = new AuthenticationContext($"{authority}/{tenantId}/");
            ClientCredential clientCredential = new ClientCredential(appId, appSecret);
            AuthenticationResult authenticationResult = auth.AcquireTokenAsync(wdatpResourceId, clientCredential).GetAwaiter().GetResult();
            string token = authenticationResult.AccessToken;

            Console.WriteLine(token);
        }
    }
}
