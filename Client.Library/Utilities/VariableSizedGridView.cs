using Client.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Client.Utilities
{
    public class VariableSizedGridView : GridView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            try {
                var localItem = item as SimpleItem;
                if (localItem != null && localItem.Width == SimpleItem.ItemWidth.Double) {
                    element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, 2);
                }
            } catch {
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, 1);
            }

            base.PrepareContainerForItemOverride(element, item);
        }
    }
}
