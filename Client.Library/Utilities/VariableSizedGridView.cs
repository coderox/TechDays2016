using Client.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Client.Utilities
{
    public class VariableSizedGridView : GridView
    {
        private static Random random = new Random(1234);
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            try {
                var localItem = item as NewsItem;

                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, 1);
                var rowSpan = random.Next(1, 4);
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty, rowSpan);

                if(localItem != null)
                {
                    switch (rowSpan)
                    {
                        case (3):
                            localItem.LabelHeight = 288;
                            break;
                        default:
                            localItem.LabelHeight = 176;
                            break;
                    }
                }

                //if (localItem != null && (localItem.Columns > 1 || localItem.Rows > 1)) {
                //    element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, localItem.Columns > 1 ? localItem.Columns : 1);
                //    element.SetValue(VariableSizedWrapGrid.RowSpanProperty, localItem.Rows > 1 ? localItem.Rows : 1);
                //}
            } catch {
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, 1);
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty, 1);
            }

            base.PrepareContainerForItemOverride(element, item);
        }
    }
}
