﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HomeApp
{
    /// <summary>
    /// Действие триггера, меняющее цвет текста, пока поле заполнено неверно
    /// </summary>
    class EmailTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry emailField)
        {
            if (emailField.IsFocused)
            {
                emailField.TextColor = emailField.Text.Contains("@") && emailField.Text.Contains(".") ? Color.AliceBlue : Color.LightPink;
            }
        }
    }
}
