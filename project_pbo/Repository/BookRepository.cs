using Npgsql;
using System.Data;
using project_pbo.Controllers;

namespace project_pbo.Repository
{
    public class BookRepository
    {
        DbHelper dbHelper = new DbHelper();

        public int GetCountData(string tabel)
        {
            DataSet ds = new DataSet();
            NpgsqlParameter[] param0 = new NpgsqlParameter[0];
            string query = $"SELECT * FROM {tabel}";

            bool status = dbHelper.ExecuteRQuery(ref ds, query, param0);

            if (!status)
            {
                Console.WriteLine("Operasi gagal dijalankan");
                return 0;
            }

            int count = ds.Tables[0].Rows.Count + 1;
            return count;
        }

        public bool GetOneData(DataSet ds, string tabel, int bookId, params NpgsqlParameter[] parameters)
        {
            string query = $"SELECT * FROM {tabel} WHERE book_id = {bookId}";
            bool status = dbHelper.ExecuteRQuery(ref ds, query, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi 'READ' gagal dijalankan");
                return false;
            }

            return true;
        }

        public bool GetAllData(DataSet ds, string tabel, params NpgsqlParameter[] parameters)
        {
            string query = $"SELECT * FROM {tabel} ORDER BY book_id ASC";
            bool status = dbHelper.ExecuteRQuery(ref ds, query, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi 'READ' gagal dijalanjan");
                return false;
            }

            return true;
        }

        public bool GetAllDataFilter(DataSet ds, string tabel, string filter, params NpgsqlParameter[] parameters)
        {
            string query = "";
            if (filter == "fik")
            {
                query = $"SELECT * FROM {tabel} WHERE category = 'Fiksi' ORDER BY book_id ASC";
            }
            else
            {
                query = $"SELECT * FROM {tabel} WHERE category = 'NonFiksi' ORDER BY book_id ASC";
            }
            bool status = dbHelper.ExecuteRQuery(ref ds, query, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi 'READ' gagal dijalanjan");
                return false;
            }

            return true;
        }

        public bool GetAllDataSearch(DataSet ds, string tabel, string filter, params NpgsqlParameter[] parameters)
        {

            string query = $"SELECT * FROM {tabel} WHERE title ILIKE '%{filter}%' ";

            bool status = dbHelper.ExecuteRQuery(ref ds, query, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi 'READ' gagal dijalanjan");
                return false;
            }

            return true;
        }

        public bool GetAllFavData(DataSet ds, string tabel, int userId, params NpgsqlParameter[] parameters)
        {
            string query = $"SELECT * FROM {tabel} f join books b on f.book_id = b.book_id WHERE user_id = {userId} ORDER BY b.book_id ASC";
            bool status = dbHelper.ExecuteRQuery(ref ds, query, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi 'READ' gagal dijalanjan");
                return false;
            }

            return true;
        }

        public bool InsertData(string query, NpgsqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            bool status = dbHelper.ExecuteCUDQuery(ref dt, query, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi 'CREATE' gagal dijalankan");
                return false;
            }

            return true;
        }

        public bool InsertFav(string query, NpgsqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            bool status = dbHelper.ExecuteCUDQuery(ref dt, query, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi 'CREATE' gagal dijalankan");
                return false;
            }

            return true;
        }

        public bool UpdateData(string query, NpgsqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            bool status = dbHelper.ExecuteCUDQuery(ref dt, query, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi 'UPDATE' gagal dijalankan");
                return false;
            }

            return true;
        }

        public bool DeleteData(string query, NpgsqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            bool status = dbHelper.ExecuteCUDQuery(ref dt, query, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi 'DELETE' gagal dijalankan");
                return false;
            }

            return true;
        }
    }
}