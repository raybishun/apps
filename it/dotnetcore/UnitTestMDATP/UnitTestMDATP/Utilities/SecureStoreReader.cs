using System;
using System.IO;

namespace UnitTestMDATP.Utilities
{
    class SecureStoreReader
    {
        public static string GetCredentials(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
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
