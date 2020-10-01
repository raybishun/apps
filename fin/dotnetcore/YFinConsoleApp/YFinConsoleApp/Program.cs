using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace YFinConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // discard '_'
            _ = GetData();
            
            Console.ReadKey();
        }

        static async Task GetData()
        {
            string[] faangm = { "FB", "AMZN", "AAPL", "NFLX", "GOOG", "MSFT" };

            IReadOnlyDictionary<string, Security> securities = 
                await Yahoo.Symbols(faangm).Fields(Field.Symbol, Field.RegularMarketPrice).QueryAsync();

            foreach (var security in securities)
            {
                Console.WriteLine($"{security.Key}, {security.Value.RegularMarketPrice}");
            }
        }
    }
}
