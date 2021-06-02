using MonkeyCache.FileStore;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinPelis.Services;
using XamarinPelis.Views;

namespace XamarinPelis
{
    public partial class App : Application
    {
        private static ServiceIoC _ServiceLocator;
        public static ServiceIoC ServiceLocator
        {
            get
            {
                return _ServiceLocator = _ServiceLocator ?? new ServiceIoC();
            }
        }

        public App()
        {
            InitializeComponent();
            Barrel.ApplicationId = "com.XamarinPelis";
            MainPage = new PeliculasView();
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
