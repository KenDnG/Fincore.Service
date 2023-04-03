using FINCORE.HELPER.LIBRARY.DbAccess.Interface;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace FINCORE.HELPER.LIBRARY.DbAccess
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly DbProviderFactory _provider;
        private readonly string _connectionString;
		public struct ConnectionsStore
		{
			public static readonly string CONN_ACQUISITION = Environment.GetEnvironmentVariable("CONN_ACQUISITION");
			public static readonly string CONN_PAYMENT = Environment.GetEnvironmentVariable("CONN_PAYMENT");
			public static readonly string CONN_TERMINATION = Environment.GetEnvironmentVariable("CONN_TERMINATION");
			public static readonly string CONN_MASTER = Environment.GetEnvironmentVariable("CONN_MASTER");
		}

		public struct ProviderName
        {
            public static string SQL_CLIENT = "System.Data.SqlClient";
        }

        public DbConnectionFactory(string constring)
        {
            DbProviderFactories.RegisterFactory(ProviderName.SQL_CLIENT, System.Data.SqlClient.SqlClientFactory.Instance);
            _provider = DbProviderFactories.GetFactory(ProviderName.SQL_CLIENT);
            _connectionString = constring; //ConnectionConfigServices.GetConnectionsString();
        }

        public IDbConnection Create()
        {
            var connection = _provider.CreateConnection();
            if (connection == null)
                throw new ConfigurationErrorsException("Failed to create connection");

            connection.ConnectionString = _connectionString;

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
    }
}