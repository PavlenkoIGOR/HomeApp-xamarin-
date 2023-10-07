using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HomeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для установки будильника
        /// </summary>
        private void SetAlarm(object sender, EventArgs eventArgs)
        {
            // Основной контейнер компоновки
            var layout = new StackLayout() { Margin = new Thickness(20) };

            // Заголовок
            var header = new Label { Text = "Установить будильник", Margin = new Thickness(0, 20, 0, 0), FontSize = 20, HorizontalTextAlignment = TextAlignment.Center };
            layout.Children.Add(header);

            // Виджет выбора даты с описанием
            var datePickerText = new Label { Text = "Дата запуска", Margin = new Thickness(0, 20, 0, 0) };
            layout.Children.Add(datePickerText);
            var datePicker = new DatePicker
            {
                Format = "D",
                MaximumDate = DateTime.Now.AddDays(7),
                MinimumDate = DateTime.Now.AddDays(-7),
            };
            layout.Children.Add(datePicker);

            // Виджет выбора времени с описанием
            var timePickerText = new Label { Text = "Время запуска ", Margin = new Thickness(0, 20, 0, 0) };
            layout.Children.Add(timePickerText);
            var timePicker = new TimePicker
            {
                Time = new TimeSpan(13, 0, 0)
            };
            layout.Children.Add(timePicker);

            // Переключатель громкости с описанием
            Slider slider = new Slider
            {
                Minimum = 0,
                Maximum = 30,
                Value = 5.0,
                ThumbColor = Color.DodgerBlue,
                MinimumTrackColor = Color.DodgerBlue,
                MaximumTrackColor = Color.Gray
            };
            var sliderText = new Label { Text = $"Громкость: {slider.Value}", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 30, 0, 0) };
            // Регистрируем обработчик события изменения громкости
            slider.ValueChanged += (s, e) => VolumeHandler(s, e, sliderText);
            layout.Children.Add(sliderText);
            layout.Children.Add(slider);

            // Переключатель и заголовок для него
            var switchHeader = new Label { Text = "Повторять каждый день", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 5, 0, 0) };
            layout.Children.Add(switchHeader);
            Switch switchControl = new Switch
            {
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Center,
                ThumbColor = Color.DodgerBlue,
                OnColor = Color.LightSteelBlue,
            };
            layout.Children.Add(switchControl);

            // Кнопка сохранения и обработчик для неё
            var saveAlarmButton = new Button { Text = "Сохранить", BackgroundColor = Color.Silver, Margin = new Thickness(0, 5, 0, 0) };
            saveAlarmButton.Clicked += (s, e) => SaveAlarmHandler(s, e, datePicker.Date + timePicker.Time);
            layout.Children.Add(saveAlarmButton);

            // Инициализация леаута
            this.Content = layout;
        }

        /// <summary>
        /// Обработчик события изменения громкости
        /// </summary>
        private void VolumeHandler(object sender, ValueChangedEventArgs e, Label header)
        {
            header.Text = String.Format("Громкость: {0:F1}", e.NewValue);
        }

        /// <summary>
        /// Обработчик сохранения будильника
        /// </summary>
        void SaveAlarmHandler(object sender, EventArgs e, DateTime alarmDate)
        {
            var layout = new StackLayout() { Margin = new Thickness(20), VerticalOptions = LayoutOptions.Center };
            var dateHeader = new Label { Text = $"Будильник сработает:", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center };
            var dateText = new Label { Text = $"{alarmDate.Day}.{alarmDate.Month} в {alarmDate.Hour}:{alarmDate.Minute}", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center };

            layout.Children.Add(dateHeader);
            layout.Children.Add(dateText);
            this.Content = layout;
        }
    }
}
