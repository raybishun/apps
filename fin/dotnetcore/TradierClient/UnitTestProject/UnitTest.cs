using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        private string getUri = "https://sandbox.tradier.com/v1/markets/quotes?symbols=";
        private string accessToken = "";

        public string TestGetData(string symbol)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                Task<HttpResponseMessage> httpResponseMessage = httpClient.GetAsync($"{getUri}{symbol}");

                Assert.AreEqual(200, (int)httpResponseMessage.Result.StatusCode);

                if (httpResponseMessage.Result.IsSuccessStatusCode)
                {
                    return httpResponseMessage.Result.Content.ReadAsStringAsync().Result;
                }

                return httpResponseMessage.Result.ReasonPhrase;
            }
        }

        [TestMethod]
        public void TestClient()
        {
            Console.WriteLine(TestGetData("msft"));
        }
    }
}
