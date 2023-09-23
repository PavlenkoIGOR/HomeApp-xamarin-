using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace HomeApp
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class myPaddingPage : ContentPage
    {
        //StackLayout myStackLayout;
        public myPaddingPage()
        {
            InitializeComponent();
            {
                //this.LoadFromXaml(typeof(myPaddingPage));
                StackLayout myStackLayout = this.FindByName<StackLayout>("myStackLayout");
                myStackLayout.VerticalOptions = LayoutOptions.Center;
                myStackLayout.Children.Add( new BoxView()
                {
                    Margin = new Thickness(20), BackgroundColor = Color.FromRgb(100, 80, 10), HeightRequest = 150
                });
            };
        }
        
        public void OnPainting()
        {
            
        }
    }
}