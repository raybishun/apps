using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using YahooFinanceApi;

namespace yfinancedemo
{
    [TestClass]
    public class TestGetData
    {
        // string[] faang = { "FB", "AMZN", "AAPL", "NFLX", "GOOG" };
        string faang = "msft";

        [TestMethod]
        public async Task TestGetDataAsync()
        {
            IReadOnlyDictionary<string, Security> securities = 
                await Yahoo.Symbols(faang).Fields(Field.Symbol, Field.RegularMarketPrice, Field.FiftyTwoWeekHigh).QueryAsync();
            
            var msft = securities["MSFT"];

            var symbol = msft[Field.Symbol];
            
            var price = msft[Field.RegularMarketPrice];
            
            Console.WriteLine($"{symbol}: {price}");
        }

        [TestMethod]
        public async Task TestGetDataAsync2()
        {
            IReadOnlyDictionary<string, Security> securities = 
                await Yahoo.Symbols(faang).Fields("Symbol", "RegularMarketPrice").QueryAsync();

            // Console.WriteLine($"{securities["AAPL"].Symbol}\n{securities["AAPL"].RegularMarketPrice}");

            foreach (var security in securities)
            {
                Console.WriteLine($"{security.Key}, {security.Value.RegularMarketPrice}");
            }
        }
    }
}
