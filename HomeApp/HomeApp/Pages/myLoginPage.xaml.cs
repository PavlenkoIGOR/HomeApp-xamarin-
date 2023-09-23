using System;
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
        // Константа для текста кнопки
        public const string BUTTON_TEXT = "Войти";

        //переменная - счетчик количества попыток
        public static int loginCounter = 0;

        public myLoginPage()
        {
            InitializeComponent();
        }
        private async void Login_Click(object sender, EventArgs e)
        {

            /*#region логика количества попыток
            if (loginCounter == 0)
            {
                // Если первая попытка - просто меняем сообщения
                loginButton.Text = "Выполняется вход...";
            }
            else if (loginCounter > 5) // Слишком много попыток - показываем ошибку
            {
                // Деактивируем кнопку
                loginButton.IsEnabled = false;
                // Показываем текстовое сообщение об ошибке
                errorMessage.Text = "Слишком много попыток! Попробуйте позже.";

            #region добавление элемента через код а не форму
                // Добавляем элемент через свойство Children
                stackLayout.Children.Add(new Label
                {
                    Text = "Слишком много попыток! Попробуйте позже.",
                    TextColor = Color.Red,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = new Thickness()
                    {
                        Bottom = 30,
                        Left = 10,
                        Right = 10,
                        Top = 30
                    }
                });
            #endregion
            }
            else
            {
                // Изменяем текст кнопки и показываем количество попыток входа
                loginButton.Text = $"Выполняется вход...   Попыток входа: {loginCounter}";
            }
            // Увеличиваем счетчик
            loginCounter += 1;
            #endregion
            */
            await Navigation.PushAsync(new myRoomsPage());
        }
    }
}