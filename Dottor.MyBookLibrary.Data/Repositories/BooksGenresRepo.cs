using Dapper.Contrib.Extensions;
using Dottor.MyBookLibrary.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dottor.MyBookLibrary.Data.Repositories
{
    public class BooksGenresRepo : IBooksGenres
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public BooksGenresRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");
        }

        public void Delete(byte id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Delete(new BooksG() { Id = id });
            }
        }

        public BooksG Get(byte id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<BooksG>(id);
            }
        }

        public IEnumerable<BooksG> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<BooksG>();
            }
        }

        public void Insert(BooksG model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Insert(model);
            }
        }

        public void Update(BooksG model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Update(model);
            }
        }
    }
}
