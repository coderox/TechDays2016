using Client.Utilities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Client.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        private readonly Frame frame;

        public class MenuItem
        {
            public string Label { get; set; }
            public string Icon { get; set; }
            public Type PageType { get; set; }
            public ICommand Command { get; set; }
            public bool IsSecondaryCommand { get; set; }
        }

        private bool isMenuOpen = false;
        public bool IsMenuOpen
        {
            get { return isMenuOpen; }
            set
            {
                if (isMenuOpen != value) {
                    isMenuOpen = value;
                    if (PropertyChanged != null) {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsMenuOpen"));
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private IList<MenuItem> menuItems;
        public IList<MenuItem> PrimaryMenuItems { get { return menuItems.Where(mi => mi.IsSecondaryCommand == false).ToList(); } }
        public IList<MenuItem> SecondaryMenuItems { get { return menuItems.Where(mi => mi.IsSecondaryCommand).ToList(); } }

        private MenuItem selectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set
            {
                if (selectedMenuItem != value) {
                    selectedMenuItem = value;
                    if (selectedMenuItem != null && selectedMenuItem.PageType != null && selectedMenuItem.PageType != frame.SourcePageType) {
                        frame.Navigate(selectedMenuItem.PageType);
                    }
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMenuItem"));
                }
            }
        }

        private MenuItem selectedSecondaryMenuItem;
        public MenuItem SelectedSecondaryMenuItem
        {
            get { return selectedSecondaryMenuItem; }
            set
            {
                if (selectedSecondaryMenuItem != value) {
                    if (value == null) {
                        selectedSecondaryMenuItem = null;
                    } else {
                        if (value.PageType != null) {
                            selectedSecondaryMenuItem = value;
                            if (value.PageType != frame.SourcePageType) {
                                frame.Navigate(selectedSecondaryMenuItem.PageType);
                            }
                        } else {
                            if (selectedSecondaryMenuItem != null && selectedSecondaryMenuItem.Command != null) {
                                selectedSecondaryMenuItem.Command.Execute(null);
                            }
                        }
                    }
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedSecondaryMenuItem"));
            }
        }

        public void TriggerSelectedMenuItemChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedPrimaryMenuItem"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedSecondaryMenuItem"));
        }

        public MenuViewModel(Frame frame)
        {
            this.frame = frame;
            frame.Navigated += OnFrameNavigated;

            menuItems = new List<MenuItem> {
                new MenuItem { Label = "Today", Icon = "\uE10F" , PageType = typeof(Views.TodayPage) },
                new MenuItem { Label = "Interests", Icon = "\uE728" , PageType = typeof(Views.InterestsPage) },
                new MenuItem { Label = "Sources", Icon = "\uE158", PageType = typeof(Views.SourcesPage) },
                new MenuItem { Label = "Local", Icon = "\uE1C4" },
                new MenuItem { Label = "Videos", Icon = "\uE102" },
                new MenuItem { Label = "Send Feedback", Icon = "\uE170" },
                new MenuItem { Label = "Settings", Icon = "\uE115", PageType = typeof(Views.SettingsPage), IsSecondaryCommand = true }
            };

            SelectedMenuItem = menuItems[0];
        }

        private void OnFrameNavigated(object sender, NavigationEventArgs e)
        {
            var menuItem = menuItems.FirstOrDefault(mi => mi.PageType == e.SourcePageType);
            if (menuItem != null) {

                if (menuItem.IsSecondaryCommand) {
                    SelectedMenuItem = null;
                    SelectedSecondaryMenuItem = menuItem;
                } else {
                    SelectedMenuItem = menuItem;
                    SelectedSecondaryMenuItem = null;
                }
            }
        }
    }
}
