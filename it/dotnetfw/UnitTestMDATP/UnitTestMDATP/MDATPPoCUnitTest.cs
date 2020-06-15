using System;
using System.IO;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using UnitTestMDATP.DropBoxModel;

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

        [TestMethod]
        public void TestMethodDropBoxListFolder()
        {
            string listFolderUrl = "https://api.dropboxapi.com/2/files/list_folder";

            string[] creds = SecureStoreHelper.GetCreds(@"C:\SecureStore\dropbox_app_token_endpoint_list_folder.txt").Split(',');
            string accessToken = creds[0];

            string body =
                "{\"path\": \"\",\"recursive\": false,\"include_media_info\": false,\"include_deleted\": false,\"include_has_explicit_shared_members\": false,\"include_mounted_folders\": true,\"include_non_downloadable_files\": true}";

            IRestClient client = new RestClient();
            
            IRestRequest request = new RestRequest() { Resource = listFolderUrl };
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(body);

            IRestResponse response = client.Post<RootObject>(request);

            Assert.AreEqual(200, (int)response.StatusCode);

            Console.WriteLine(response.Content);
        }
    }
}
