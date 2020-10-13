using System.IO;

namespace UnitTestMDATP.Utilities
{
    class TenantInfo
    {
        public string TenantId { get; private set; }
        public string AppId { get; private set; }
        public string AppSecret { get; private set; }

        public TenantInfo()
        {
            string path = @"C:\SecureStore\BBS_Get_ATP_Alerts.txt";
            string[] tenantInfo = File.ReadAllLines(path);

            TenantId = tenantInfo[0];
            AppId = tenantInfo[1];
            AppSecret = tenantInfo[2];
        }

        public override string ToString()
        {
            return $"{TenantId},{AppId},{AppSecret}";
        }
    }
}
