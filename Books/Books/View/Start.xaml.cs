using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Books.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage
    {
        

        StartViewModel vm = new StartViewModel();
        public Start()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.GetAll();
        }
    }
}