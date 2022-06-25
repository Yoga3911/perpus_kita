using project_pbo.Repository;
using project_pbo.Models;
using Npgsql;
using System.Data;

namespace project_pbo.Services
{
    public class BookService
    {
        BookRepository bookRepository = new BookRepository();

        public void SaveFav(int user_id, int book_id)
        {
            DateTime dateTime = DateTime.Now.AddDays(10);
            string query = "INSERT INTO favorite (user_id, book_id) VALUES (@user_id, @book_id)";

            NpgsqlParameter[] param = new NpgsqlParameter[2];
            param[0] = new NpgsqlParameter("@user_id", user_id);
            param[1] = new NpgsqlParameter("@book_id", book_id);

            bookRepository.InsertFav(query, param);
        }
        public List<BookModel> GetAllBook()
        {
            DataSet ds = new DataSet();
            NpgsqlParameter[] param = new NpgsqlParameter[0];

            bookRepository.GetAllData(ds, "books", param);

            var data = ds.Tables[0];

            List<BookModel> books = new List<BookModel>();

            foreach (DataRow dr in data.Rows)
            {
                BookModel book = new BookModel();
                book.BookId = dr.Field<Int32>(data.Columns[0]);
                book.Title = dr.Field<string>(data.Columns[1]);
                book.Description = dr.Field<string>(data.Columns[2]);
                book.PublishedDate = dr.Field<DateTime>(data.Columns[3]);
                book.Rating = dr.Field<string>(data.Columns[4]);
                book.Isbn = dr.Field<string>(data.Columns[5]);
                book.Category = dr.Field<string>(data.Columns[6]);
                book.PublisherId = dr.Field<Int16>(data.Columns[7]);
                books.Add(book);
            }

            return books;
        }

        public List<BookModel> GetAllBookFilter(string filter)
        {
            DataSet ds = new DataSet();
            NpgsqlParameter[] param = new NpgsqlParameter[0];

            bookRepository.GetAllDataFilter(ds, "books", filter, param);

            var data = ds.Tables[0];

            List<BookModel> books = new List<BookModel>();

            foreach (DataRow dr in data.Rows)
            {
                BookModel book = new BookModel();
                book.BookId = dr.Field<Int32>(data.Columns[0]);
                book.Title = dr.Field<string>(data.Columns[1]);
                book.Description = dr.Field<string>(data.Columns[2]);
                book.PublishedDate = dr.Field<DateTime>(data.Columns[3]);
                book.Rating = dr.Field<string>(data.Columns[4]);
                book.Isbn = dr.Field<string>(data.Columns[5]);
                book.Category = dr.Field<string>(data.Columns[6]);
                book.PublisherId = dr.Field<Int16>(data.Columns[7]);
                books.Add(book);
            }

            return books;
        }

        public List<BookModel> GetAllBookSearch(string filter)
        {
            DataSet ds = new DataSet();
            NpgsqlParameter[] param = new NpgsqlParameter[0];

            bookRepository.GetAllDataSearch(ds, "books", filter, param);

            var data = ds.Tables[0];

            List<BookModel> books = new List<BookModel>();

            foreach (DataRow dr in data.Rows)
            {
                BookModel book = new BookModel();
                book.BookId = dr.Field<Int32>(data.Columns[0]);
                book.Title = dr.Field<string>(data.Columns[1]);
                book.Description = dr.Field<string>(data.Columns[2]);
                book.PublishedDate = dr.Field<DateTime>(data.Columns[3]);
                book.Rating = dr.Field<string>(data.Columns[4]);
                book.Isbn = dr.Field<string>(data.Columns[5]);
                book.Category = dr.Field<string>(data.Columns[6]);
                book.PublisherId = dr.Field<Int16>(data.Columns[7]);
                books.Add(book);
            }

            return books;
        }

        public List<BookModel> GetAllFavBook(int userId)
        {
            DataSet ds = new DataSet();
            NpgsqlParameter[] param = new NpgsqlParameter[0];

            bookRepository.GetAllFavData(ds, "favorite", userId, param);

            var data = ds.Tables[0];

            List<BookModel> books = new List<BookModel>();

            foreach (DataRow dr in data.Rows)
            {
                BookModel book = new BookModel();
                book.BookId = dr.Field<Int32>(data.Columns[3]);
                book.Title = dr.Field<string>(data.Columns[4]);
                book.Description = dr.Field<string>(data.Columns[5]);
                book.PublishedDate = dr.Field<DateTime>(data.Columns[6]);
                book.Rating = dr.Field<string>(data.Columns[7]);
                book.Isbn = dr.Field<string>(data.Columns[8]);
                book.Category = dr.Field<string>(data.Columns[9]);
                book.PublisherId = dr.Field<Int16>(data.Columns[10]);
                books.Add(book);
            }

            return books;
        }

        public BookModel getBookById(int bookId)
        {
            DataSet ds = new DataSet();
            NpgsqlParameter[] param = new NpgsqlParameter[0];

            bookRepository.GetOneData(ds, "books", bookId, param);

            var data = ds.Tables[0];

            BookModel book = new BookModel();
            foreach (DataRow dr in data.Rows)
            {
                book.BookId = dr.Field<Int32>(data.Columns[0]);
                book.Title = dr.Field<string>(data.Columns[1]);
                book.Description = dr.Field<string>(data.Columns[2]);
                book.PublishedDate = dr.Field<DateTime>(data.Columns[3]);
                book.Rating = dr.Field<string>(data.Columns[4]);
                book.Isbn = dr.Field<string>(data.Columns[5]);
                book.Category = dr.Field<string>(data.Columns[6]);
                book.PublisherId = dr.Field<Int16>(data.Columns[7]);
            }


            return book;
        }

        public void InsertBook(string title, string description, string rating, string isbn, int publisher_id, string category, DateTime publisher_date)
        {
            string query = "INSERT INTO books (title, description, published_date, rating, isbn, category, publisher_id) VALUES (@title, @description, @published_date, @rating, @isbn, @category, @publisher_id)";

            NpgsqlParameter[] param = new NpgsqlParameter[7];
            param[0] = new NpgsqlParameter("@title", title);
            param[1] = new NpgsqlParameter("@description", description);
            param[2] = new NpgsqlParameter("@published_date", publisher_date);
            param[3] = new NpgsqlParameter("@rating", rating);
            param[4] = new NpgsqlParameter("@isbn", isbn);
            param[5] = new NpgsqlParameter("@category", category);
            param[6] = new NpgsqlParameter("@publisher_id", publisher_id);

            bookRepository.InsertData(query, param);
        }

        public void UpdateBook(int book_id, string title, string description, string rating, string isbn, int publisher_id, DateTime publishedDate)
        {
            string query = "UPDATE books SET title = @title, published_date = @published_date, description = @description, rating = @rating, isbn = @isbn, publisher_id = @publisher_id WHERE book_id = @book_id";
            Console.WriteLine(title);
            Console.WriteLine(book_id);
            NpgsqlParameter[] param = new NpgsqlParameter[7];
            param[0] = new NpgsqlParameter("@book_id", book_id);
            param[1] = new NpgsqlParameter("@title", title);
            param[2] = new NpgsqlParameter("@description", description);
            param[3] = new NpgsqlParameter("@published_date", publishedDate);
            param[4] = new NpgsqlParameter("@rating", rating);
            param[5] = new NpgsqlParameter("@isbn", isbn);
            param[6] = new NpgsqlParameter("@publisher_id", publisher_id);

            bookRepository.UpdateData(query, param);
        }

        public void DeleteBook(int book_id)
        {
            string query = "DELETE FROM books WHERE book_id = @book_id";
            NpgsqlParameter[] param = new NpgsqlParameter[1];
            param[0] = new NpgsqlParameter("@book_id", book_id);

            bookRepository.DeleteData(query, param);
        }
    }
}