using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dottor.MyBookLibrary.Data;
using Dottor.MyBookLibrary.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dottor.MyBookLibrary.Web.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IBookReadHistoriesRepository _bookshistory;

        public Book Book { get; set; }

        public IEnumerable<BookReadHistory> Bookhistory {get; set;}
        public DetailsModel(IBooksRepository booksRepository , IBookReadHistoriesRepository bookReadHistoriesRepository)
        {
            _booksRepository = booksRepository;
            _bookshistory = bookReadHistoriesRepository;

        }

        public void OnGet(int id)
        {
            Book = _booksRepository.Get(id);

            Bookhistory = _bookshistory.GetByBook(id);
            
        }
    }
}