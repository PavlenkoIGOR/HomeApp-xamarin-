using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

//пока нигде не подключен
namespace HomeApp
{
    class FocusTriggerAction : TriggerAction<Entry>
    {
        /// <summary>
        /// Действие триггера, добавляющее анимацию для полей в фокусе
        /// </summary>
        protected override void Invoke(Entry sender)
        {
            if (sender.IsFocused)
                sender.FadeTo(1);
        }

        //куда следующий кусок вставить пока хз:
//        var passField = new Entry();

//        // определяем триггер для поля ввода пароля
//        var passFieldTrigger = new Trigger(typeof(Entry))
//        {
//            Property = Entry.IsFocusedProperty,
//            Value = true
//        };

//        passFieldTrigger.Setters.Add(new Setter
//    {
//       Property = Entry.BackgroundColorProperty,
//       Value = Color.Gray
//    });
     
//    // добавляем триггер
//    passField.Triggers.Add(passFieldTrigger);
     
//    Content = new StackLayout
//    {
//       Children = { passField
//}
//    };  
    }
}
