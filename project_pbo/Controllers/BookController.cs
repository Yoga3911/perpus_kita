﻿using Microsoft.AspNetCore.Mvc;
using Npgsql;
using project_pbo.Models;
using System.Data;
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
            bookService.InsertBook();
            
            return View();
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