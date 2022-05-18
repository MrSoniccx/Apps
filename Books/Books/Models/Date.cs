using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Books.Models
{
    [Table("Dates")]
    public class Date
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
    }
}
