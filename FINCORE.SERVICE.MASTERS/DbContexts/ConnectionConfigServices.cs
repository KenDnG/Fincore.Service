using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.DbAccess.Interface;
using FINCORE.HELPER.LIBRARY.Encryption;

namespace FINCORE.SERVICE.MASTERS.DbContexts
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

        public string GetConnMACFDB_Dev()
        {
            var x = Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnMACFDB_Dev"));
            return Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnMACFDB_Dev"));
        }

        public string GetConnMasterApp()
        {
            var x = Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnMasters"));
            return x;
        }

        public IDbConnectionFactory GetConnection(string _con)
        {
            return new DbConnectionFactory(_con);
        }
    }
}