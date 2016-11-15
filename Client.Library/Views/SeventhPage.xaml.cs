using System;
using System.ComponentModel;
using Windows.UI.Xaml;

namespace Client.Views
{
    public sealed partial class SeventhPage : INotifyPropertyChanged
    {
        public SeventhPage()
        {
            this.InitializeComponent();
            this.DataContext = this;

            Loaded += delegate {
                if (ActualWidth < 641) {
                    VisualStateManager.GoToState(this, "small", false);
                } else if (ActualWidth < 1008) {
                    VisualStateManager.GoToState(this, "medium", false);
                } else {
                    VisualStateManager.GoToState(this, "large", false);
                }
            };
        }

        private double itemWidth = 200;
        public double ItemWidth
        {
            get { return itemWidth; }
            set
            {
                itemWidth = value;
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemWidth"));
                }
            }
        }

        private int maximumRowsOrColumns = 1;
        public int MaximumRowsOrColumns
        {
            get { return maximumRowsOrColumns; }
            set
            {
                maximumRowsOrColumns = value;
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("MaximumRowsOrColumns"));
                }
            }
        }

        private int columnSpan = 1;
        public int ColumnSpan
        {
            get { return columnSpan; }
            set
            {
                columnSpan = value;
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("ColumnSpan"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {       
            ItemWidth = Math.Floor(e.NewSize.Width / maximumRowsOrColumns);
        }
    }

    public class VariableSizedGridView : Windows.UI.Xaml.Controls.GridView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            try {
                var localItem = item as FrameworkElement;
                if (localItem != null && localItem.Tag.ToString() == "Wide")
                    //element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.RowSpanProperty, localItem.RowSpan);
                    element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.ColumnSpanProperty, 2);
            } catch {
                //element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.RowSpanProperty, 1);
                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.ColumnSpanProperty, 1);
            }

            base.PrepareContainerForItemOverride(element, item);
        }
    }
}
