using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveBitmapToLocalStorage
{
    [Activity(Label = "SplashActivity", MainLauncher = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.Fullscreen);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            LoadLayout();
        }
        private void LoadLayout()
        {
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.Fullscreen);

            var color = Resources.GetColor(Resource.Color.colorBackground, this.ApplicationContext.Theme);
            Window.SetNavigationBarColor(color);
        }

        protected override void OnResume()
        {
            base.OnResume();
            SimulateStartup();
        }

        async void SimulateStartup()
        {
            await Task.Delay(1000);
            //  string testPath = 
            var pathToNewFolder = Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath;
            if (!Directory.Exists(pathToNewFolder))
            {
                Directory.CreateDirectory(pathToNewFolder);
            }

            Intent intent = new Intent("ACTION_MANAGE_APP_ALL_FILES_ACCESS_PERMISSION");
            intent.SetClass(this, typeof(MainActivity));
            intent.SetType(typeof(MainActivity).ToString());
            intent.AddCategory("android.intent.category.DEFAULT");
            intent.SetData(Android.Net.Uri.Parse($"package:{ApplicationContext.PackageName}"));
            StartActivity(intent);
        }

        public override void OnBackPressed() { }
    }

}