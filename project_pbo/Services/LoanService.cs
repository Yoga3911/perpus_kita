using project_pbo.Repository;
using project_pbo.Models;
using Npgsql;
using System.Data;

namespace project_pbo.Services
{
    public class LoanService
    {
        LoanRepository loanRepository = new LoanRepository();
        public void insertLoan(DateTime loan_date, int user_id, int book_id)
        {
            DateTime dateTime = DateTime.Now.AddDays(10);
            string query = "INSERT INTO loan (loan_date, return_date, user_id, book_id, is_return, status_id) VALUES (@loan_date, @return_date, @user_id, @book_id, false, 1)";

            NpgsqlParameter[] param = new NpgsqlParameter[4];
            param[0] = new NpgsqlParameter("@loan_date", loan_date);
            param[1] = new NpgsqlParameter("@return_date", dateTime);
            param[2] = new NpgsqlParameter("@user_id", user_id);
            param[3] = new NpgsqlParameter("@book_id", book_id);

            loanRepository.InsertData(query, param);
        }

        public List<LoanModel> GetAllBook(int userId)
        {
            DataSet ds = new DataSet();
            NpgsqlParameter[] param = new NpgsqlParameter[0];

            loanRepository.GetAllData(ds, userId, param);

            var data = ds.Tables[0];

            List<LoanModel> loans = new List<LoanModel>();

            foreach (DataRow dr in data.Rows)
            {
                LoanModel loan = new LoanModel();
                loan.LoanId = dr.Field<Int32>(data.Columns[0]);
                loan.LoanDate = dr.Field<DateTime>(data.Columns[1]);
                loan.ReturnDate = dr.Field<DateTime>(data.Columns[2]);
                loan.UserId = dr.Field<Int16>(data.Columns[4]);
                loan.BookId = dr.Field<Int16>(data.Columns[5]);
                loan.IsReturn = dr.Field<Boolean>(data.Columns[6]);
                loan.StatusId = dr.Field<Int16>(data.Columns[7]);
                loan.BookId2 = dr.Field<Int32>(data.Columns[8]);
                loan.Title = dr.Field<string>(data.Columns[9]);
                loan.Description = dr.Field<string>(data.Columns[10]);
                loan.PublishedDate = dr.Field<DateTime>(data.Columns[11]);
                loan.Rating = dr.Field<string>(data.Columns[12]);
                loan.Isbn = dr.Field<string>(data.Columns[13]);
                loan.PublisherId = dr.Field<Int16>(data.Columns[15]);
                loans.Add(loan);
            }

            return loans;
        }

        public void UpdateLoan(int statusId, int loanId)
        {
            string query = "UPDATE loan SET admin_id = 1, status_id = @status_id WHERE loan_id = @loan_id";
            NpgsqlParameter[] param = new NpgsqlParameter[2];
            param[0] = new NpgsqlParameter("@status_id", statusId);
            param[1] = new NpgsqlParameter("@loan_id", loanId);

            loanRepository.UpdateData(query, param);
        }
    }
}