using Telerik.Windows.Controls;

namespace DataTreeViewDemo.Controls {
    public class CustomRadButton : GridViewColumn {
        public override System.Windows.FrameworkElement CreateCellElement(Telerik.Windows.Controls.GridView.GridViewCell cell, object dataItem) {
            RadButton button = cell.Content as RadButton;
            if(button == null) {
                button = new RadButton();
            }
            button.CommandParameter = dataItem;
            return button;
        }
    }
}
