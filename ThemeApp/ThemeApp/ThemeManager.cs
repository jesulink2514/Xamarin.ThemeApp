using System;
using System.Threading.Tasks;
using Xamarin.Forms.Themes;

namespace ThemeApp
{
    public class ThemeManager
    {
        private string _theme;

        public string Theme
        {
            get => _theme;
            set
            {
                _theme = value;
                App.Current.Properties["theme"] = value;
                var themeType = GetThemeType(_theme);
                App.Current.Resources.MergedWith = themeType;
            }
        }

        public void Init()
        {
            const string defaultTheme = "Light";
            if (App.Current.Properties.ContainsKey("theme"))
            {
                _theme = App.Current.Properties["theme"]?.ToString();
            }
            else
            {
                _theme = defaultTheme;
            }
            var themeType = GetThemeType(_theme);
            App.Current.Resources.MergedWith = themeType;
        }

        private Type GetThemeType(string theme)
        {
            if (theme == "Light")
            {
                return typeof(LightThemeResources);
            }
            return typeof(DarkThemeResources);
        }

        public Task SaveAsync()
        {
            return App.Current.SavePropertiesAsync();
        }
    }
}
