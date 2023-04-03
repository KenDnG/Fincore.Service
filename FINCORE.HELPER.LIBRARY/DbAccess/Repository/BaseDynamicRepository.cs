using System.Data;

namespace FINCORE.HELPER.LIBRARY.DbAccess.Repository
{
    public class BaseDynamicRepository
    {
        private DbContext _context;

        public BaseDynamicRepository(DbContext context)
        {
            _context = context;
        }

        protected DbContext Context
        {
            get
            {
                return this._context;
            }
        }

        /// <summary>
        /// Execute Query Insert and return value data position 0.
        /// </summary>
        /// <param name="command">
        /// Parameters contain IDbCommand
        /// </param>
        protected string WriteTransaction(IDbCommand command)
        {
            string result = null;
            using (var record = command.ExecuteReader())
            {
                //if (record.Read()) result = true;
                if (record.FieldCount > 0)
                {
                    while (record.Read())
                    {
                        result = record["error_message"].ToString();
                    }
                };
            }
            return result;
        }
    }
}