using Microsoft.AspNetCore.Mvc;
using Npgsql;
using project_pbo.Models;
using System.Data;
using System.Diagnostics;

namespace project_pbo.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        DbHelper dbHelper = new DbHelper();
        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DataSet ds = new DataSet();
            NpgsqlParameter[] param = new NpgsqlParameter[0];

            dbHelper.ExecuteRQuery(ref ds, "SELECT * FROM books", param);
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
            ViewData["data"] = books;

            return View();
        }

        public IActionResult BookOwned()
        {
            return View();
        }

        public IActionResult ManageBook()
        {
            DataTable dt = new DataTable();
            var param = InsertBook();
            dbHelper.ExecuteCUDQuery(ref dt, "INSERT INTO books VALUES (@book_id, @title, @published_date, @rating, @isbn, @publisher_id)", param);
            return View();
        }

        public NpgsqlParameter[] InsertBook()
        {
            DataSet ds = new DataSet();
            NpgsqlParameter[] param2 = new NpgsqlParameter[0];

            dbHelper.ExecuteRQuery(ref ds, "SELECT * FROM books", param2);
            int count = ds.Tables[0].Rows.Count + 1;

            NpgsqlParameter[] param = new NpgsqlParameter[6];
            param[0] = new NpgsqlParameter("@book_id", count);
            param[1] = new NpgsqlParameter("@title", "IronMan");
            param[2] = new NpgsqlParameter("@published_date", DateTime.Now);
            param[3] = new NpgsqlParameter("rating", "C");
            param[4] = new NpgsqlParameter("@isbn", "3219388");
            param[5] = new NpgsqlParameter("@publisher_id", 1);

            return param;
        }

        public IActionResult Favorite()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}