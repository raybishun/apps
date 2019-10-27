using System;
using System.Windows.Forms;

namespace pocRssReader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string[,] rssData = null;
                RssItem rssItem = new RssItem();
                string rssChannel = "https://status.cloudappsecurity.com/history.rss";

                try
                {
                    if (args[0] == "-json")
                    {
                        rssData = rssItem.GetRssData(rssChannel);
                        rssItem.CreateJsonFile(rssData, @"rssItems.json");
                    }
                    else if (args[0] == "-csv")
                    {
                        rssData = rssItem.GetRssData(rssChannel);
                        rssItem.CreateCsvFile(rssData, @"rssItems.csv");
                    }
                    else
                    {
                        Console.WriteLine("\nValid args:\n \n\t-json\n\t-csv\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new RssReaderForm());
            }
        }
    }
}
