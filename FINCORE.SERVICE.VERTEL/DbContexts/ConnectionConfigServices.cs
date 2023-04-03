

using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.DbAccess.Interface;
using FINCORE.HELPER.LIBRARY.Encryption;

namespace FINCORE.SERVICE.VERTEL.DbContexts
{
    public class ConnectionConfigServices
    {
        private IConfiguration configuration;
        private readonly string appSetting = "appsettings.json";

        public ConnectionConfigServices()
        {
            this.configuration = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory())
                .AddJsonFile(appSetting, optional: false).Build();
        }

        public string GetConnAcquisition()
        {
            var x = Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnAcquisition"));
            return Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnAcquisition"));
        }        
        
        public string GetConnMACF()
        {
            var x = Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnVertel"));
            return Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnVertel"));
        }

        public IDbConnectionFactory GetConnection()
        {
            return new DbConnectionFactory(this.GetConnAcquisition());
        }
    }
}