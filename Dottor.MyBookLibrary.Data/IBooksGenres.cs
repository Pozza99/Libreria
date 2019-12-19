using Dottor.MyBookLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.MyBookLibrary.Data
{
    public interface IBooksGenres
        : IRepository<BooksG, byte>
    {
    }
}
