using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository.Interfaces;
using System.Data;

namespace FINCORE.HELPER.LIBRARY.Helper
{
    public class StoreProcedure : BaseDynamicRepository
    {
        private DbContext dbContext;

        public StoreProcedure(DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public string Insert<T>(string StoreProcedure, T Model)
        {
            string errorMessage = default;
            using (var command = dbContext.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = StoreProcedure;

                foreach (var prop in Model.GetType().GetProperties())
                {
                    command.Parameters.Add(command.CreateParameter(ConvertHelper.ConvertAttribute(prop.Name), prop.GetValue(Model)));
                }

                return errorMessage = this.WriteTransaction(command);
            }
        }

        public string Update<T>(string StoreProcedure, T Model)
        {
            string errorMessage = default;
            using (var command = dbContext.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = StoreProcedure;

                foreach (var prop in Model.GetType().GetProperties())
                {
                    command.Parameters.Add(command.CreateParameter(ConvertHelper.ConvertAttribute(prop.Name), prop.GetValue(Model)));
                }

                return errorMessage = this.WriteTransaction(command);
            }
        }
    }
}