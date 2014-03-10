using System.Windows.Controls;
using DataTreeViewDemo.ViewModels;
using Telerik.Pivot.Core;

namespace DataTreeViewDemo.Views {
    public partial class PivotGrid : UserControl {
        private readonly ProductViewModel _productViewModel = new ProductViewModel();
        public PivotGrid() {
            InitializeComponent();
            var localDataSourceProvider = this.Resources["LocalDataProvider"] as LocalDataSourceProvider;
            if(localDataSourceProvider != null)
                localDataSourceProvider.ItemsSource = _productViewModel.Products;
        }
    }
}
