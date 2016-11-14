using System;
using System.Threading.Tasks;
using Template10.Common;
using Template10.Services.NavigationService;
using Template10.Services.ViewService;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Client.Views
{
    public class NavigationServiceFake : INavigationService
    {
        Frame frame = null;
        FrameFacade facade = null;

        public NavigationServiceFake(Frame frame)
        {
            this.frame = frame;
        }

        public bool CanGoBack => this.frame.CanGoBack;

        public bool CanGoForward => this.frame.CanGoForward;

        public object Content => this.frame.Content;

        public object CurrentPageParam => null;

        public Type CurrentPageType => null;

        public DispatcherWrapper Dispatcher => null;

        public Frame Frame => this.frame;

        public FrameFacade FrameFacade => this.facade;

        public bool IsInMainView => false;

        public string NavigationState
        {
            get
            {
                return string.Empty;
            }

            set
            {
            }
        }

        public event TypedEventHandler<Type> AfterRestoreSavedNavigation;

        public void ClearCache(bool removeCachedPagesInBackStack = false)
        {
            //throw new NotImplementedException();
        }

        public void ClearHistory()
        {
            //throw new NotImplementedException();
        }

        public void GoBack(NavigationTransitionInfo infoOverride = null)
        {
            //throw new NotImplementedException();
        }

        public void GoForward()
        {
            //throw new NotImplementedException();
        }

        public Task<bool> LoadAsync()
        {
            return Task.FromResult(false);
        }

        public void Navigate(Type page, object parameter = null, NavigationTransitionInfo infoOverride = null)
        {
            //throw new NotImplementedException();
        }

        public void Navigate<T>(T key, object parameter = null, NavigationTransitionInfo infoOverride = null) where T : struct, IConvertible
        {
            //throw new NotImplementedException();
        }

        public Task<bool> NavigateAsync(Type page, object parameter = null, NavigationTransitionInfo infoOverride = null)
        {
            return Task.FromResult(false);
        }

        public Task<bool> NavigateAsync<T>(T key, object parameter = null, NavigationTransitionInfo infoOverride = null) where T : struct, IConvertible
        {
            return Task.FromResult(false);
        }

        public Task<ViewLifetimeControl> OpenAsync(Type page, object parameter = null, string title = null, ViewSizePreference size = ViewSizePreference.UseHalf)
        {
            return Task.FromResult<ViewLifetimeControl>(null);
        }

        public void Refresh()
        {
            //throw new NotImplementedException();
        }

        public void Refresh(object param)
        {
            //throw new NotImplementedException();
        }

        public Task<bool> RestoreSavedNavigationAsync()
        {
            return Task.FromResult(false);
        }

        public void Resuming()
        {
            //throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            return Task.CompletedTask;
        }

        public Task SaveNavigationAsync()
        {
            return Task.CompletedTask;
        }

        public Task SuspendingAsync()
        {
            return Task.CompletedTask;
        }
    }

    public sealed partial class Template10Page
    {
        public Template10Page()
        {
            this.InitializeComponent();

            this.Menu.NavigationService = new NavigationServiceFake(this.Frame);
        }
    }
}
