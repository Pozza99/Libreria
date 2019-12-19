using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dottor.MyBookLibrary.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Dottor.MyBookLibrary.Data.Models.SBook;

namespace Dottor.MyBookLibrary.Web
{
    
    public class SearchModel : PageModel
    {
        private readonly ISBook _Sbook;

        public SearchModel(ISBook sbook)
        {
            _Sbook = sbook;
        }


        [BindProperty] //utilizziamo la stessa classe per ricevere i dati
        public InputModel Input { get; set; }

        public IEnumerable<Doc> Books { get; set; } = Enumerable.Empty<Doc>();

        public class InputModel
        {
            public string Title { get; set; }
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            Books = await _Sbook.GetFacts(Input.Title);

            return Page();
        }
    }
}