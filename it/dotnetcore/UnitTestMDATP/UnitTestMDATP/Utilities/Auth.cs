using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace UnitTestMDATP.Utilities
{
    class Auth
    {
        public static string GetToken()
        {
            #region References
            // 1. https://www.nuget.org/packages/Microsoft.IdentityModel.Clients.ActiveDirectory/
            #endregion

            #region Notes
            // Token valid for 1 hour

            // Validate token at: https://jwt.ms/, this will:
            // 1. Decode the token (into JSON)
            // 2. Explain the Claim types and their values
            #endregion

            string authority = "https://login.windows.net";
            string wdatpResourceId = "https://api.securitycenter.windows.com";

            TenantInfo tenantInfo = new TenantInfo();

            try
            {
                AuthenticationContext auth = new AuthenticationContext($"{authority}/{tenantInfo.TenantId}/");
                ClientCredential clientCredential = new ClientCredential(tenantInfo.AppId, tenantInfo.AppSecret);
                AuthenticationResult authenticationResult = auth.AcquireTokenAsync(wdatpResourceId, clientCredential).GetAwaiter().GetResult();
                return authenticationResult.AccessToken;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
