﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class myLoginPage : ContentPage
    {
        public
        const string BUTTON_TEXT = "Войти";
        public static int loginCouner = 0;
        IDeviceDetector detector = DependencyService.Get<IDeviceDetector>();

        public myLoginPage()
        {
            InitializeComponent();

            if (Device.Idiom == TargetIdiom.Desktop)
                loginButton.CornerRadius = 0;

            //runningDevice.Text = detector.GetDevice(); //определение на какой плаиформе запущено приложение (выводится на экран девайса)

            // Устанавливаем динамический ресурс с помощью специально метода
            infoMessage.SetDynamicResource(Label.TextColorProperty, "errorColor");
        }

        /// <summary>
        /// По клику "логинимся" на главный экран приложения
        /// </summary>
        private async void Login_Click(object sender, EventArgs e)
        {
            loginButton.Text = $"Выполняется вход..";
            // Имитация задержки (приложение загружает данные с сервера)
            await Task.Delay(150);

            // Переход на следующую страницу - страницу списка устройств
            await Navigation.PushAsync(new myDeviceListPage());
            // Восстановим первоначальный текст на кнопке (на случай, если пользователь вернется на этот экран чтобы выполнить вход снова)
            loginButton.Text = BUTTON_TEXT;
        }
        ///// <summary>
        ///// По клику обрабатываем счётчик и выводим разные сообщения
        ///// </summary>
        //private void Login_Click(object sender, EventArgs e)
        //{
        //    if (loginCouner == 0)
        //    {
        //        loginButton.Text = $"Выполняется вход..";
        //    }
        //    else if (loginCouner > 5)
        //    {
        //        loginButton.IsEnabled = false;

        //        // Обновляем динамический ресурс по необходимости
        //        Resources["errorColor"] = Color.FromHex("#e70d4f");
        //        infoMessage.Text = "Слишком много попыток! Попробуйте позже";
        //    }
        //    else
        //    {
        //        // Обновляем динамический ресурс по необходимости
        //        Resources["errorColor"] = Color.FromHex("#ff8e00");

        //        loginButton.Text = $"Выполняется вход...";
        //        infoMessage.Text = $" Попыток входа: { loginCouner}";
        //    }

        //    loginCouner += 1;
        //}
        //private async void Login_Click(object sender, EventArgs e)
        //{

        //    /*#region логика количества попыток
        //    if (loginCounter == 0)
        //    {
        //        // Если первая попытка - просто меняем сообщения
        //        loginButton.Text = "Выполняется вход...";
        //    }
        //    else if (loginCounter > 5) // Слишком много попыток - показываем ошибку
        //    {
        //        // Деактивируем кнопку
        //        loginButton.IsEnabled = false;
        //        // Показываем текстовое сообщение об ошибке
        //        errorMessage.Text = "Слишком много попыток! Попробуйте позже.";

        //    #region добавление элемента через код а не форму
        //        // Добавляем элемент через свойство Children
        //        stackLayout.Children.Add(new Label
        //        {
        //            Text = "Слишком много попыток! Попробуйте позже.",
        //            TextColor = Color.Red,
        //            VerticalTextAlignment = TextAlignment.Center,
        //            HorizontalTextAlignment = TextAlignment.Center,
        //            Padding = new Thickness()
        //            {
        //                Bottom = 30,
        //                Left = 10,
        //                Right = 10,
        //                Top = 30
        //            }
        //        });
        //    #endregion
        //    }
        //    else
        //    {
        //        // Изменяем текст кнопки и показываем количество попыток входа
        //        loginButton.Text = $"Выполняется вход...   Попыток входа: {loginCounter}";
        //    }
        //    // Увеличиваем счетчик
        //    loginCounter += 1;
        //    #endregion
        //    */
        //    await Navigation.PushAsync(new myRoomsPage());
        //}
    }
}