using System.Data;

namespace FINCORE.HELPER.LIBRARY.DbAccess.Repository.Interfaces
{
    public static class IDbCommandExtensions
    {
        public static IDbDataParameter CreateParameter(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;

            return parameter;
        }

        public static IDbDataParameter CreateParameterOutput(this IDbCommand command, DbType paramType, string name)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Direction = ParameterDirection.Output;
            parameter.DbType = paramType;

            return parameter;
        }
    }
}