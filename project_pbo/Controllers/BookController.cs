using Microsoft.AspNetCore.Mvc;
using project_pbo.Models;
using System.Diagnostics;
using project_pbo.Services;

namespace project_pbo.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        DbHelper dbHelper = new DbHelper();
        BookService bookService = new BookService();
        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["data"] = bookService.GetAllBook();

            return View();
        }

        public IActionResult BookOwned()
        {
            return View();
        }

        public IActionResult ManageBook()
        {
            ViewData["data"] = bookService.GetAllBook();

            return View();
        }
        
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditBook(BookModel bookModel)
        {
            ViewData["data"] = bookService.getBookById(bookModel.BookId!);
            return View();
        }

        [HttpPost]
        public IActionResult Insert(BookModel bookModel)
        {
            bookService.InsertBook(bookModel.Title!, bookModel.Description!, bookModel.Rating!, bookModel.Isbn!, bookModel.PublisherId, bookModel.PublishedDate);

            return RedirectToAction("ManageBook");
        }

        [HttpPost]
        public IActionResult ApplyBookChanges(BookModel bookModel)
        {
            bookService.UpdateBook(bookModel.BookId, bookModel.Title!, bookModel.Description!, bookModel.Rating!, bookModel.Isbn!, bookModel.PublisherId, bookModel.PublishedDate);

            return RedirectToAction("ManageBook");
        }

        [HttpPost]
        public IActionResult Update()
        {
            //bookService.UpdateBook(1, "", "Hidup itu menyakitkan", "R", "2928109", 1);

            return RedirectToAction("ManageBook");
        }

        [HttpPost]
        public IActionResult Delete()
        {
            bookService.DeleteBook(1);

            return RedirectToAction("ManageBook");
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