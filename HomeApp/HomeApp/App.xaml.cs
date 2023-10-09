using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HomeApp.Pages;
using HomeApp.Data.Tables;
using AutoMapper;
using HomeApp.Data;
using System.IO;

namespace HomeApp
{
    public partial class App : Application
    {
        // Инициализация репозитория
        public static HomeDeviceRepository HomeDevices = new HomeDeviceRepository(
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                $"homedevices.db")
            );
        public static IMapper Mapper { get; set; }
        public App()
        {
            Mapper = CreateMapper();
            // инициализация интерфейса
            InitializeComponent();
            // Инициализация главного экрана
            MainPage = new NavigationPage(new myLoginPage());
        }

        /// <summary>
        /// Создание Автомаппера для преобразования сущностей
        /// </summary>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.Tables.HomeDevice, Mdels.HomeDevice>();
                cfg.CreateMap<Mdels.HomeDevice, Data.Tables.HomeDevice>();
            });

            return config.CreateMapper();
        }

        protected async override void OnStart()
        {
            await HomeDevices.InitDatabase();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
