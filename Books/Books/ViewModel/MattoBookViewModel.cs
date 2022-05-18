using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Books.Models;

namespace Books.ViewModel
{
    public class MattoBookViewModel
    {
        public Book Libro { get; set; }
        public ICommand cmdGrabaLibro { get; set; }
        public MattoBookViewModel(Book libro)
        {
            Libro = libro;
            cmdGrabaLibro = new Command<Book>((item) => cmdGrabaLibroMetodo(item));
        }
        private void cmdGrabaLibroMetodo(Book libro)
        {
            App.BookDb.InsertOrUpdate(libro);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
