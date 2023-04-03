using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.DbAccess.Interface;
using FINCORE.HELPER.LIBRARY.Encryption;

namespace FINCORE.SERVICE.BPKB.DbContexts
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
            var x = Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnBPKB"));
            return Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnBPKB"));
        }

        public IDbConnectionFactory GetConnection(string _con)
        {
            return new DbConnectionFactory(_con);
        }
    }
}