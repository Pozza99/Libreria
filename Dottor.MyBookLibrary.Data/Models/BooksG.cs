using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.MyBookLibrary.Data.Models
{
    [Table("Genres")]
    public class BooksG
    {
        [Key]
        public byte Id { get; set; }

        public string Description { get; set; }
    }
}
