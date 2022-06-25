using Microsoft.AspNetCore.Mvc;
using project_pbo.Models;
using System.Diagnostics;
using project_pbo.Services;
using System.Web;

namespace project_pbo.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        BookService bookService = new BookService();
        LoanService loanService = new LoanService();
        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["data"] = bookService.GetAllBook();
            ViewData["status"] = HttpContext.Session.GetString("statusUser");

            return View();
        }

        public IActionResult BookOwned()
        {

            ViewData["data"] = loanService.GetAllBook((int)HttpContext.Session.GetInt32("id")!);
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            return View();
        }

        public IActionResult LoanList()
        {

            ViewData["data"] = loanService.GetAllBook(0);
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            return View();
        }

        public IActionResult ManageBook()
        {
            ViewData["data"] = bookService.GetAllBook();
            ViewData["status"] = HttpContext.Session.GetString("statusUser");

            return View();
        }

        public IActionResult AddBook()
        {
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            return View();
        }

        public IActionResult DetailBook(int bookId)
        {
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            ViewData["data"] = bookService.getBookById(bookId);
            return View();
        }

        [HttpGet]
        public IActionResult EditBook(int bookId)
        {
            ViewData["data"] = bookService.getBookById(bookId);
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            return View();
        }

        [HttpPost]
        public void insertData(int userId, int bookId)
        {
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            loanService.insertLoan(loan_date: DateTime.Now, user_id: userId, book_id: bookId);
        }

        [HttpPost]
        public IActionResult Insert(BookModel bookModel)
        {
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            bookService.InsertBook(bookModel.Title!, bookModel.Description!, bookModel.Rating!, bookModel.Isbn!, bookModel.PublisherId, bookModel.Category, bookModel.PublishedDate);

            return RedirectToAction("ManageBook");
        }

        [HttpPost]
        public IActionResult ApplyBookChanges(BookModel bookModel)
        {
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            bookService.UpdateBook(bookModel.BookId, bookModel.Title!, bookModel.Description!, bookModel.Rating!, bookModel.Isbn!, bookModel.PublisherId, bookModel.PublishedDate);

            return RedirectToAction("ManageBook");
        }

        [HttpPost]
        public IActionResult ApplyLoanChanges(LoanModel loanModel)
        {
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            loanService.UpdateLoan(2, loanModel.LoanId);

            return RedirectToAction("LoanList");
        }

        [HttpPost]
        public IActionResult ApplyLoanReturn(LoanModel loanModel)
        {
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            loanService.UpdateLoan(3, loanModel.LoanId);

            return RedirectToAction("BookOwned");
        }

        [HttpPost]
        public void SaveFavorite(int userId, int bookId)
        {
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            bookService.SaveFav(userId, bookId);
        }

        [HttpGet]
        public IActionResult Delete(int bookId)
        {
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            Console.WriteLine(bookId);
            bookService.DeleteBook(bookId);


            return RedirectToAction("ManageBook");
        }

        public IActionResult Favorite()
        {
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            ViewData["data"] = bookService.GetAllFavBook((int)HttpContext.Session.GetInt32("id")!);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<BookModel> FilterFik()
        {
            List<BookModel> data = bookService.GetAllBookFilter("fik");
            ViewData["status"] = HttpContext.Session.GetString("statusUser");

            return data;
        }

        public List<BookModel> FilterNonFik()
        {
            List<BookModel> data = bookService.GetAllBookFilter("nonFik");
            ViewData["status"] = HttpContext.Session.GetString("statusUser");

            return data;
        }

        public List<BookModel> GetAllBook()
        {
            List<BookModel> data = bookService.GetAllBook();
            ViewData["status"] = HttpContext.Session.GetString("statusUser");

            return data;
        }

        public List<BookModel> Filter(string query)
        {
            List<BookModel> data = bookService.GetAllBookSearch(query);
            ViewData["status"] = HttpContext.Session.GetString("statusUser");

            return data;
        }
    }
}