

using System.Windows;
using System.Windows.Controls;
using DataTreeViewDemo.ViewModels;
using Telerik.Windows.Controls;

namespace DataTreeViewDemo.Views {
    public class ProductDataTreeView : DataTreeTemplate {
        private readonly MainViewModel MainViewModel = new MainViewModel();
        protected override void InitializeControl() {
            this.DataContext = this.MainViewModel;
            var txt = new TextBlock {
                Text = "质损项目",
                FontSize = 14,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5, 10, 5, 2)
            };
            this.LayoutRoot.Children.Add(txt);
            this.DataTreeView.LoadOnDemand += DataTreeView_LoadOnDemand;
            base.InitializeControl();
        }

        private void DataTreeView_LoadOnDemand(object sender, Telerik.Windows.RadRoutedEventArgs e) {
            var dataContext = this.DataContext as MainViewModel;
            var itemContrain = e.OriginalSource as RadTreeViewItem;
            if(dataContext == null || itemContrain == null)
                return;

            if(itemContrain.Item is BaseDataTreeViewModel && itemContrain.Level < 1) {
                var viewModel = itemContrain.Item as BaseDataTreeViewModel;
                dataContext.BulidChirdrens(viewModel);
            } else
                DataTreeView.IsLoadOnDemandEnabled = false;
        }
    }
}
