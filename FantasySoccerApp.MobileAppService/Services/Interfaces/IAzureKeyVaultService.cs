using System.Collections.Generic;

namespace FantasySoccerApp.MobileAppService.Services.Interfaces
{
    public interface IAzureKeyVaultService
    {
        string GetKeyVaultEndpoint();
        void SetKeys(Dictionary<string, string> keys);
        Dictionary<string, string> GetKeys();
        string GetSecretAsync(string secretName);
        object GetAllSecretsAsync();
    }
}
