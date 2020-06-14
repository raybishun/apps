using System;
using System.IO;

namespace UnitTestMDATP
{
	class SecureStoreHelper
    {
        internal static string GetCreds(string path)
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
