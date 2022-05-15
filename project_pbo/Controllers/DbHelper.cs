using Microsoft.AspNetCore.Mvc;
using Npgsql;
using project_pbo.Models;
using System.Configuration;
using System.Data;
using System.Diagnostics;


namespace project_pbo.Controllers
{
    public class DbHelper : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public bool ExecuteCUDQuery(ref DataTable dt, string sql, params NpgsqlParameter[] parameters)
        {
            DotNetEnv.Env.Load();
            string dsn = $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
                $"Username={Environment.GetEnvironmentVariable("DB_USERNAME")};" +
                $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
                $"Database={Environment.GetEnvironmentVariable("DB_NAME")}";
            using (NpgsqlConnection connStr = new NpgsqlConnection(dsn))
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connStr))
            {
                cmd.CommandType = CommandType.Text;
                try
                {

                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }

                    cmd.Connection?.Open();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                return true;
            }
        }

        public bool ExecuteRQuery(ref DataSet ds, string sql, params NpgsqlParameter[] parameters)
        {
            DotNetEnv.Env.Load();
            string dsn = $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
                $"Username={Environment.GetEnvironmentVariable("DB_USERNAME")};" +
                $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
                $"Database={Environment.GetEnvironmentVariable("DB_NAME")}";
            using (NpgsqlConnection connStr = new NpgsqlConnection(dsn))
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connStr))
            {
                cmd.CommandType = CommandType.Text;
                try
                {
                    if (parameters.Length > 0)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    cmd.Connection?.Open();
                    new NpgsqlDataAdapter(cmd).Fill(ds);
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                return true;
            }
        }
    }
}
