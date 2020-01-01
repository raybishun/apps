using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using Newtonsoft.Json;

namespace pocRssReader
{
    public class RssItem
    {
        public string PubDate { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        [JsonIgnore]
        public int MaxRssItems { get; set; }
        [JsonIgnore]
        public int RssElements { get; private set; }
        [JsonIgnore]
        public int RssItemCount { get; private set; }

        public RssItem()
        {
            MaxRssItems  = 100;
            RssElements  = 4;
        }

        public RssItem(string pubDate, string title, string link, int maxRssItems = 100, int rssItemCount = 4)
        {
            PubDate      = pubDate;
            Title        = title;
            Link         = link;
            MaxRssItems  = maxRssItems;
            RssItemCount = 4;
        }

        public string[,] GetRssData(string rssChannel)
        {
            WebRequest webRequest = WebRequest.Create(rssChannel);
            // Handle "The remote server returned an error: (407) Proxy Authentication Required."
            webRequest.Proxy = WebRequest.DefaultWebProxy;
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;

            WebResponse webResponse = webRequest.GetResponse();

            Stream stream = webResponse.GetResponseStream();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(stream);

            // Store all RSS Items in an XmlNodeList
            XmlNodeList rssItems = xmlDocument.SelectNodes("rss/channel/item");
            RssItemCount = rssItems.Count;

            string[,] tempRssData = new string[MaxRssItems, RssElements];
            #region RSS Multidimensional Array Structure
            /*
            RSS Elements:
                    0 = pubDate 
                    1 = title
                    2 = description
                    3 = link

            RSS Array:
            Item0  -> pubDate, title, description, link
            Item1  -> pubDate, title, description, link
            Item2  -> pubDate, title, description, link
            ...
            Item25 -> pubDate, title, description, link
            */
            #endregion

            if (rssItems.Count > MaxRssItems)
            {
                throw new Exception("Unable to store returned data.");
            }
            else
            {
                for (int i = 0; i < rssItems.Count; i++)
                {
                    XmlNode rssItem;

                    rssItem = rssItems.Item(i).SelectSingleNode("pubDate");
                    if (rssItem != null)
                    {
                        tempRssData[i, 0] = rssItem.InnerText;
                    }
                    else
                    {
                        tempRssData[i, 0] = "";
                    }

                    rssItem = rssItems.Item(i).SelectSingleNode("title");
                    if (rssItem != null)
                    {
                        tempRssData[i, 1] = rssItem.InnerText;
                    }
                    else
                    {
                        tempRssData[i, 1] = "";
                    }

                    rssItem = rssItems.Item(i).SelectSingleNode("description");
                    if (rssItem != null)
                    {
                        tempRssData[i, 2] = rssItem.InnerText;
                    }
                    else
                    {
                        tempRssData[i, 2] = "";
                    }

                    rssItem = rssItems.Item(i).SelectSingleNode("link");
                    if (rssItem != null)
                    {
                        tempRssData[i, 3] = rssItem.InnerText;
                    }
                    else
                    {
                        tempRssData[i, 3] = "";
                    }
                }

                return tempRssData;
            }
        }

        public void CreateCsvFile(string[,] rssData, string dstFile)
        {
            if (rssData != null)
            {
                using (StreamWriter sw = new StreamWriter(dstFile, false))
                {
                    for (int i = 0; i < rssData.GetLength(0); i++)
                    {
                        if (rssData[i, 1] != null)
                        {
                            RssItem rssItem = new RssItem
                            {
                                PubDate = UtilScrubData.RemoveZeros(rssData[i, 0]),
                                Title = rssData[i, 1],
                                Link = rssData[i, 3]
                            };

                            sw.WriteLine(rssItem.ToString());
                        }
                    }
                }
            }
        }

        public void CreateJsonFile(string[,] rssData, string dstFile)
        {
            var items = new List<RssItem>();

            if (rssData != null)
            {
                for (int i = 0; i < rssData.GetLength(0); i++)
                {
                    if (rssData[i, 1] != null)
                    {
                        RssItem item = new RssItem
                        {
                            PubDate = UtilScrubData.RemoveZeros(rssData[i, 0]),
                            Title = rssData[i, 1],
                            Link = rssData[i, 3]
                        };

                        items.Add(item);
                    }
                }

                var json = JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(dstFile, json);
            }
        }

        public override string ToString()
        {
            return $"\"{PubDate}\",\"{Title}\",\"{Link}\"";
        }
    }
}


// References
// 1. JSON Validator: https://jsonlint.com