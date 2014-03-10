using System.Collections.ObjectModel;
using System.Windows;
using DataTreeViewDemo.ViewModels;
using DataTreeViewDemo.Views;
using Telerik.Windows.Controls;
namespace DataTreeViewDemo {
    public partial class MainPage {
        private readonly ObservableCollection<BaseDataTreeViewModel> CheckedChildItems = new ObservableCollection<BaseDataTreeViewModel>();
        private DearTiledRegionView dearTiledRegionView;
        public DearTiledRegionView DearTiledRegionView {
            get {
                if(this.dearTiledRegionView == null) {
                    this.dearTiledRegionView = new DearTiledRegionView();
                    this.dearTiledRegionView.OnTreeViewItemClick += this.DearTiledRegionView_OnTreeViewItemClick;
                    //this.dearTiledRegionView.OnTreeViewChecked += this.DearTiledRegionView_OnTreeViewChecked;
                    //this.dearTiledRegionView.OnTreeViewUnchecked += this.DearTiledRegionView_OnTreeViewUnchecked;
                }
                return this.dearTiledRegionView;
            }
        }

        //private void DearTiledRegionView_OnTreeViewUnchecked(object sender, Telerik.Windows.RadRoutedEventArgs e) {
        //    var radTreeViewItem = e.OriginalSource as RadTreeViewItem;
        //    if(radTreeViewItem == null)
        //        return;
        //    var currentItem = radTreeViewItem.Item as BaseDataTreeViewModel;
        //    if(currentItem == null) return;
        //    currentItem.CheckState = ToggleState.Off;
        //    this.ResetChildItems(currentItem);
        //    foreach(var current in this.CheckedChildItems.Where(v => this.GetChildItems(currentItem).Contains(v)).ToArray()) {
        //        this.CheckedChildItems.Remove(current);
        //    }
        //    this.radGridView.ItemsSource = null;
        //    this.radGridView.ItemsSource = this.CheckedChildItems;
        //}

        //private void DearTiledRegionView_OnTreeViewChecked(object sender, Telerik.Windows.RadRoutedEventArgs e) {
        //    var radTreeViewItem = e.OriginalSource as RadTreeViewItem;
        //    if(radTreeViewItem == null)
        //        return;
        //    var currentItem = radTreeViewItem.Item as BaseDataTreeViewModel;
        //    if(currentItem == null) return;
        //    currentItem.CheckState = ToggleState.On;
        //    foreach(var checkedItem in this.GetChildItems(currentItem).ToArray().Where(checkedItem => !this.CheckedChildItems.Contains(checkedItem))) {
        //        this.CheckedChildItems.Add(checkedItem);
        //    }
        //    this.radGridView.ItemsSource = null;
        //    this.radGridView.ItemsSource = this.GetChildItems(currentItem);
        //}

        //private ObservableCollection<BaseDataTreeViewModel> GetChildItems(BaseDataTreeViewModel parentItem) {
        //    if(parentItem.SubCategories.Count != 0)
        //        foreach(var item in parentItem.SubCategories.Where(v => v.CheckState == ToggleState.On)) {
        //            if(!_baseDataTreeViewModels.Contains(item))
        //                _baseDataTreeViewModels.Add(item);
        //            this.GetChildItems(item);
        //        }
        //    return _baseDataTreeViewModels;
        //}

        //private void ResetChildItems(BaseDataTreeViewModel parentItem) {
        //    if(parentItem.SubCategories.Count != 0)
        //        foreach(var item in parentItem.SubCategories.Where(v => v.CheckState == ToggleState.Off)) {
        //            if(_baseDataTreeViewModels.Contains(item))
        //                _baseDataTreeViewModels.Remove(item);
        //            this.ResetChildItems(item);
        //        }
        //}

        private readonly ObservableCollection<BaseDataTreeViewModel> _baseDataTreeViewModels = new ObservableCollection<BaseDataTreeViewModel>();

        private void DearTiledRegionView_OnTreeViewItemClick(object sender, Telerik.Windows.RadRoutedEventArgs e) {
            var selectItem = e.OriginalSource as RadTreeViewItem;
            if(selectItem == null) return;
            var currentItem = selectItem.Item as BaseDataTreeViewModel;
            if(currentItem == null) return;
            if(currentItem.ParentItem != null) this.ParentItem.Text = currentItem.ParentItem.Name;
            this.CurrentItem.Text = currentItem.Name;
        }

        private DamageItemDataTreeView _damageItemDataTreeView;
        public DamageItemDataTreeView DamageItemDataTreeView {
            get {
                return this._damageItemDataTreeView ?? (this._damageItemDataTreeView = new DamageItemDataTreeView());
            }
        }

        public MainPage() {
            InitializeComponent();
            this.DearTiledRegionView.SetValue(MarginProperty, new Thickness(5, 5, 5, 5));
            this.ContentStackPanel.Children.Add(this.DearTiledRegionView);
            //this.DamageItemDataTreeView.SetValue(MarginProperty, new Thickness(5, 5, 5, 5));
            //this.ContentStackPanel.Children.Add(this.DamageItemDataTreeView);
        }
    }
}
