namespace Client.Views
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class NativePage : Page
    {
        public NativePage()
        {
            this.InitializeComponent();
        }

        private void OnHomeClicked(object sender, RoutedEventArgs e)
        {
            this.ApplicationFrame.Navigate(typeof(MainPage));
        }

        private void OnGlobeClicked(object sender, RoutedEventArgs e)
        {
            this.ApplicationFrame.Navigate(typeof(SecondPage));
        }

        private void OnSettingsClicked(object sender, RoutedEventArgs e)
        {
            this.ApplicationFrame.Navigate(typeof(SettingsPage));
        }
    }
}
