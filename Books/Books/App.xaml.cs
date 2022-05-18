using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Books.Repositories;
using Books.View;

namespace Books
{
    public partial class App : Application
    {


        #region Repo
        private static BookRepository _BookDb;
        public static BookRepository BookDb
        {
            get
            {
                if (_BookDb == null)
                {
                    _BookDb = new BookRepository();
                }
                return _BookDb;

            }
        }


        private static DatePublish _FechasDb;
        public static DatePublish FechasDb
        {
            get
            {
                if (_FechasDb == null)
                {
                    _FechasDb = new DatePublish();
                }
                return _FechasDb;
            }
        }
        #endregion
        public App()
        {
            InitializeComponent();
            FechasDb.Init();
            BookDb.Init();
            MainPage = new NavigationPage(new Start());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
