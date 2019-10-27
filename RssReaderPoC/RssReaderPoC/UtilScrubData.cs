using System;

namespace pocRssReader
{
    public class UtilScrubData
    {
        public static string RemoveZeros(string data)
        {
            string result = "";

            try
            {
                #region Expected String Input
                // "Sat, 19 Oct 2019 14:43:54 +0000"
                #endregion

                int endMarker = data.IndexOf('+') - 1;

                result = data.Substring(0, endMarker);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}
