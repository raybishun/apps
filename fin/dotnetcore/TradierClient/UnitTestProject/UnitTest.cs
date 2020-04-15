using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UnitTestProject.Helpers;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnitTestProject.Models.JsonModel;
using Newtonsoft.Json;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        #region Fields & Properties
        private readonly string[] creds = SecureStoreHeler.GetCreds().Split(',');

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

        // NOTE: Not using HttpClient within a Using statement, so as to
        // avoid instantiating a new HttpClient for subsequent requests,
        // as this can lead to socket exhaustion per 'Improper Instantiation AntiPattern' described:
        // https://docs.microsoft.com/en-us/azure/architecture/antipatterns/improper-instantiation/

        private readonly HttpClient httpClient = new HttpClient();
        private HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
        #endregion

        public async Task<string> GetQuoteAsStringAsync(string queryString)
        {
            Assert.AreEqual(2, creds.Length);
            AccessToken = creds[0];
            Uri = creds[1];

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

            using (httpResponseMessage = await httpClient.GetAsync($"{Uri}{queryString}"))
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();

                return content;
            }
        }
        
        public async Task<QuoteRootObject> GetQuoteAsJsonAsync(string queryString)
        {
            Assert.AreEqual(2, creds.Length);
            AccessToken = creds[0];
            Uri = creds[1];

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

            using (httpResponseMessage = await httpClient.GetAsync($"{Uri}{queryString}"))
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    // QuoteRootObject quoteRootObject = JsonConvert.DeserializeObject<QuoteRootObject>(content);
                    QuoteRootObject quoteRootObject = ResponseDataHelper.DeserializeStringToJson<QuoteRootObject>(content);
                    return quoteRootObject;
                }

                return new QuoteRootObject();
            }
        }

        // Clients
        [TestMethod]
        public void TestGetQuoteAsString()
        {
            Console.WriteLine(GetQuoteAsStringAsync("msft").Result);
        }

        [TestMethod]
        public void TestGetQuoteAsJson()
        {
            //var msft = GetQuoteAsJsonAsync("msft");
            //Console.WriteLine(msft.Result.Quotes.Quote.Description);

            var msft = GetQuoteAsJsonAsync("msft").Result;
            Console.WriteLine(msft.Quotes.Quote.Description);
        }
        
        // TODO: Fix call from async method

        //[TestMethod]
        //public async void TestGetQuoteAsJsonAsync()
        //{
        //    var msft = await GetQuoteAsJsonAsync("msft");
        //    Console.WriteLine(msft.Quotes.Quote.Description);
        //}
    }
}