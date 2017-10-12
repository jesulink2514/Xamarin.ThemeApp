using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Themes;

namespace ThemeApp.ViewModels
{
    public class SettingsPageViewModel : BindableBase, INavigatedAware
    {
        private string _selectedTheme;

        public List<string> Themes { get; private set; } = new List<string>()
        {
            "Light","Dark"
        };

        public string SelectedTheme
        {
            get => _selectedTheme;
            set => SetProperty(ref _selectedTheme,value);
        }

        public ICommand ApplyCommand { get; private set; }

        public SettingsPageViewModel()
        {
            ApplyCommand = new DelegateCommand(Apply);
        }

        private void Apply()
        {
            var theme = SelectedTheme == "Dark" ? typeof(DarkThemeResources) : typeof(LightThemeResources);
            App.Current.Resources.MergedWith = theme;
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

            var x = typeof(DarkThemeResources);
            var isDark = Application.Current.Resources.MergedWith == x;
            SelectedTheme = isDark ? "Dark" : "Light";
        }
    }
}
