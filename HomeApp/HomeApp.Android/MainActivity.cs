﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

namespace HomeApp.Droid
{
    [Activity(Label = "HomeApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            // Создание нового экземпляра класса приложения и его запуск. Определен в пространстве имен Xamarin.Forms.Platform.Android у класса FormsAppCompatActivity.
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {   // Инициализация платформы Xamarin.Essentials
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            // Инициализация платформы Xamarin.Forms
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}