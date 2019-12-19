using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dottor.MyBookLibrary.Data;
using Dottor.MyBookLibrary.Data.Controllers;
using Dottor.MyBookLibrary.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dottor.MyBookLibrary.Web
{
    [Authorize]
    public class AggiungiInSql : PageModel
    {
        private readonly IBooksRepository _booksRepository;
        private readonly ISBook _book;


        public AggiungiInSql(IBooksRepository booksRepository, ISBook book)
        {
            _booksRepository = booksRepository;
            _book = book;
        }

        public async Task<IActionResult> OnGet(string isbn)
        {
            var details = await _book.GetDetails(isbn);
            var sbook = new Book();
            sbook.Author = details.details.authors?.FirstOrDefault()?.name;
            sbook.Title = details.details.title;
            sbook.IsRead = false;
            _booksRepository.Insert(sbook);

            return RedirectToPage("/Index");

        }
    }
}