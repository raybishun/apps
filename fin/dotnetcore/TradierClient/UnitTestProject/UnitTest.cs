using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UnitTestProject.Helpers;
using System.Text.RegularExpressions;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        private readonly string[] creds = SecureStore.GetCreds().Split(',');

        private string accessToken = string.Empty;
        public string AccessToken
        {
            get 
            {
                return accessToken;
            }
            set 
            {
                Assert.IsTrue(Regex.IsMatch(creds[0], "^[a-zA-Z0-9]*$"));

                if (Regex.IsMatch(creds[0], "^[a-zA-Z0-9]*$"))
                {
                    accessToken = creds[0];
                }
            }
        }
        
        private string uri = string.Empty;
        public string Uri
        {
            get 
            {
                return uri;
            }
            set 
            {
                Assert.IsTrue(Regex.IsMatch(creds[1], "^https?://"));
                // Assert.IsTrue(Regex.IsMatch(creds[1], "^(https|https)://"));

                if (Regex.IsMatch(creds[1], "^https?://"))
                {
                    uri = creds[1];
                }
            }
        }

        public string TestGetQuoteAsJson(string symbol)
        {
            Assert.AreEqual(2, creds.Length);
            AccessToken = creds[0];
            Uri = creds[1];

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

                Task<HttpResponseMessage> httpResponseMessage = httpClient.GetAsync($"{Uri}{symbol}");

                Assert.AreEqual(200, (int)httpResponseMessage.Result.StatusCode);

                if (httpResponseMessage.Result.IsSuccessStatusCode)
                {
                    return httpResponseMessage.Result.Content.ReadAsStringAsync().Result;
                }

                return httpResponseMessage.Result.ReasonPhrase;
            }
        }

        [TestMethod]
        public void TestGetQuote()
        {
            Console.WriteLine(TestGetQuoteAsJson("msft"));
        }
    }
}