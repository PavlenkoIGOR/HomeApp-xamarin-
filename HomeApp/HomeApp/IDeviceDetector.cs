using HomeApp.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp
{
    /// <summary>
    /// Общий интерфейс для классов отдельных платформ, его конкретные реализации DeviceDetector.cs добавлены в локальные проекты для платформы Android и UWP.
    /// </summary>
    //Классы добавлены, теперь нужно использовать этот функционал в общей разделяемой сборке HomeApp, где у нас описан интерфейс.
    //Для этого сначала добавим для него новый Label на странице LoginPage.xaml в самый конец лейаута:
    public interface IDeviceDetector
    {
        /// <summary>
        /// Получение информации об устройстве
        /// </summary>
        string GetDevice();
    }
}
