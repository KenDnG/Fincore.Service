using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.DbAccess.Repository.Interfaces;
using System.Data;

namespace FINCORE.HELPER.LIBRARY.DbAccess.Repository
{
    public class BaseRepository<T> where T : new()
    {
        private DbContext _context;

        public BaseRepository(DbContext context)
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

        protected Pagination<T> ReadTransactionPagination(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                Pagination<T> items = new Pagination<T>();
                while (record.Read())
                {
                    items.Model.Add(Map<T>(record));
                }
                return items;
            }
        }

        protected IList<T> ReadTransaction(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                List<T> items = new List<T>();
                while (record.Read())
                {
                    items.Add(Map<T>(record));
                }
                return items;
            }
        }

        protected T Map<T>(IDataRecord record)
        {
            var objT = Activator.CreateInstance<T>();
            foreach (var property in typeof(T).GetProperties())
            {
                if (record.HasColumn(property.Name) && !record.IsDBNull(record.GetOrdinal(property.Name)))
                    property.SetValue(objT, record[property.Name]);
            }
            return objT;
        }

        /// <summary>
        /// Execute Query Insert and return value data position 0.
        /// </summary>
        /// <param name="command">
        /// Parameters contain IDbCommand
        /// </param>
        protected string WriteTransaction(IDbCommand command)
        {
            string result = default;
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

        /// <summary>
        /// Count Transaction
        /// </summary>
        /// <param name="command">Command</param>
        /// <returns></returns>
        protected int CountTransaction(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                int result = 0;
                while (record.Read())
                {
                    result = (int)record[0];
                }
                return result;
            }
        }
    }
}