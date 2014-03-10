using System.Collections.ObjectModel;
using DataTreeViewDemo.ViewModels;
using Telerik.Windows;
using Telerik.Windows.Controls;

namespace DataTreeViewDemo.Views {
    public abstract partial class DataTreeTemplate {
        private bool isInitialize;
        private ObservableCollection<BaseDataTreeViewModel> checkedChildItems;
        public event TreeViewDoubleClick OnTreeViewDoubleClick;
        public event TreeViewOnChecked OnTreeViewChecked;
        public event TreeViewOnUnchecked OnTreeViewUnchecked;
        public event TreeViewOnItemClick OnTreeViewItemClick;
        public event TreeViewItemExpanded OnTreeViewItemExpanded;
        public event TreeViewLoadDemand OnTreeViewLoadDemand;
        public event TreeViewItemPrepared OnTreeViewItemPrepared;

        private void Initialize() {
            this.DataTreeView.ItemClick += this.DataTreeView_ItemClick;
            this.DataTreeView.ItemPrepared += this.DataTreeView_ItemPrepared;
            this.DataTreeView.LoadOnDemand += this.DataTreeView_LoadOnDemand;
            this.DataTreeView.ItemDoubleClick += this.DataTreeView_ItemDoubleClick;
            this.DataTreeView.Checked += this.DataTreeView_Checked;
            this.DataTreeView.Unchecked += this.DataTreeView_Unchecked;
            this.WatermarkTextBox.TextChanged += this.WatermarkTextBox_TextChanged;
        }

        private void WatermarkTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            var inputValue = sender as RadWatermarkTextBox;


        }

        private void DataTreeView_ItemDoubleClick(object sender, RadRoutedEventArgs e) {
            if(this.OnTreeViewDoubleClick != null)
                this.OnTreeViewDoubleClick(sender, e);
        }

        private void DataTreeView_Unchecked(object sender, RadRoutedEventArgs e) {
            if(this.OnTreeViewUnchecked != null)
                this.OnTreeViewUnchecked(sender, e);
        }

        private void DataTreeView_Checked(object sender, RadRoutedEventArgs e) {
            if(this.OnTreeViewChecked != null)
                this.OnTreeViewChecked(sender, e);
        }

        private void DataTreeView_LoadOnDemand(object sender, RadRoutedEventArgs e) {
            if(this.OnTreeViewLoadDemand != null)
                this.OnTreeViewLoadDemand(sender, e);
        }

        private void DataTreeView_ItemClick(object sender, RadRoutedEventArgs e) {
            if(this.OnTreeViewItemClick != null)
                this.OnTreeViewItemClick(sender, e);
        }

        private void DataTreeView_ItemPrepared(object sender, RadTreeViewItemPreparedEventArgs e) {
            if(this.OnTreeViewItemPrepared != null)
                this.OnTreeViewItemPrepared(sender, e);
            //e.PreparedItem.IsLoadingOnDemand = (e.PreparedItem.Level < 1 && !(e.PreparedItem.Item is BaseDataTreeViewModel));
        }

        private void DataTreeTemplate_Loaded(object sender, System.Windows.RoutedEventArgs e) {
            if(!this.isInitialize) {
                this.InitializeControl();
            }
        }

        public delegate void TreeViewDoubleClick(object sender, RadRoutedEventArgs e);

        public delegate void TreeViewOnChecked(object sender, RadRoutedEventArgs e);

        public delegate void TreeViewOnItemClick(object sender, RadRoutedEventArgs e);

        public delegate void TreeViewOnUnchecked(object sender, RadRoutedEventArgs e);

        public delegate void TreeViewItemExpanded(object sender, RadRoutedEventArgs e);

        public delegate void TreeViewLoadDemand(object sender, RadRoutedEventArgs e);

        public delegate void TreeViewItemPrepared(object sender, RadTreeViewItemPreparedEventArgs e);

        public RadTreeViewItem SelectedItem {
            get;
            set;
        }

        /// <summary>
        /// 获取选中的子节点集合
        /// </summary>
        public ObservableCollection<BaseDataTreeViewModel> CheckedChildItems {
            get {
                return this.checkedChildItems ??
                       (this.checkedChildItems = new ObservableCollection<BaseDataTreeViewModel>());
            }
            set {
                if(checkedChildItems != value)
                    this.checkedChildItems = value;
                this.Action();
            }
        }

        private void Action() {
            var radTreeViewItem = this.SelectedItem;
            //if(radTreeViewItem != null)
            //    this.checkedChildItems = this.GetChildItems((BaseDataTreeViewModel)radTreeViewItem.Item);
        }

        protected virtual void InitializeControl() {
        }

        //private ObservableCollection<BaseDataTreeViewModel> GetChildItems(BaseDataTreeViewModel parentItem) {
        //    if(parentItem.SubCategories.Count != 0)
        //        foreach(var item in parentItem.SubCategories.Where(v => v.CheckState == ToggleState.On)) {
        //            if(!_baseDataTreeViewModels.Contains(item))
        //                _baseDataTreeViewModels.Add(item);
        //            this.GetChildItems(item);
        //        }
        //    return _baseDataTreeViewModels;
        //}



        private readonly ObservableCollection<BaseDataTreeViewModel> _baseDataTreeViewModels = new ObservableCollection<BaseDataTreeViewModel>();


        internal DataTreeTemplate() {
            InitializeComponent();
            this.Initialize();
            this.Loaded += this.DataTreeTemplate_Loaded;
        }
    }
}
