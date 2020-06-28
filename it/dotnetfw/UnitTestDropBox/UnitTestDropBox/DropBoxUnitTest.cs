using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using UnitTestMDATP.DropBoxModel;

namespace UnitTestDropBox
{
    [TestClass]
    public class DropBoxUnitTest
    {
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
