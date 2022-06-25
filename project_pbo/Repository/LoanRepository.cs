using Npgsql;
using System.Data;
using project_pbo.Controllers;

namespace project_pbo.Repository
{
    public class LoanRepository
    {
        DbHelper dbHelper = new DbHelper();
        public bool InsertData(string query, NpgsqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            Console.WriteLine(query);
            bool status = dbHelper.ExecuteCUDQuery(ref dt, query, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi 'CREATE' gagal dijalankan");
                return false;
            }

            return true;
        }

        public bool GetAllData(DataSet ds, int userId, params NpgsqlParameter[] parameters)
        {
            string query = "";
            if (userId == 0)
            {
                query = $"SELECT * FROM loan l join books b on l.book_id = b.book_id ORDER BY b.book_id ASC";

            }
            else
            {
                query = $"SELECT * FROM loan l join books b on l.book_id = b.book_id WHERE l.user_id = {userId} ORDER BY b.book_id ASC";
            }
            bool status = dbHelper.ExecuteRQuery(ref ds, query, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi 'READ' gagal dijalanjan");
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
    }
}