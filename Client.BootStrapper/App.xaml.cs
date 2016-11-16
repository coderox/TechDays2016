namespace Client.UWP
{
    using Windows.ApplicationModel.Activation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class App
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var rootFrame = new Frame();

            Window.Current.Content = rootFrame;

            // rootFrame.Navigate(typeof(Views.UWPCommunityToolkitPage), e.Arguments);
            rootFrame.Navigate(typeof(Views.NativePage), e.Arguments);

            Window.Current.Activate();
        }
    }
}
