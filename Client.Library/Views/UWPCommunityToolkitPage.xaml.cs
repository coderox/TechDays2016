using Microsoft.Toolkit.Uwp.UI.Controls;
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
    public sealed partial class UWPCommunityToolkitPage : Page
    {
        public UWPCommunityToolkitPage()
        {
            this.InitializeComponent();
        }

        private void OnItemClicked(object sender, ItemClickEventArgs e)
        {
            var menuItem = e.ClickedItem as HamburgerMenuGlyphItem;

            switch (menuItem.Label) {
                case "Home":
                    this.ApplicationFrame.Navigate(typeof(MainPage));
                    break;
                case "Globe":
                    this.ApplicationFrame.Navigate(typeof(SecondPage));
                    break;
                case "Settings":
                    this.ApplicationFrame.Navigate(typeof(SettingsPage));
                    break;
                default:
                    break;
            }
        }
    }
}
