using Npgsql;
using System.Data;
using project_pbo.Controllers;

namespace project_pbo.Repository
{
    public class UserRepository
    {
        DbHelper dbHelper = new DbHelper();

        public bool Login(DataSet ds, string email, string password, params NpgsqlParameter[] parameters)
        {
            string query = $"SELECT * FROM users WHERE email = '{email}' AND password = '{password}'";
            bool status = dbHelper.ExecuteRQuery(ref ds, query, parameters);

            if (!status)
            {
                Console.WriteLine("User tidak ditemukan");
                return false;
            }

            return true;
        }

        public bool GetById(DataSet ds, int userId, params NpgsqlParameter[] parameters)
        {
            string query = $"SELECT * FROM users WHERE user_id = '{userId}'";
            bool status = dbHelper.ExecuteRQuery(ref ds, query, parameters);

            if (!status)
            {
                Console.WriteLine("User tidak ditemukan");
                return false;
            }

            return true;
        }

        public bool InsertData(DataTable dt, string query, params NpgsqlParameter[] parameters)
        {
            bool status = dbHelper.ExecuteCUDQuery(ref dt, query, parameters);

            if (!status)
            {
                Console.WriteLine("Register gagal");
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