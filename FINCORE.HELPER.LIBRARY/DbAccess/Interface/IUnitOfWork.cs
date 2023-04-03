namespace FINCORE.HELPER.LIBRARY.DbAccess.Interface
{
    public interface IUnitOfWork
    {
        void Dispose();

        void SaveChanges();
    }
}