using System;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.App;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Navigation;
using Google.Android.Material.Snackbar;

namespace SaveBitmapToLocalStorage
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        public static Context Context { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            AndroidX.AppCompat.Widget.Toolbar toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            Context = this;
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
            PermissionCheck();
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_camera)
            {
                // Handle the camera action
            }
            else if (id == Resource.Id.nav_gallery)
            {

            }
            else if (id == Resource.Id.nav_slideshow)
            {

            }
            else if (id == Resource.Id.nav_manage)
            {

            }
            else if (id == Resource.Id.nav_share)
            {

            }
            else if (id == Resource.Id.nav_send)
            {

            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

        private void PermissionCheck()
        {
            if (CheckSelfPermission(Manifest.Permission.ReadExternalStorage) != Permission.Granted || CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Permission.Granted)
            {
                var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
                ActivityCompat.RequestPermissions(this, permissions, 1);
            }
            else
            {
                var input = FindViewById<TextView>(Resource.Id.inputNumber);
                Share(input.Text, Resources.GetString(Resource.String.title), Resources.GetString(Resource.String.share_msg));
            }
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            switch (requestCode)
            {
                case 1:
                    {
                        // If request is cancelled, the result arrays are empty. 
                        if (grantResults.Length > 0 && grantResults[0] == Permission.Granted && grantResults[1] == Permission.Granted)
                        {
                            // permission was granted, yay! Do the contacts-related task you need to do. 
                            var input = FindViewById<TextView>(Resource.Id.inputNumber);
                            Share(input.Text, Resources.GetString(Resource.String.title), Resources.GetString(Resource.String.share_msg));
                        }
                        else
                        {
                            // permission denied, boo! Disable the functionality that depends on this permission. 
                        }
                        return;
                    }

                    // other 'case' lines to check for other permissions this app might request 
            }
        }



        public void Share(string filename, string title, string content)
        {
            if (string.IsNullOrEmpty(filename) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content)) return;

            var imageView = FindViewById<ImageView>(Resource.Id.generatedImage);
            Android.Graphics.Drawables.BitmapDrawable bitmapDrawable = ((Android.Graphics.Drawables.BitmapDrawable)imageView.Drawable);
            if (bitmapDrawable != null)
            {
                Bitmap bitmap = bitmapDrawable.Bitmap;
                string testPath = Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath + Java.IO.File.Separator + $"{filename}.png";
                using (System.IO.FileStream os = new System.IO.FileStream(testPath, System.IO.FileMode.Create))
                {
                    bitmap.Compress(Bitmap.CompressFormat.Png, 100, os);
                    os.Close();
                }

                var sharingIntent = new Intent();
                sharingIntent.SetAction(Intent.ActionSend);
                sharingIntent.SetType("image/*");
                sharingIntent.PutExtra(Intent.ExtraSubject, Resources.GetString(Resource.String.contact_subject));
                sharingIntent.PutExtra(Intent.ExtraText, content);
                sharingIntent.PutExtra(Intent.ExtraStream, testPath);
                StartActivity(Intent.CreateChooser(sharingIntent, title));
            }
        }

        private void NavigationUrl(string url)
        {
            var uri = Android.Net.Uri.Parse(url);
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }



    }
}

