using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace CosmosMinimalApi.Api.ExtensionMethods
{
    public static class KeyVaultExtensions
    {
        public static async Task AddKeyvaultExtendedAsync(this WebApplicationBuilder builder)
        {
            var keyVaultURL = builder.Configuration["KeyVault:KeyVaultURL"];
            var keyVaultClientId = builder.Configuration["KeyVault:ClientId"];
            var keyVaultClientSecret = builder.Configuration["KeyVault:ClientSecret"];
            var keyVaultDirectoryID = builder.Configuration["KeyVault:DirectoryID"];

            builder.Configuration.AddAzureKeyVault(new Uri(keyVaultURL!), new DefaultAzureCredential());

            var credential = new ClientSecretCredential(keyVaultDirectoryID, keyVaultClientId, keyVaultClientSecret);
            var client = new SecretClient(new Uri(keyVaultURL!), credential);

            Secrets.URI = (await client.GetSecretAsync("URI")).Value.Value;
            Secrets.PrimaryKey = (await client.GetSecretAsync("PrimaryKey")).Value.Value;
            Secrets.DbName = (await client.GetSecretAsync("DbName")).Value.Value;
           
        }
    }
}
