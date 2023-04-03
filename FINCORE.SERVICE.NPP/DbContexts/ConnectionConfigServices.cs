using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.DbAccess.Interface;
using FINCORE.HELPER.LIBRARY.Encryption;

namespace FINCORE.SERVICE.NPP.DbContexts
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

        public string GetConnNPP()
        {
            return Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings: ConnNPP"));
        }

        public IDbConnectionFactory GetConnection(string _con)
        {
            return new DbConnectionFactory(_con);
        }
    }
}