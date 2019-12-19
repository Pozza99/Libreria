using Dottor.MyBookLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.MyBookLibrary.Data
{
    public interface IBooksRepository
        : IRepository<Book, int>
    {
        IEnumerable<Book> GetByGens(byte GenereId);
    }


    //public interface IBooksRepository
    //{
    //    Book Get(int id);

    //    IEnumerable<Book> GetAll();

    //    void Insert(Book model);

    //    void Update(Book model);

    //    void Delete(int id);
    //}
}
