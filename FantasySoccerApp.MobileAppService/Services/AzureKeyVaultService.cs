using System.Collections.Generic;
using FantasySoccerApp.MobileAppService.Services.Interfaces;
using FantasySoccerApp.MobileAppService.Utilities;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace FantasySoccerApp.MobileAppService.Services
{
    public class AzureKeyVaultService : IAzureKeyVaultService
    {
        Dictionary<string, string> keys { get; set; }
        public string GetKeyVaultEndpoint()
        {
            return "https://fantasysoccerappkeyvault.vault.azure.net/";
        }

        public AzureKeyVaultService(Dictionary<string, string> azureVaultKeys)
        {
            this.keys = azureVaultKeys;
        }

        public AzureKeyVaultService()
        { }

        public string GetSecretAsync(string secretName)
        {
            var trimmedSecretName = secretName.Replace(" ", "").NoNull();
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var secretValue = keyVaultClient.GetSecretAsync(GetKeyVaultEndpoint() + "secrets/" + trimmedSecretName).Result;

            return secretValue.Value;
        }

        public object GetAllSecretsAsync()
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var result = keyVaultClient.GetSecretsAsync(GetKeyVaultEndpoint()).Result;
            return result;
        }

        public void SetKeys(Dictionary<string, string> azureKeys)
        {
            this.keys = azureKeys;
        }

        public Dictionary<string, string> GetKeys()
        {
            return keys;
        }
    }
}
