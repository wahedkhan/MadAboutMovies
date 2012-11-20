using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.ApplicationSettings;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MadAboutMovies
{
    public sealed partial class MyCharmFlyouts : UserControl
    {
        public MyCharmFlyouts()
        {
            this.InitializeComponent();
            SettingsPane.GetForCurrentView().CommandsRequested += CommandsRequested;
        }

        private void CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(new SettingsCommand("a", "About Us", (p) => { cfoAbout.IsOpen = true; }));            
            args.Request.ApplicationCommands.Add(new SettingsCommand("p", "Privacy", (p) => { cfoPrivacy.IsOpen = true; }));
        }

        private async void OnMailTo(object sender, RoutedEventArgs args)
        {
            var hyperlinkButton = sender as HyperlinkButton;
            if (hyperlinkButton != null)
            {
                var uri = new Uri("http://" + hyperlinkButton.Content.ToString());
                await Windows.System.Launcher.LaunchUriAsync(uri);
            }
        }

        private async void OnPrivacyClick(object sender, RoutedEventArgs args)
        {
            var hyperlinkButton = sender as HyperlinkButton;
            if (hyperlinkButton != null)
            {
                var uri = new Uri("http://www.tekpill.com/home/privacy");
                await Windows.System.Launcher.LaunchUriAsync(uri);
            }
        }       
    }
}
