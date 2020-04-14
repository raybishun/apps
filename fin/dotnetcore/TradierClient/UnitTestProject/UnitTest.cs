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
        #endregion

        public string GetQuoteAsString(string symbol)
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

        public QuoteRootObject GetQuoteAsJson(string symbol)
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
                    string str = httpResponseMessage.Result.Content.ReadAsStringAsync().Result;

                    // QuoteRootObject quoteRootObject = JsonConvert.DeserializeObject<QuoteRootObject>(str);
                    QuoteRootObject quoteRootObject = ResponseDataHelper.DeserializeStringToJson<QuoteRootObject>(str);
                    return quoteRootObject;
                }

                return new QuoteRootObject();
            }
        }

        public async Task<QuoteRootObject> GetQuoteAsJsonAsync(string symbol)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"{Uri}{symbol}");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string str = await httpResponseMessage.Content.ReadAsStringAsync();
                    QuoteRootObject quoteRootObject = ResponseDataHelper.DeserializeStringToJson<QuoteRootObject>(str);
                    return quoteRootObject;
                }

                return new QuoteRootObject();
            }
        }

        // ====================================================================
        // Client
        // ====================================================================
        [TestMethod]
        public void TestGetQuoteAsString()
        {
            Console.WriteLine(GetQuoteAsString("msft"));
        }

        [TestMethod]
        public void TestGetQuoteAsJson()
        {
            var msft = GetQuoteAsJson("spy");
            Console.WriteLine($"{msft.Quotes.Quote.Symbol}\n{msft.Quotes.Quote.Last}");
        }

        [TestMethod]
        public void TestGetQuoteAsJsonAsync()
        {
            var msft = GetQuoteAsJsonAsync("spy");
            Console.WriteLine($"{msft.Result.Quotes.Quote.Symbol}\n{msft.Result.Quotes.Quote.Last}");
        }
    }
}