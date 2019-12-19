using Dapper;
using Dapper.Contrib.Extensions;
using Dottor.MyBookLibrary.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dottor.MyBookLibrary.Data.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public BooksRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Delete(new Book() { Id = id});
            }
        }
        public Book Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Book>(@"
SELECT [Id]
      ,[Title]
      ,[Author]
      ,[Description]
      ,[CreationDate]
      ,[GenreId]
      ,[PublishedDate]
      ,[IsRead]
      ,[DateLastUpdate]
      ,[ImageUrl]
      ,[Rate]
  FROM [dbo].[Books]
  WHERE Id = @BookId", new {  BookId = id });
            }
        }
        public IEnumerable<Book> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Book>(@"
SELECT [Id]
      ,[Title]
      ,[Author]
      ,[Description]
      ,[CreationDate]
      ,[GenreId]
      ,[PublishedDate]
      ,[IsRead]
      ,[DateLastUpdate]
      ,[ImageUrl]
      ,[Rate]
  FROM [dbo].[Books]");
            }
        }

        public IEnumerable<Book> GetByGens(byte GenereId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Book>(@"SELECT [Id]
                                      ,[Title]
                                      ,[Author]
                                      ,[Description]
                                      ,[CreationDate]
                                      ,[GenreId]
                                      ,[PublishedDate]
                                      ,[IsRead]
                                      ,[DateLastUpdate]
                                      ,[ImageUrl]
                                      ,[Rate]
                                  FROM [dbo].[Books]
                WHERE [GenreId] = @Gen", new { Gen = GenereId });
            }
        }

        public void Insert(Book model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Insert(model);
            }
        }
        public void Update(Book model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Update(model);
            }
        }
    }
}
