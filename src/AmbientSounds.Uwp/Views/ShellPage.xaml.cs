﻿using AmbientSounds.Services;
using AmbientSounds.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AmbientSounds.Views
{
    /// <summary>
    /// The root frame used to power the backgrounds of the app.
    /// </summary>
    public sealed partial class ShellPage : Page
    {
        public ShellPage()
        {
            this.InitializeComponent();
            this.DataContext = App.Services.GetRequiredService<ShellPageViewModel>();
            this.Unloaded += (_, _) => { ViewModel.Dispose(); };

            if (App.IsTenFoot)
            {
                // Ref: https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/turn-off-overscan
                ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseCoreWindow);
            }
        }

        public ShellPageViewModel ViewModel => (ShellPageViewModel)this.DataContext;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var navigator = App.Services.GetRequiredService<INavigator>();
            navigator.Frame = MainFrame;

            MainFrame.Navigate(typeof(MainPage));
        }
    }
}
