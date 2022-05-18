using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Books.Models
{
    [Table("Books")]
     public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Descripcion { get; set; }
        public string Autor { get; set; }
        [ForeignKey(typeof(Date))]
        public int FKDateId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Date Date { get; set; }
    }
}
