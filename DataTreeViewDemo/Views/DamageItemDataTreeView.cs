

using System.Windows;
using System.Windows.Controls;
using DataTreeViewDemo.ViewModels;
using Telerik.Windows.Controls;

namespace DataTreeViewDemo.Views {
    public class DamageItemDataTreeView : DataTreeTemplate {
        private readonly DamageItemViewModel _damageItemViewModel = new DamageItemViewModel();
        protected override void InitializeControl() {
            this.DataContext = this._damageItemViewModel;
            var txt = new TextBlock {
                Text = "质损项目",
                FontSize = 14,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5, 10, 5, 2)
            };
            this.LayoutRoot.Children.Add(txt);
            this.DataTreeView.ItemPrepared += DataTreeView_ItemPrepared;
            this.DataTreeView.LoadOnDemand += DataTreeView_LoadOnDemand;
            base.InitializeControl();
        }

        private void DataTreeView_ItemPrepared(object sender, RadTreeViewItemPreparedEventArgs e) {

            e.PreparedItem.IsLoadOnDemandEnabled = (e.PreparedItem.Level < 5 && !(e.PreparedItem.Item is DamageItemViewModel));
        }

        private void DataTreeView_LoadOnDemand(object sender, Telerik.Windows.RadRoutedEventArgs e) {
            var dataContext = this.DataContext as DamageItemViewModel;
            var itemContrain = e.OriginalSource as RadTreeViewItem;
            if(dataContext == null || itemContrain == null)
                return;

            if(itemContrain.Item is BaseDataTreeViewModel && itemContrain.Level < 11) {
                var viewModel = itemContrain.Item as BaseDataTreeViewModel;
                dataContext.BulidChirdrens(viewModel);
            } else
                DataTreeView.IsLoadOnDemandEnabled = false;
        }
    }
}
