using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebViewInputTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPageDemoFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutPageDemoFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutPageDemoFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class FlyoutPageDemoFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutPageDemoFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutPageDemoFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutPageDemoFlyoutMenuItem>(new[]
                {
                    new FlyoutPageDemoFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new FlyoutPageDemoFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new FlyoutPageDemoFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new FlyoutPageDemoFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new FlyoutPageDemoFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}