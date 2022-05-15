using project_pbo.Repository;
using project_pbo.Models;
using Npgsql;
using System.Data;

namespace project_pbo.Services
{
    public class BookService
    {
        BookRepository bookRepository = new BookRepository();
        public List<BookModel> GetAllBook()
        {
            DataSet ds = new DataSet();
            NpgsqlParameter[] param = new NpgsqlParameter[0];
            string query = "SELECT * FROM books";

            bookRepository.GetAllData(ds, query, param);
            
            var data = ds.Tables[0];
            
            List<BookModel> books = new List<BookModel>();
            
            foreach (DataRow dr in data.Rows)
            {
                BookModel book = new BookModel();
                book.BookId = dr.Field<Int16>(data.Columns[0]);
                book.Title = dr.Field<string>(data.Columns[1]);
                book.PublishedDate = dr.Field<DateTime>(data.Columns[2]);
                book.Rating = dr.Field<string>(data.Columns[3]);
                book.Isbn = dr.Field<string>(data.Columns[4]);
                book.PublisherId = dr.Field<Int16>(data.Columns[5]);
                books.Add(book);
            }

            return books;
        }

        public void InsertBook()
        {
            string query = "INSERT INTO books VALUES (@book_id, @title, @published_date, @rating, @isbn, @publisher_id)";

            int count = bookRepository.GetCountData("SELECT * FROM books");

            NpgsqlParameter[] param = new NpgsqlParameter[6];
            param[0] = new NpgsqlParameter("@book_id", count);
            param[1] = new NpgsqlParameter("@title", "IronMan");
            param[2] = new NpgsqlParameter("@published_date", DateTime.Now);
            param[3] = new NpgsqlParameter("rating", "C");
            param[4] = new NpgsqlParameter("@isbn", "3219388");
            param[5] = new NpgsqlParameter("@publisher_id", 1);

            bookRepository.InsertData(query, param);
        }
    }
}
