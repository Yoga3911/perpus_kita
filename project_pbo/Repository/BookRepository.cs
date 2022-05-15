using Npgsql;
using System.Data;
using project_pbo.Controllers;

namespace project_pbo.Repository
{
    public class BookRepository
    {
        DbHelper dbHelper = new DbHelper();
        
        public int GetCountData(string sql)
        {
            DataSet ds = new DataSet();

            NpgsqlParameter[] param0 = new NpgsqlParameter[0];
            bool status = dbHelper.ExecuteRQuery(ref ds, sql, param0);
            
            if (!status)
            {
                Console.WriteLine("Operasi gagal dijalankan");
                return 0;
            }
            
            int count = ds.Tables[0].Rows.Count + 1;
            return count;
        }
        
        public bool GetAllData(DataSet ds, string sql, params NpgsqlParameter[] parameters)
        {
            bool status = dbHelper.ExecuteRQuery(ref ds, sql, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi gagal dijalanjan");
                return false;
            }

            return true;
        }

        public bool InsertData(string sql, params NpgsqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            bool status = dbHelper.ExecuteCUDQuery(ref dt, sql, parameters);

            if (!status)
            {
                Console.WriteLine("Operasi gagal dijalankan");
                return false;
            }
            
            return true;
        }


    }
}
