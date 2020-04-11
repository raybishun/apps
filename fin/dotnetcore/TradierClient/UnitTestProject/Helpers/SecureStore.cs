using System;
using System.IO;

namespace UnitTestProject.Helpers
{
    class SecureStore
    {
        private static readonly string creds = @"C:\SecureStore\token_endpoint.txt";

        /// <summary>
        /// Read Endpoint Uri and Access Token from file in Secure Store.
        /// </summary>
        /// <returns></returns>
        internal static string GetCreds()
        {
            try
            {
                using (StreamReader sr = new StreamReader(creds))
                {
                    return sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
