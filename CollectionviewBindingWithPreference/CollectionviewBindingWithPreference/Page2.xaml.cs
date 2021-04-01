using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionviewBindingWithPreference
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var res = Preferences.Get("item2", false);

            Preferences.Set("item2", !res);



            MessagingCenter.Send<App, string>((App)App.Current, "OneMessage", "");
        }
    }
}