using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class myNewDevicePage : ContentPage
    {
        
        public myNewDevicePage()
        {
            InitializeComponent();
            OpenEditor();
        }
        public void OpenEditor()
        {
            
            // Создание однострочного текстового поля для названия
            Entry newDeviceName = new Entry()
            {
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Название",
                Style = (Style)App.Current.Resources["ValidInputStyle"] //ссылка на наш стиль, содержащий состояние, а также установка для него обработчика InputTextChanged(...), который будет это состояние отслеживать.
            };
            newDeviceName.TextChanged += (sender, e) => InputTextChanged(sender, e, newDeviceName);
            stackLayout.Children.Add(newDeviceName);

            // Создание многострочного поля для описания
            var newDeviceDescription = new Editor
            {
                HeightRequest = 200,
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Описание",
                Style = (Style)App.Current.Resources["ValidInputStyle"]
            };
            newDeviceDescription.TextChanged += (sender, e) => InputTextChanged(sender, e, newDeviceDescription);

            // Создание кнопки
            var addButton = new Button
            {
                Text = "Добавить",
                Margin = new Thickness(30, 10),
                BackgroundColor = Color.Silver,

            };


            // Создаем заголовок для переключателя
            var switchHeader = new Label { Text = "Не использует газ", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 5, 0, 0) };
            stackLayout.Children.Add(switchHeader);

            // Создаем переключатель
            Switch switchControl = new Switch
            {
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Center,
                ThumbColor = Color.DodgerBlue,
                OnColor = Color.LightSteelBlue,
            };
            // Регистрируем обработчик события переключения
            switchControl.Toggled += (sender, e) => SwitchHandler(sender, e, switchHeader);
            addButton.Clicked += (sender, eventArgs) => AddButtonClicked(sender, eventArgs, new View[]
            {
                newDeviceName,
                newDeviceDescription,
                switchControl
            });

            // Добавляем всё на страницу
            stackLayout.Children.Add(newDeviceName);
            stackLayout.Children.Add(newDeviceDescription);
            stackLayout.Children.Add(switchControl);
            stackLayout.Children.Add(addButton);
            this.Content = stackLayout;
            Content.BackgroundColor = Color.FromRgb(100, 80, 80);
        }

        /// <summary>
        /// Обработчик-валидатор текстовых полей, который будет переключать состояния
        /// </summary>
        private void InputTextChanged(object sender, TextChangedEventArgs e, InputView view)
        {
            // Регулярное выражение для описания специальных символов
            Regex rgx = new Regex("[^A-Za-z0-9]");
            // Не разрешаем использовать специальные символы в названии и описании, если они есть, то проставляем Invalid
            VisualStateManager.GoToState(view, rgx.IsMatch(view.Text) ? "Invalid" : "Valid");
        }

        /// <summary>
        /// Обработка переключателя
        /// </summary>
        public void SwitchHandler(object sender, ToggledEventArgs e, Label header)
        {
            if (!e.Value)
            {
                header.Text = "Не использует газ";
                return;
            }

            header.Text = "Использует газ";
        }
        /// <summary>
        /// Кнопка сохранения деактивирует все контролы
        /// </summary>
        private void AddButtonClicked(object sender, EventArgs e, View[] views)
        {
            foreach (var view in views)
                view.IsEnabled = false;
        }
    }
}