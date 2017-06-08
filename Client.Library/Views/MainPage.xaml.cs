using Client.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
        IExperimentsService experiments = new ExperimentsService();
        Color testColor;

        public MainPage()
        {
            this.InitializeComponent();

            Loaded += async delegate {
                await ExperimentsServiceFake.Initialize();
                await ReloadControls();
            };
        }

        private void OnPurchase(object sender, RoutedEventArgs e)
        {
            experiments.LogConversion<Color>(Experiments.PURCHASE_BUTTON_BACKGROUND_COLOR, testColor);
        }

        private async void OnReload(object sender, RoutedEventArgs e)
        {
            await ReloadControls();
        }

        private void OnReport(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(ExperimentsServiceFake.ReportResults());
        }

        private async void OnRun(object sender, RoutedEventArgs e)
        {
            //var random = new Random();
            for (int i = 0; i < 1000; i++) {
                await ReloadControls();
                await Task.Delay(5);
                if (ExperimentsServiceFake.Random.NextDouble() < 0.25) {
                    OnPurchase(null, null);
                }
            }

            OnReport(null, null);
        }

        private async Task ReloadControls()
        {
            await experiments.Initialize();

            testColor = experiments.Get<Color>(Experiments.PURCHASE_BUTTON_BACKGROUND_COLOR, Colors.Gray);
            btnPurchase.Background = new SolidColorBrush(testColor);
            experiments.LogView<Color>(Experiments.PURCHASE_BUTTON_BACKGROUND_COLOR, testColor);
        }
    }
}
