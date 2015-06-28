using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinForms.LocalRepository
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel();

            //more about MessagingCenter: 
            //http://developer.xamarin.com/guides/cross-platform/xamarin-forms/messaging-center/
            MessagingCenter.Subscribe<HomeViewModel, string>(this, "Message", (sender, arg) =>
            {
                // do something whenever the "Hi" message is sent
                // using the 'arg' parameter which is a string

                DisplayAlert("Notification", arg, "Ok");
            });
        }
    }
}
