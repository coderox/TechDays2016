using Client.ViewModels;
using System;
using System.Diagnostics;
using Windows.Devices.WiFi;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Client.Views
{
    public sealed partial class TodayPage : Page
    {
        TodayViewModel ViewModel { get { return this.DataContext as TodayViewModel; } }

        ConnectionProfile profile = null;

        public TodayPage()
        {
            this.InitializeComponent();
            
            this.DataContext = new TodayViewModel();

            Loaded += async delegate {
                if (ActualWidth < 600) {
                    ViewModel.MyNewsMaximumRowsOrColumns = 1;
                    VisualStateManager.GoToState(this, "small", false);
                } else if (ActualWidth < 1008) {
                    ViewModel.MyNewsMaximumRowsOrColumns = 2;
                    VisualStateManager.GoToState(this, "medium", false);
                } else if (ActualWidth < 1252) {
                    ViewModel.MyNewsMaximumRowsOrColumns = 3;
                    VisualStateManager.GoToState(this, "large", false);
                } else {
                    ViewModel.MyNewsMaximumRowsOrColumns = 4;
                    VisualStateManager.GoToState(this, "xlarge", false);
                }
                UpdateItemWidth(gridView.ActualWidth-24);


                //NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
                //profile = NetworkInformation.GetInternetConnectionProfile();

                //if (profile.IsWlanConnectionProfile) {
                    await ViewModel.LoadAsync();
                //}
            };
        }

        private void NetworkInformation_NetworkStatusChanged(object sender)
        {
            profile = NetworkInformation.GetInternetConnectionProfile();           
        }

        private void InterestsClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.InterestsPage));
        }

        private void SourcesClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.SourcesPage));
        }

        private void OnEnableSearchClicked(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "SearchBoxVisible", false);
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateItemWidth(e.NewSize.Width-24);
        }

        private void UpdateItemWidth(double width)
        {
            if (ViewModel != null) {
                ViewModel.MyNewsItemWidth = Math.Floor(width / ViewModel.MyNewsMaximumRowsOrColumns);
            }
        }
    }
}
