using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WebViewInputTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            webview.Source = new HtmlWebViewSource() { Html = "<html><head><meta name=\"viewport\" content=\"width=device-width,initial-scale=1\"></head><body><div style=\"width:50px; height: 600px; background - color:blue\"></div><input type=\"text\" /></body></html>" };
        }
    }
}
