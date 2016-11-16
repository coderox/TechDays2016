using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Client.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnNative(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NativePage));
        }

        private void OnUWPCommunityToolkit(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UWPCommunityToolkitPage));
        }
    }
}
