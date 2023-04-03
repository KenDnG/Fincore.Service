using System.Data;

namespace FINCORE.HELPER.LIBRARY.DbAccess.Interface
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}