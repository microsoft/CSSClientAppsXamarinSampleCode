using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CollectionviewBindingWithPreference
{
    public class AchievementsViewModule
    {
        public ObservableCollection<Achievement> Achievements { get; set; }

        public AchievementsViewModule()
        {
            Achievements = new ObservableCollection<Achievement>();



            Achievements.Add(new Achievement
            {
                Title = "first title",
                Subtitle = "first subtitle",
                ImageUrl = "image.png",
                Completed = Preferences.Get("item1", false),
                CompletedDate = DateTime.Now
            });
            Achievements.Add(new Achievement
            {
                Title = "second title",
                Subtitle = "second subtitle",
                ImageUrl = "image.png",
                Completed = Preferences.Get("item2", false),
                CompletedDate = DateTime.Now
            });
            Achievements.Add(new Achievement
            {
                Title = "third title",
                Subtitle = "third subtitle",
                ImageUrl = "image.png",
                Completed = Preferences.Get("item3", false),
                CompletedDate = DateTime.Now
            });

            MessagingCenter.Subscribe<App, string>(App.Current, "OneMessage", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() => {
                    Achievements.Clear();

                    Achievements.Add(new Achievement
                    {
                        Title = "first title",
                        Subtitle = "first subtitle",
                        ImageUrl = "image.png",
                        Completed = Preferences.Get("item1", false),
                        CompletedDate = DateTime.Now
                    });
                    Achievements.Add(new Achievement
                    {
                        Title = "second title",
                        Subtitle = "second subtitle",
                        ImageUrl = "image.png",
                        Completed = Preferences.Get("item2", false),
                        CompletedDate = DateTime.Now
                    });
                    Achievements.Add(new Achievement
                    {
                        Title = "third title",
                        Subtitle = "third subtitle",
                        ImageUrl = "image.png",
                        Completed = Preferences.Get("item3", false),
                        CompletedDate = DateTime.Now
                    });
                });
            });
        }
    }

    public class Achievement
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public DateTime CompletedDate { get; set; }
        public Boolean Completed { get; set; }
        public string ImageUrl { get; set; }
    }
}
