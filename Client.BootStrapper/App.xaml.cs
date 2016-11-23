namespace Client.UWP
{
    using Windows.ApplicationModel.Activation;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;

    public sealed partial class App
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var titleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            Color bkgColor = (Color)Current.Resources["NewsRed"];
            Color buttonHoverColor = (Color)Current.Resources["NewsHoverRed"];
            Color buttonPressedColor = (Color)Current.Resources["NewsPressedRed"];
            titleBar.BackgroundColor = bkgColor;
            titleBar.ForegroundColor = Colors.White;

            titleBar.InactiveBackgroundColor = bkgColor;
            titleBar.InactiveForegroundColor = Colors.White;

            titleBar.ButtonBackgroundColor = bkgColor;
            titleBar.ButtonForegroundColor = Colors.White;
            titleBar.ButtonHoverBackgroundColor = buttonHoverColor;
            titleBar.ButtonHoverForegroundColor = Colors.White;
            titleBar.ButtonPressedBackgroundColor = buttonPressedColor;
            titleBar.ButtonPressedForegroundColor = Colors.White;
            titleBar.ButtonInactiveBackgroundColor = bkgColor;
            titleBar.ButtonInactiveForegroundColor = Colors.White;

            var rootFrame = new Frame();

            Window.Current.Content = rootFrame;

            // rootFrame.Navigate(typeof(Views.UWPCommunityToolkitPage), e.Arguments);
            rootFrame.Navigate(typeof(Views.Shell), e.Arguments);

            Window.Current.Activate();
        }
    }
}
