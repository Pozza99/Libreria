using Dottor.MyBookLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.MyBookLibrary.Data
{
    public interface IBookReadHistoriesRepository
        :IRepository<BookReadHistory, int>
    {
        IEnumerable<BookReadHistory> GetByBook(int bookId);
    }

    //public interface IBookReadHistoriesRepository
    //{
    //    BookReadHistory Get(int id);

    //    IEnumerable<BookReadHistory> GetAll();

    //    void Insert(BookReadHistory model);

    //    void Update(BookReadHistory model);

    //    void Delete(int id);
    //}
}
