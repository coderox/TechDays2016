using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Client.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void SecondPage(object sender, RoutedEventArgs e)
        {
            // folders
            Frame.Navigate(typeof(SecondPage));
        }

        private void ThirdPage(object sender, RoutedEventArgs e)
        {
            // pages
            Frame.Navigate(typeof(ThirdPage));
        }

        private void FourthPage(object sender, RoutedEventArgs e)
        {
            // viewstate
            Frame.Navigate(typeof(FourthPage));
        }

        private void FifthPage(object sender, RoutedEventArgs e)
        {
            // device family triggers
            Frame.Navigate(typeof(FifthPage));
        }

        private void SixthPage(object sender, RoutedEventArgs e)
        {
            // explicit
            switch (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) {
                case "Windows.Mobile":
                    Frame.Navigate(typeof(SixthPage_Mobile));
                    break;
                case "Windows.Desktop":
                    Frame.Navigate(typeof(SixthPage));
                    break;
                default:
                    break;
            }
        }

        private void SeventhPage(object sender, RoutedEventArgs e)
        {
            // based on recommendations: https://msdn.microsoft.com/windows/uwp/layout/screen-sizes-and-breakpoints-for-responsive-design
            Frame.Navigate(typeof(SeventhPage));
        }
    }
}
