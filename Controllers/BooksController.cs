﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabBack;
using LabBack.Models;

namespace LabBack.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Random()
        {
            var firstBook = new Book() { Name = "English Dictionary" };
            return View(firstBook);
        }
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if(String.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }
            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }
        [Route("Books/relased/{year:regex(^\\Dd{{4}})}/{month:range(1,12)}")]
        public IActionResult ByRelaseDate( int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
