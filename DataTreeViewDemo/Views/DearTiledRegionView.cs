
using System.Windows;
using System.Windows.Controls;
using DataTreeViewDemo.ViewModels;
using Telerik.Windows.Controls;

namespace DataTreeViewDemo.Views {
    public class DearTiledRegionView : DataTreeTemplate {
        private readonly DealerTiledRegionViewModel DealerTiledRegionViewModel = new DealerTiledRegionViewModel();

        protected override void InitializeControl() {
            this.DataContext = this.DealerTiledRegionViewModel;
            var stackPanel = new StackPanel {
                Orientation = Orientation.Horizontal,
                MinWidth = 100
            };
            stackPanel.Children.Add(new TextBlock {
                Text = "区域经销商",
                FontSize = 14,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5, 10, 5, 2)
            });
            this.LayoutRoot.Children.Add(stackPanel);
            this.DataTreeView.LoadOnDemand += DataTreeView_LoadOnDemand;
            base.InitializeControl();
        }

        private void DataTreeView_LoadOnDemand(object sender, Telerik.Windows.RadRoutedEventArgs e) {
            var dataContext = this.DataContext as DealerTiledRegionViewModel;
            var itemContrain = e.OriginalSource as RadTreeViewItem;
            if(dataContext == null || itemContrain == null)
                return;

            if(itemContrain.Item is BaseDataTreeViewModel && itemContrain.Level < 3) {
                var viewModel = itemContrain.Item as BaseDataTreeViewModel;
                if(!dataContext.BulidChirdrens(viewModel))
                    itemContrain.IsLoadOnDemandEnabled = false;
            } else
                DataTreeView.IsLoadOnDemandEnabled = false;
        }
    }
}
