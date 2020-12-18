using System;
using System.Management;

namespace BitLockerUtility48
{
    class Program
    {
        static void Main(string[] args)
        {
            GetWinOSInfo();
            Console.ReadKey();
        }

        static void GetWinOSInfo()
        {
            try
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = ImpersonationLevel.Impersonate;
                ManagementScope scope = new ManagementScope(@"\\.\root\cimv2", options);
                scope.Connect();

                // ObjectQuery query = new ObjectQuery("SELECT Caption FROM Win32_OperatingSystem");
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection objectCollection = searcher.Get();

                foreach (var item in objectCollection)
                {
                    Console.WriteLine(item["Caption"].ToString());
                    
                    foreach (var subItem in item.Properties)
                    {
                        Console.WriteLine($"{subItem.Name}\t{subItem.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
