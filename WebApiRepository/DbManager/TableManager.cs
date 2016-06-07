using SQLite.Net;
using SQLite.Net.Platform.Win32;

namespace WebApiRepository.DbManager
{
    public class TableManager
    {
        private readonly SQLiteConnection _connection;
        public TableManager()
        {
            _connection = new SQLiteConnection(new SQLitePlatformWin32(), "");
        }

        public void CreateTable<T>()
        {
            _connection.CreateTable<T>();
        }
    }
}
