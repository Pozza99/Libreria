using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Dottor.MyBookLibrary.Data.Models.SBook;

namespace Dottor.MyBookLibrary.Data
{
    public interface ISBook
    {
        Task<IEnumerable<Doc>> GetFacts(string title);

        Task<BookDetailsResult> GetDetails(string isbn);
    }
}
