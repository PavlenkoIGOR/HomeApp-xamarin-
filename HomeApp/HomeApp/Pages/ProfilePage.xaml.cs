using HomeApp.Mdels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        /// <summary>
        /// Модель пользовательских данных. Свойство UserInfo содержит ссылку на нашу модель пользовательских данных.
        /// </summary>
        public myUserInfo UserInfo { get; set; }
        public ProfilePage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Вызывается до того, как элемент становится видимым
        /// </summary>
        protected override void OnAppearing()   //Вместо метода-конструктора мы перенесли основную логику страницы 
        {                                       //в метод OnAppearing(), который вызывается непосредственно перед тем, как
                                                //страница становится видимой. Можете использовать его в своих задачах.
                                                //Пробуем достать данные из словаря по ключу, если таких данных нет, то создаем модель и сохраняем в словарь.
            // Проверяем, есть ли в словаре значение
            if (App.Current.Properties.TryGetValue("CurrentUser", out object user))
            {
                UserInfo = user as myUserInfo;
                loginEntry.Text = UserInfo.Name;
                emailEntry.Text = UserInfo.Email;
                
            }
            else
            {
                // Добавляем, если нет
                UserInfo = new myUserInfo();
                App.Current.Properties.Add("CurrentUser", UserInfo); //добавление в локальный словарь (IDictionary)
            }

            // Получим значения ползунков из Preferences.
            // Если значений нет - установим значения по умолчанию (false)
            gasSwitch.On = Preferences.Get("gasState", false);
            climateSwitch.On = Preferences.Get("climateState", false);
            electroSwitch.On = Preferences.Get("electroState", false);

            base.OnAppearing();
        }

        private void NotifyUser(object sender, ToggledEventArgs e)
        {
            if (gasSwitch.On && climateSwitch.On && electroSwitch.On)
                DisplayAlert("Внимание!", "Пользователь получит полный доступ ко всем системам", "OK");
        }

        /// <summary>
        ///  Сохраним информацию о пользователе
        /// </summary>
        private async void saveButton_Clicked(object sender, System.EventArgs e)
        {
            UserInfo.Name = loginEntry.Text;
            UserInfo.Email = emailEntry.Text;

            // Сохраним значения ползунков в настройки.
            Preferences.Set("gasState", gasSwitch.On);
            Preferences.Set("climateState", climateSwitch.On);
            Preferences.Set("electroState", electroSwitch.On);

            // Возврат на предыдущую страницу
            await Navigation.PopAsync();
        }


    }
}