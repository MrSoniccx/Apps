using System;
using System.Collections.Generic;
using System.Text;
using Books.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace Books.Repositories
{
    public class BookRepository
    {
        SQLiteConnection connection;
        public BookRepository()
        {
            connection = new SQLiteConnection(Constantes.Constants.DatabasePath, Constantes.Constants.Flags);
            connection.CreateTable<Book>();
        }
        public void Init()
        {
            connection.CreateTable<Book>();
        }
        public void InsertOrUpdate(Book libro)
        {
            if (libro.Id == 0)
            {
                Console.WriteLine($"Id Before {libro.Id}");
                connection.InsertWithChildren(libro);
                Console.WriteLine($"Id After {libro.Id}");
            }
            else
            {
                Console.WriteLine($"Id Before {libro.Id}");
                connection.Update(libro);
                App.FechasDb.InsertOrUpdate(libro.Date);
                Console.WriteLine($"Id After {libro.Id}");
            }
        }
        public Book GetById(int Id)
        {
            return connection.Table<Book>().FirstOrDefault(item => item.Id == Id);
            
        }
        public List<Book> GetAll()
        {
            return connection.GetAllWithChildren<Book>();
        }

        public void DeleteItem(int Id)
        {
            Book libro = GetById(Id);
            connection.Delete(libro);
        }
    }
}
