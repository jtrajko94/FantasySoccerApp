using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Essentials;

namespace FantasySoccerApp.Utilities
{
    public static class Settings
    {
        public static string APIRootUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5003" : "http://localhost:5003";

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string CurrentUserAccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("CurrentUserAccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("CurrentUserAccessToken", value);
            }
        }

        public static DateTime CurrentUserAccessTokenExpiration
        {
            get
            {
                return AppSettings.GetValueOrDefault("CurrentUserAccessTokenExpiration", DateTime.UtcNow);
            }
            set
            {
                AppSettings.AddOrUpdateValue("CurrentUserAccessTokenExpiration", value);
            }
        }

        public static string CurrentUserEmail
        {
            get
            {
                return AppSettings.GetValueOrDefault("CurrentUserEmail", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("CurrentUserEmail", value);
            }
        }

        public static string CurrentUserPassword
        {
            get
            {
                return AppSettings.GetValueOrDefault("CurrentUserPassword", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("CurrentUserPassword", value);
            }
        }
    }
}
