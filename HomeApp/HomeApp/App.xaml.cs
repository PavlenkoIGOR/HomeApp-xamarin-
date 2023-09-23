using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HomeApp.Pages;

namespace HomeApp
{
    public partial class App : Application
    {
        public App()
        {
            // инициализация интерфейса
            InitializeComponent();
            // Инициализация главного экрана
            MainPage = new myDevicesPage();/*new myPaddingPage();*//*new myClimatePage();*//*new myDevicesPage();*//*new NavigationPage(new myLoginPage());*//*new myRegistrationPage();*//*new myLoginPage();*//*new myLoadingPage();*//*new MainPage();*/
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
