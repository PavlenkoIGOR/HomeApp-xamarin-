using HomeApp.Mdels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Reflection;

namespace HomeApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class myDeviceListPage : ContentPage
	{
        //public List<HomeDevice> Devices { get; set; } = new List<HomeDevice>();
        //вместо List теперь
        /// <summary>
        /// Группируемая коллекция
        /// </summary>
        public ObservableCollection<Group<string, HomeDevice>> DeviceGroups { get; set; } = new ObservableCollection<Group<string, HomeDevice>>();

        /// <summary>
        /// Ссылка на выбранный объект
        /// </summary>
        HomeDevice SelectedDevice;
        public myDeviceListPage ()
		{
			InitializeComponent ();
        }

        //Логика наполнения страницы данными теперь происходит не в методе-конструкторе, а в методе, вызываемом при появлении страницы в зоне видимости — OnAppearing().
        protected async override void OnAppearing()
        {
            // Загрузка данных из базы
            var devicesFromDb = await App.HomeDevices.GetHomeDevices();
            // Мапим сущности БД в сущности бизнес-логики
            var deviceList = App.Mapper.Map<Mdels.HomeDevice[]>(devicesFromDb);

            // Сгруппируем по комнатам
            var devicesByRooms = deviceList.GroupBy(d => d.Room).Select(g => new Group<string, HomeDevice>(g.Key, g));

            // Сохраним
            DeviceGroups = new ObservableCollection<Group<string, HomeDevice>>(devicesByRooms);
            BindingContext = this;

            base.OnAppearing();
        }

        /// <summary>
        /// Обработчик нажатия
        /// </summary>
        private void deviceList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // распаковка модели из объекта
            var tappedDevice = (HomeDevice)e.Item;
            // уведомление
            DisplayAlert("Нажатие", $"Вы нажали на элемент {tappedDevice.Name}", "OK"); ; ;
        }

        /*************************<!--ObservableCollection-->*******************************/
        /// <summary>
        /// Обработчик выбора
        /// </summary>
        private void deviceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedDevice = (HomeDevice)e.SelectedItem;
        }
        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            // Возврат на первую страницу стека навигации (корневую страницу приложения) - экран логина
            await Navigation.PopAsync();
        }

        private async void NewDeviceButton_Clicked(object sender, EventArgs e)
        {
            // Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
            await Navigation.PushAsync(new myNewDevicePage(null, null));
        }

        /// <summary>
        /// обработчик новой кнопки «Изменить»
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void EditDeviceButton_Clicked(object sender, EventArgs e)
        {
            // проверяем, выбрал ли пользователь устройство из списка
            if (SelectedDevice == null)
            {
                await DisplayAlert(null, $"Пожалуйста, выберите устройство!", "OK");
                return;
            }

            // Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
            await Navigation.PushAsync(new myDevicePage("Изменить устройство", SelectedDevice));
        }
        private async void UserProfileButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            // Получаем сущность базы данных, которую следует удалить (мапим из внутренней сущности, представляющей выбранное устройство)
            var deviceToDelete = App.Mapper.Map<Data.Tables.HomeDevice>(SelectedDevice);
            // Удаляем сущность из бд
            await App.HomeDevices.DeleteHomeDevice(deviceToDelete);

            // Обновляем интерфейс
            var grp = DeviceGroups.FirstOrDefault(g => g.Name == SelectedDevice.Room);
            var deviceToRemove = grp.FirstOrDefault(d => d.Id == deviceToDelete.Id);
            grp.Remove(deviceToRemove);
        }


        ///// <summary>
        ///// Обработчик добавления нового устройства
        ///// </summary>
        //private async void AddDevice(object sender, EventArgs e)
        //{
        //    // Запрос и валидация имени устройства
        //    var newDeviceName = await DisplayPromptAsync("Новое устройство", "Введите имя устройства", "Продолжить", "Отмена");
        //    if (Devices.Any(d => d.Name.CompareTo(newDeviceName.Trim()) == 0))
        //    {
        //        await DisplayAlert("Ошибка", $"Устройство '{newDeviceName}' уже существует", "ОК");
        //        return;
        //    }

        //    // Запрос описания устройства
        //    var newDeviceDescription = await DisplayPromptAsync(newDeviceName, "Добавьте краткое описание устройства", "Сохранить", "Отмена");

        //    // Добавление устройства и уведомление пользователя
        //    Devices.Add(new HomeDevice(newDeviceName, description: newDeviceDescription));
        //    await DisplayAlert(null, $"Устройство '{newDeviceName}' успешно добавлено", "ОК");
        //}

        ///// <summary>
        ///// Обработчик удаления устройства
        ///// </summary>
        //private async void RemoveDevice(object sender, EventArgs e)
        //{
        //    // Получаем и "распаковываем" выбранный элемент
        //    var deviceToRemove = deviceList.SelectedItem as HomeDevice;
        //    if (deviceToRemove != null)
        //    {
        //        // Удаляем
        //        Devices.Remove(deviceToRemove);
        //        // Уведомляем пользователя
        //        await DisplayAlert(null, $"Устройство '{deviceToRemove.Name}' удалено", "ОК");
        //    }
        //}
    }
}