using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Books.Models;
using Books.ViewModel;

namespace Books.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MattoBook : ContentPage
    {
        public MattoBook(Book libro)
        {
            InitializeComponent();
            BindingContext = new MattoBookViewModel(libro);
        }
    }
}