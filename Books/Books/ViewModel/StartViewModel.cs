using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Bogus;
using Books.Models;
using Books.View;
using Books.Repositories;

namespace Books.ViewModel
{
    public class StartViewModel : BaseViewModel
    {
        
        public ObservableCollection<Book> Libros { get; set; }
        public ICommand cmdAgregaLibro { get; set; }
        public ICommand cmdModifcaLibro { get; set; }
        public StartViewModel()
        {
            Libros = new ObservableCollection<Book>();
            cmdAgregaLibro = new Command(() => cmdAgregaLibroMetodo());
            cmdModifcaLibro = new Command<Book>((item) => cmdModifcaLibroMetodo(item));

        }
        private void cmdModifcaLibroMetodo(Book libro)
        {
            App.Current.MainPage.Navigation.PushAsync(new MattoBook(libro));
        }
        private void cmdAgregaLibroMetodo()
        {
            Book libro = new Faker<Book>()
                .RuleFor(c => c.Autor, f => f.Name.FirstName())
                .RuleFor(c => c.Autor, f => f.Name.FirstName());

            Random rnd = new Random();
            DateTime datetoday = DateTime.Now;
            int rndYear = rnd.Next(1995, datetoday.Year);
            int rndMonth = rnd.Next(1, 12);
            int rndDay = rnd.Next(1, 31);
            DateTime generateDate = new DateTime(rndYear, rndMonth, rndDay);
            Debug.WriteLine($"FECHA ALEATORIA {generateDate}");
            libro.Titulo = "Diccionario fácil";
            libro.Editorial = "Espaninglish";
            libro.Descripcion = "Todo en uno";
            libro.Date = new Date() { Fecha = generateDate };
            App.Current.MainPage.Navigation.PushAsync(new MattoBook(libro));

            Debug.WriteLine($"FECHA ALEATORIA {generateDate}");
        }
        public void GetAll()

        {
            if (Libros != null)
            {
                Libros.Clear();
                App.BookDb.GetAll().ForEach(item => Libros.Add(item));
            }
            else
            {
                Libros = new ObservableCollection<Book>(App.BookDb.GetAll());

            }
            OnPropertyChanged();
        }


    }
}

