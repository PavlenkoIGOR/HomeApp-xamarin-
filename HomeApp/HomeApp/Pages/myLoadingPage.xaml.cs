﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class myLoadingPage : ContentPage
    {
        public myLoadingPage()
        {
            InitializeComponent();
            // Объявим новый текстовый элемент
            Label header = new Label() { Text = $"Запуск вашего первого приложения{Environment.NewLine} на Xamarin..." };

            // Здесь можно сразу установить стили и шрифт
            header.Opacity = 0;
            header.HorizontalTextAlignment = TextAlignment.Center;
            header.VerticalTextAlignment = TextAlignment.Center;
            header.FontSize = 21;
            // Можем даже задать анимацию
            header.FadeTo(1, 3000);

            // Инициализация свойства Content новым элементом.
            this.Content = header;
        }
    }
}