using project_pbo.Repository;
using project_pbo.Models;
using Npgsql;
using System.Data;

namespace project_pbo.Services
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();

        public UserModel LoginEmailPassword(string email, string password)
        {
            DataSet ds = new DataSet();
            NpgsqlParameter[] param = new NpgsqlParameter[0];

            userRepository.Login(ds, email, password, param);

            var data = ds.Tables[0];

            UserModel user = new UserModel();
            foreach (DataRow dr in data.Rows)
            {
                user.UserId = dr.Field<Int32>(data.Columns[0]);
                user.FirstName = dr.Field<string>(data.Columns[1]);
                user.LastName = dr.Field<string>(data.Columns[2]);
                user.Address = dr.Field<string>(data.Columns[3]);
                user.Email = dr.Field<string>(data.Columns[4]);
                user.Password = dr.Field<string>(data.Columns[5]);
                user.IsAdmin = dr.Field<bool>(data.Columns[6]);
                user.Phone = dr.Field<string>(data.Columns[7]);
            }

            return user;
        }

        public bool RegisterUser(string firstName, string lastName, string email, string password, string address, string phone)
        {
            DataTable dt = new DataTable();
            string query = "INSERT INTO users (first_name, last_name, address, email, password, is_admin, phone) VALUES (@firstName, @lastName, @address, @email, @password, false, @phone)";
            NpgsqlParameter[] param = new NpgsqlParameter[6];
            param[0] = new NpgsqlParameter("@firstName", firstName);
            param[1] = new NpgsqlParameter("@lastName", lastName);
            param[2] = new NpgsqlParameter("@address", address);
            param[3] = new NpgsqlParameter("@email", email);
            param[4] = new NpgsqlParameter("@password", password);
            param[5] = new NpgsqlParameter("@phone", phone);

            bool isSuccess = userRepository.InsertData(dt, query, param);
            if (!isSuccess)
            {
                return false;
            }

            return true;
        }
    }
}