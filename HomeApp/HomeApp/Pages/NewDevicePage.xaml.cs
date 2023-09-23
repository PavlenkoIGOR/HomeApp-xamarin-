using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDevicePage : ContentPage
    {
        Button addButton;
        public NewDevicePage()
        {
            InitializeComponent();
            OpenEditor();
            GetDevices();
        }
        public void OpenEditor()
        {
            StackLayout stackLayout = new StackLayout();
            // Создание однострочного текстового поля для названия
            Entry newDeviceName = new Entry()
            {
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Название"
            };

            // Создание многострочного поля для описания
            Editor newDeviceDescription = new Editor
            {
                HeightRequest = 200,
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Описание"
            };

            // Создание кнопки
            addButton = new Button
            {
                Text = "Добавить",
                Margin = new Thickness(30, 10),
                BackgroundColor = Color.Silver,
                
            };

            // Добавляем всё на страницу
            stackLayout.Children.Add(newDeviceName);
            stackLayout.Children.Add(newDeviceDescription);
            stackLayout.Children.Add(addButton);
            this.Content = stackLayout;
            Content.BackgroundColor = Color.FromRgb(100, 80, 80);
        }

        /// <summary>
        /// Метод для выгрузки устройств
        /// </summary>
        public void GetDevices()
        {
            // Создадим некий список устройств.
            // В реальном приложении они могут доставаться из базы или веб-сервиса.
            var homeDevices = new List<string>()
            {
                "Чайник",
                "Стиральная машина",
                "Посудомоечная машина",
                "Мультиварка",
                "Водонагреватель",
                "Плита",
                "Микроволновая печь",
                "Духовой шкаф",
                "Холодильник",
                "Увлажнитель воздуха",
                "Телевизор",
                "Пылесос",
                "Музыкальный центр",
                "Компьютер",
                "Игровая консоль"
            };
            StackLayout innerStack = new StackLayout();
            ScrollView scrollView = new ScrollView();

            foreach (var device in homeDevices)
            {
                Label label = new Label()
                {
                    Text = device,
                    FontSize = 17
                };

                // Контейнер Frame, внутри которого будет отображаться текстовый элемент
                Frame frame = new Frame()
                {
                    BorderColor = Color.Gray,
                    BackgroundColor = Color.FromHex("#e1e1e1"),
                    CornerRadius = 4,
                    Margin = new Thickness(10, 1)
                };
                // Задаем содержимое контейнера Frame
                frame.Content = label;
                // Добавляем фреймы в стек для их отображения в едином списке по порядку
                innerStack.Children.Add(frame);
            }
            // Сохраним стек внутрь уже имеющегося в xaml-файле блока прокручиваемой разметки
            scrollView.Content = innerStack;
            this.Content = scrollView;
        }
    }
}