namespace Client.UWP
{
    using System.Threading.Tasks;
    using Template10.Controls;
    using Windows.ApplicationModel.Activation;
    using Windows.UI.Xaml;

    public sealed partial class App
    {
        public App()
        {
            this.InitializeComponent();
        }

        public override UIElement CreateRootElement(IActivatedEventArgs e)
        {
            var service = this.NavigationServiceFactory(BackButton.Attach, ExistingContent.Exclude);
            return new ModalDialog {
                DisableBackButtonWhenModal = true,
                Content = new Views.Template10Page(service)
            };
        }

        public override Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            return this.NavigationService.NavigateAsync(typeof(Views.MainPage));
        }
    }
}
