using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Settings;
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

                CrossSettings.Current.AddOrUpdateValue("theme",_theme);

                AplicarTheme(value);

            }
        }

        public void Init()
        {
            const string defaultTheme = "Light";
            var theme = CrossSettings.Current
                .GetValueOrDefault("theme",defaultTheme);
            
            Theme = theme;

            AplicarTheme(theme);
        }

        public Task SaveAsync()
        {
            return Task.FromResult(0);
        }

        private void AplicarTheme(string value)
        {
            Type theme;
            if (value == "Light")
            {
               theme=  typeof(LightThemeResources);
            }
            else
            {
               theme = typeof(DarkThemeResources);
            }
            
            App.Current.Resources.MergedWith = theme;
        }
    }
}
